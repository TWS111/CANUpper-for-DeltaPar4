using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;
using Microsoft.VisualBasic;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using CameraHandle = System.Int32;
using System.Drawing.Imaging;
using dmBotAcTools;
using MVSDK;
using MvApi = MVSDK.MvApi;
using ListViewTest;
using OpenCvSharp;
using Point = OpenCvSharp.Point;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

//using NationalInstruments.Restricted;
//using Microsoft.VisualBasic.CompilerServices;


[StructLayout(LayoutKind.Sequential, Pack = 1)] //单字节对齐
struct CAN_Fream                 //can发送功能相关结构体  16bytes
{
    public Byte    freamHeader;          //发送标志位
    public Byte    CMD;                  //CAN 命令  //00 心跳  0x01  接收失败  0x11 接收成功   0x02 发送失败  0x12 发送成功  0x03 波特率设置失败  0x13 波特率设置成功
    public Byte    canDataLen;           //:6 数据长度
    //uint8_t canIde:1;                  //ide:0,标准帧;1,扩展帧
    //uint8_t canRtr:1;                  //rtr:0,数据帧;1,远程帧
    public UInt32  CANID;                //can ID  
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]  //指定canData 数组长度=8
    public byte[]  canData;               //Can 数据 
    public Byte    freamEnd;             //结尾
 };

struct Return_data
{
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.Struct)]  //指定canData 数组长度=8
    public byte[] Load;     //格式V x.x.x.x  预留部分空间 后续扩展使用
    [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.Struct)]  //指定canData 数组长度=8
    public byte[] App;      //格式V x.x.x.x
};
public struct Coordinate//逆解各电机角度值
{
    static public float senta1;
    static public float senta2;
    static public float senta3;
    static public float senta4;
    static public float basicplus;
}

namespace Upper0
{
    
    
    
    public partial class Form1 : Form
    {

        protected IntPtr m_Grabber = IntPtr.Zero;
        protected CameraHandle m_hCamera = 0;
        protected tSdkCameraDevInfo m_DevInfo;
        protected ColorPalette m_GrayPal;
        protected pfnCameraGrabberFrameCallback m_FrameCallback;

        SerialPort vcom = new SerialPort();
        CanProcess tocan = new CanProcess();

        FIFO canRxFIFO  = new FIFO(16 * 1024 * 1024);  //开辟16M can  FIFO
        FIFO uartRxFIFO = new FIFO(16 * 1024 * 1024);  //开辟16M 串口 FIFO
        vSeralPortProsess comm = new vSeralPortProsess();
        readonly vSeralPortProsess vcomp = new vSeralPortProsess();

        delegate void listViewDelegate(string Placeholder, string Index, string ID, string ID_Type, string ID_Format, string State, string Data_length, string DATA);

        delegate void CANDataUpdateDelegate();

        delegate void freamStatisticsDelegate();

        delegate void pressBarUpdate();
        /// <summary>
        /// 字符串队列【.NET Framework 4.0以上】
        /// </summary>
        ConcurrentQueue<byte[]> _cq = new ConcurrentQueue<byte[]>();

        /// <summary>
        /// 字节数据队列
        /// </summary>
        ConcurrentQueue<byte[]> _cqBZ = new ConcurrentQueue<byte[]>();
        //ports

        public Int32 CachedFrames = 10000;// listView 缓存帧数
        //files
       
        private long nCount_Tx = 0;
        private long nCount_Rx = 0;
        private long lastCount_Tx = 0;
        private long lastCount_Rx = 0;
        //串口发送统计
        private long uCount_Tx = 0;
        private long uCount_Rx = 0;
        private long lastuCount_Tx = 0;
        private long lastuCount_Rx = 0;
        private Int16 _busTXspeed = 0;
        private Int16 _busRXspeed = 0;
        private int _down = 0;
        private int _up = 0;
        private Int32 com_bps = 0;
        private double com_bit = 0;


        private long canCountOffset = 1000;

        public int listViewIndex = 0;
        public int listviewCountTemp = 0;
        public UInt32 listRemoveCount = 0;
        public bool comFlag = false;
        private string saveReceiveData = "";
        private bool finishJob = false;
        private bool send_pressed = false;
        public bool baudrateSetState = false;
        private byte[] currentSendFrame;
        private byte[] readFileStream;

        private int _LedIndex = 0;

        public UInt16 acToolsHeartTickCount = 0;

        private bool _closing;     //是否正在关闭串口，执行Application.DoEvents，并阻止再次

        private bool _formclosing = true; //窗口被关闭，阻止其余线程运行 

        //property variables

        private string _baudRate = string.Empty;
        private string _parity = string.Empty; 
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        Return_data return_data_t;


        //global manager variables
        private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };

        public enum TransmissionType { Text, Hex }
        public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };


        delegate void SetTextCallback(string text);
        delegate void SetBoolCallback(bool _bool);
        delegate void SetNumCallback(int num);
        delegate void VOIDSetTextCallback();

        private Thread SettextBox_receiveThread = null;  //更新textBOX
        private Thread CleartextBox_receiveThread = null;  //更新textBOX

        private string _textBox_receive = "";

        private bool _debug = true;        //是否显示调试信息


        class DoubleBufferListView : ListView
        {
            public DoubleBufferListView()
            {
                SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }
        float p_des=0.0f;//位置can四字节
        float v_des=0.0f;//速度can四字节

        public static string StringToHex(string input)
        {
            char[] chars = input.ToCharArray();
            StringBuilder hex = new StringBuilder(chars.Length * 2);

            foreach (char c in chars)
            {
                hex.AppendFormat("{0:X2}", (int)c);
            }

            return hex.ToString();
        }
        string[] canID = { "101", "103", "105", "107" };
        float speedweight = 1.0f;//移动速度权重
        float p_div = 15.0f;//移动位置分度
        float xnow = 0, ynow = 0, znow = 400, yawnow = 0;
        float xStart, yStart, zStart, yawStart;
        float xEnd, yEnd, zEnd, yawEnd;
        bool moveconf0 = false, moveconf1 = false;
        bool first = true;
        int n = 0;
        string imgpath;
        double[][] centerXY;
        void disabledbutton()//手动按键复位
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
            button29.Enabled = false;
        }
        void fresh()
        {
            label25.Text = Coordinate.senta1.ToString();
            label33.Text = Coordinate.senta2.ToString();
            label34.Text = Coordinate.senta3.ToString();
            label35.Text = Coordinate.senta4.ToString();
        }
        public void inverse(float x0, float y0, float z0)//运动学逆解 旧的！不包含yaw
         {

             float R = 107.12f;
             float r = 98.85f;
             float L = 275.5f;
             float l = 460.6f;
             float x, y, z;

             x = x0; y = y0; z = z0;

             float a1, a2, a3, a4, b1, b2, b3, b4, c1, c2, c3, c4;
             float basicplus;

             //b1 = 4 * L * (R - r - x);
             b1=b2=b3=b4 = 2 * z;

             //b2 = 4 * L * (R - r - y);
             //b3 = 4 * L * (R - r + x);
             //b4 = b2;

             basicplus = (R - r) * (R - r) + L * L + l * l + x * x + y * y + z * z;

             //a1 = basicplus - 2 * x * (R - r) - 2 * L * z;
             a1 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l - 2 * x * (R - r)) / (2 * L) + (R - r - x);
             //a2 = basicplus - 2 * y * (R - r) - 2 * L * z;
             a2 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l - 2 * y * (R - r)) / (2 * L) + (R - r - y);
             //a3 = basicplus + 2 * x * (R - r) - 2 * L * z;
             a3 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l + 2 * x * (R - r)) / (2 * L) + (R - r + x);
             a4 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l + 2 * y * (R - r)) / (2 * L) + (R - r + y);


             //c1 = basicplus - 2 * x * (R - r) + 2 * L * z;
             c1 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l - 2 * x * (R - r)) / (2*L) - (R - r - x);
             //c2 = basicplus - 2 * y * (R - r) + 2 * L * z;
             c2 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l - 2 * y * (R - r)) / (2 * L) - (R - r - y);
             //c3 = basicplus + 2 * x * (R - r) + 2 * L * z;
             c3 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l + 2 * x * (R - r)) / (2 * L) - (R - r + x);
             c4 = (x * x + y * y + z * z + (R - r) * (R - r) + L * L - l * l + 2 * y * (R - r)) / (2 * L) - (R - r + y);

             Coordinate.senta1 = (float)(-2 * Math.Atan((-b1 - Math.Sqrt(b1 * b1 - 4 * a1 * c1)) / (2 * c1)));
             Coordinate.senta2 = (float)(-2 * Math.Atan((-b2 - Math.Sqrt(b2 * b2 - 4 * a2 * c2)) / (2 * c2)));
             Coordinate.senta3 = (float)(-2 * Math.Atan((-b3 - Math.Sqrt(b3 * b3 - 4 * a3 * c3)) / (2 * c3)));
             Coordinate.senta4 = (float)(-2 * Math.Atan((-b4 - Math.Sqrt(b4 * b4 - 4 * a4 * c4)) / (2 * c4)));

         }
        public void inverse0(float x0, float y0, float z0, float yaw0)//运动学逆解 新的，包含yaw，但是只有yaw正确
        {

            float R = 102.83f;
            
            float L = 268.91f;
            float l = 460.6f;
            float h = 70.0f;
            float d = 165.2f;
            float D=31.261f;
            float H = 19.254f;
            int delta1 = -1, delta4 = -1, delta2 = 1, delta3 = 1;
            int u1 = -1, u2 = -1, u3 = 1, u4 = 1;
            int alpha1 = 1, alpha4 = 1, alpha2 = -1, alpha3 = -1;
            int beta1 = 1, beta2 = 1, beta3 = -1, beta4 = -1;
            float x, y, z, yaw;
            x = x0; y = y0; z = z0; yaw = yaw0;
            float I =  L * z;

            float a1, a2, a3, a4, b1, b2, b3, b4, j1, j2, j3, j4, k1, k2, k3, k4;
            
            a1 = (float)(x + 0.5 * u1 * h * Math.Sin( yaw) - delta1 * 0.5 * d - R * 0.5 * Math.Sqrt(2) + alpha1 * D);
            a2 = (float)(x + 0.5 * u2 * h * Math.Sin( yaw) - delta2 * 0.5 * d + R * 0.5 * Math.Sqrt(2) + alpha2 * D);
            a3 = (float)(x + 0.5 * u3 * h * Math.Sin( yaw) - delta3 * 0.5 * d + R * 0.5 * Math.Sqrt(2) + alpha3 * D);
            a4 = (float)(x + 0.5 * u4 * h * Math.Sin( yaw) - delta4 * 0.5 * d - R * 0.5 * Math.Sqrt(2) + alpha4 * D);

            b1 = (float)(y - 0.5 * u1 * h * Math.Cos( yaw) - R * 0.5 * Math.Sqrt(2) + beta1 * H);
            b2 = (float)(y - 0.5 * u2 * h * Math.Cos( yaw) - R * 0.5 * Math.Sqrt(2) + beta2 * H);
            b3 = (float)(y - 0.5 * u3 * h * Math.Cos( yaw) + R * 0.5 * Math.Sqrt(2) + beta3 * H);
            b4 = (float)(y - 0.5 * u4 * h * Math.Cos( yaw) + R * 0.5 * Math.Sqrt(2) + beta4 * H);

            j1 = (float)(-1 * L * (a1 * 0.5 * Math.Sqrt(2) + b1 * 0.5 * Math.Sqrt(2)));
            j2 = (float)(-1 * L * (-1 * a2 * 0.5 * Math.Sqrt(2) + b2 * 0.5 * Math.Sqrt(2)));
            j3 = (float)(-1 * L * (-1 * a3 * 0.5 * Math.Sqrt(2) - b3 * 0.5 * Math.Sqrt(2)));
            j4 = (float)(-1 * L * (a4 * 0.5 * Math.Sqrt(2) - b4 * 0.5 * Math.Sqrt(2)));

            k1 = (float)(0.5 * (a1 * a1 + b1 * b1 - l * l + L * L));
            k2 = (float)(0.5 * (a2 * a2 + b2 * b2 - l * l + L * L));
            k3 = (float)(0.5 * (a3 * a3 + b3 * b3 - l * l + L * L));
            k4 = (float)(0.5 * (a4 * a4 + b4 * b4 - l * l + L * L));

            Coordinate.senta1 = (float)(2 * Math.Atan((-I - Math.Sqrt(I * I - k1 * k1 + j1 * j1)) / (k1 - j1)));
            Coordinate.senta2 = (float)(2 * Math.Atan((-I - Math.Sqrt(I * I - k2 * k2 + j2 * j2)) / (k2 - j2)));
            Coordinate.senta3 = (float)(2 * Math.Atan((-I - Math.Sqrt(I * I - k3 * k3 + j3 * j3)) / (k3 - j3)));
            Coordinate.senta4 = (float)(2 * Math.Atan((-I - Math.Sqrt(I * I - k4 * k4 + j4 * j4)) / (k4 - j4)));
            Coordinate.basicplus = I * I - k1 * k1 + j1 * j1;
        }
        public void cantrans(float senta1,float senta2,float senta3,float senta4)//can包装函数，位置速度模式
        {

            //byte[] p1 = BitConverter.GetBytes(senta1);
            //byte[] p2 = BitConverter.GetBytes(senta2);
            //byte[] p3 = BitConverter.GetBytes(senta3);
            //byte[] p4 = BitConverter.GetBytes(senta4);
            //byte[] v = BitConverter.GetBytes(v_des);
            string[] PHex=new string[4];
            PHex[0] = BitConverter.ToString(BitConverter.GetBytes(senta1)).Replace("-", "");
            PHex[1] = BitConverter.ToString(BitConverter.GetBytes(senta2)).Replace("-", "");
            PHex[2] = BitConverter.ToString(BitConverter.GetBytes(senta3)).Replace("-", "");
            PHex[3] = BitConverter.ToString(BitConverter.GetBytes(senta4)).Replace("-", "");

            string V = BitConverter.ToString(BitConverter.GetBytes(v_des)).Replace("-", "");
            

            //string V = BitConverter.ToString(v).Replace("-", "");
            //string p_Hstr = StringToHex(p_str);
            //string v_Hstr = StringToHex(v_str);
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }
            for (int i = 0; i < 4; i++)
            {

                tocan.SendToCan(vcom,
                            PHex[i] + V,
                            canID[i],
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            }
           
        }
        public void  canbox()//can使能函数
        {

            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }
            for (int i = 0; i < 3; i++)
            {
                tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FC",
                            canID[i],
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);
            }
            
        }
        void cantbox()//can失能函数
        {
            
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }
            for (int i = 0; i < 4; i++)
            {
                tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FD",
                            canID[i],
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);
            }
        }
        //相机初始化
        private void InitCamera()
        {
            CameraSdkStatus status = 0;

            tSdkCameraDevInfo[] DevList;
            MvApi.CameraEnumerateDevice(out DevList);
            int NumDev = (DevList != null ? DevList.Length : 0);
            if (NumDev < 1)
            {
                MessageBox.Show("未扫描到相机");
                return;
            }
            else if (NumDev == 1)
            {
                status = MvApi.CameraGrabber_Create(out m_Grabber, ref DevList[0]);
            }
            else
            {
                status = MvApi.CameraGrabber_CreateFromDevicePage(out m_Grabber);
            }

            if (status == 0)
            {
                MvApi.CameraGrabber_GetCameraDevInfo(m_Grabber, out m_DevInfo);
                MvApi.CameraGrabber_GetCameraHandle(m_Grabber, out m_hCamera);
                MvApi.CameraCreateSettingPage(m_hCamera, this.Handle, m_DevInfo.acFriendlyName, null, (IntPtr)0, 0);

                MvApi.CameraGrabber_SetRGBCallback(m_Grabber, m_FrameCallback, IntPtr.Zero);

                // 黑白相机设置ISP输出灰度图像
                // 彩色相机ISP默认会输出BGR24图像
                tSdkCameraCapbility cap;
                MvApi.CameraGetCapability(m_hCamera, out cap);
                if (cap.sIspCapacity.bMonoSensor != 0)
                {
                    MvApi.CameraSetIspOutFormat(m_hCamera, (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);

                    // 创建灰度调色板
                    Bitmap Image = new Bitmap(1, 1, PixelFormat.Format8bppIndexed);
                    m_GrayPal = Image.Palette;
                    for (int Y = 0; Y < m_GrayPal.Entries.Length; Y++)
                        m_GrayPal.Entries[Y] = Color.FromArgb(255, Y, Y, Y);
                }

                // 为了演示如何在回调中使用相机数据创建Bitmap并显示到PictureBox中，这里不使用SDK内置的绘制操作
                //MvApi.CameraGrabber_SetHWnd(m_Grabber, this.DispWnd.Handle);

                MvApi.CameraGrabber_StartLive(m_Grabber);
            }
            else
            {
                MessageBox.Show(String.Format("打开相机失败，原因：{0}", status));
            }
            
            button21.Enabled = false;
            label37.Visible = true;
        }
        //相机画面回调
        private void CameraGrabberFrameCallback(
            IntPtr Grabber,
            IntPtr pFrameBuffer,
            ref tSdkFrameHead pFrameHead,
            IntPtr Context)
        {
            // 数据处理回调

            // 由于黑白相机在相机打开后设置了ISP输出灰度图像
            // 因此此处pFrameBuffer=8位灰度数据
            // 否则会和彩色相机一样输出BGR24数据

            // 彩色相机ISP默认会输出BGR24图像
            // pFrameBuffer=BGR24数据

            // 执行一次GC，释放出内存
            GC.Collect();

            // 由于SDK输出的数据默认是从底到顶的，转换为Bitmap需要做一下垂直镜像
            MvApi.CameraFlipFrameBuffer(pFrameBuffer, ref pFrameHead, 1);

            int w = pFrameHead.iWidth;
            int h = pFrameHead.iHeight;
            Boolean gray = (pFrameHead.uiMediaType == (uint)MVSDK.emImageFormat.CAMERA_MEDIA_TYPE_MONO8);
            Bitmap Image = new Bitmap(w, h,
                gray ? w : w * 3,
                gray ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb,
                pFrameBuffer);

            // 如果是灰度图要设置调色板
            if (gray)
            {
                Image.Palette = m_GrayPal;
            }

            this.Invoke((EventHandler)delegate
            {
                pictureBox4.Image = Image;
                pictureBox4.Refresh();
            });
        }

        public List<Point> GetSplitPoints(Point[][] contours, List<int> contourCount, int arcLength, int farDistance)//凸包检测
        {
            #region 
            List<double> lArc = new List<double>();
            //Mat src = srcImage.Clone();
            List<Point[]> lpContours = new List<Point[]>();
            List<int> hulls = new List<int>();
            Point lastP = new Point();
            Point firstP = new Point();
            Point farLastP = new Point();
            List<Point> lps = new List<Point>();
            int dot = 1;
            List<int> depth = new List<int>();
            for (int i = 0; i < contourCount.Count; i++)
            {
                InputArray inputArray = InputArray.Create<Point>(contours[contourCount[i]]);
                OutputArray outputArray = OutputArray.Create(hulls);
                Cv2.ConvexHull(inputArray, outputArray, false, false);
                if (Cv2.ArcLength(inputArray, true) < arcLength)
                {
                    //lArc.Add(Cv2.ArcLength(inputArray, true));
                    continue;
                }
                //前三个值得含义分别为：凸缺陷的起始点，凸缺陷的终点，凸缺陷的最深点（即边缘点到凸包距离最大点）。
                var defects = Cv2.ConvexityDefects(contours[contourCount[i]], hulls);
                for (int j = 0; j < defects.Length; j++)
                {
                    OpenCvSharp.Point start = contours[contourCount[i]][defects[j].Item0];
                    OpenCvSharp.Point end = contours[contourCount[i]][defects[j].Item1];
                    OpenCvSharp.Point far = contours[contourCount[i]][defects[j].Item2];
                    //OpenCvSharp.Point fart = contours[contourCount[i]][defects[j].Item3];
                    if (defects[j].Item3 > farDistance) //(4500 < defects[j].Item3 && defects[j].Item3 < 300000)
                    {
                        lps.Add(contours[contourCount[i]][defects[j].Item2]);
                        depth.Add(defects[j].Item3);
                    }
                }
            }
            #endregion
            return lps;
        }

        public List<RotatedRect> GetMinRects(Point[][] contours, List<int> contourCount)
        {
            //Cv2.ImShow(",mmmm", morphImage);

            //double rotateAngel = 0;
            Point2f[] vertices = new Point2f[4];
            //Point2f minRectcenterPoint = new Point2f();
            List<RotatedRect> minRects = new List<RotatedRect>();
            for (int i = 0; i < contourCount.Count; i++)
            {
                //获取轮廓点的矩形区域
                //绘制Rio区域最小矩形
                #region 绘制Rio区域最小矩形
                RotatedRect minRect = Cv2.MinAreaRect(contours[contourCount[i]]);
                minRects.Add(minRect);
                #endregion
            }
            return minRects;
        }
        /// <summary>
        /// 返回设置范围内的轮廓
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="range1"></param>
        /// <param name="range2"></param>
        /// <param name="contourCount"></param>
        /// <returns></returns>
        public Point[][] GetImageContours(Mat mat, int length, out List<int> contourCount)
        {
            List<double> arclength = new List<double>();
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchies;
            //Cv2.ImShow(",mmmm", mat);
            Cv2.FindContours(mat, out contours, out hierarchies, RetrievalModes.External, ContourApproximationModes.ApproxSimple, new Point());
            Mat connImg = Mat.Zeros(mat.Size(), MatType.CV_8UC3);
            Point2f[] vertices = new Point2f[4];
            Mat drawOutline = Mat.Zeros(mat.Size(), mat.Type());
            int sum = 0;
            contourCount = new List<int>();
            for (int i = 0; i < contours.Length; i++)
            {
                Rect rect1 = Cv2.BoundingRect(contours[i]);
                if (Cv2.ArcLength(contours[i], true) > length)//(rect1.Width > range1 && rect1.Height < range2)
                {
                    Cv2.DrawContours(drawOutline, contours, i, new Scalar(255, 0, 255), 2, LineTypes.Link8, hierarchies);
                    contourCount.Add(i);
                    arclength.Add(Cv2.ArcLength(contours[i], true));
                    sum++;
                }
            }
            Cv2.ImShow("contours", drawOutline);
            return contours;
        }

        public static Bitmap MatToBitmap(Mat dst)//mat转bitmap
        {
            return new Bitmap(dst.Cols, dst.Rows, (int)dst.Step(), PixelFormat.Format24bppRgb, dst.Data);
        }

        public void getpicture()//预处理，包含读取图片、灰度化、高斯降噪、二值化
        {
            //Mat img1 = new Mat(imgpath, ImreadModes.Color);
            Mat imggray = Cv2.ImRead(imgpath);
            Mat imggauss = Cv2.ImRead(imgpath);
          
            Mat img1 = Cv2.ImRead(imgpath);
            //Cv2.ImShow("win1", img1);
            Cv2.WaitKey(0);
            
            Mat imgcopy = new Mat();
            img1.CopyTo(imgcopy);
            Cv2.CvtColor(imgcopy, imggray, ColorConversionCodes.BGR2GRAY);
            OpenCvSharp.Size up = new OpenCvSharp.Size(752, 480);
            Cv2.GaussianBlur(imggray, imggauss, new OpenCvSharp.Size(11, 11), 4, 4);
            Mat binary = new Mat();
            Mat binary2 = new Mat();
            Cv2.Threshold(imggauss, binary, 65, 225, ThresholdTypes.Binary);
            Cv2.Threshold(imggray, binary2, 65, 225, ThresholdTypes.Binary);
            //Cv2.ImShow("win2", imggray);
            //Cv2.ImShow("win3", imggauss);
            //Cv2.ImShow("win4", binary);
            Cv2.ImShow("win5", binary2);

            Mat scrImage = binary;

            List<int> contourCount;
            Point[][] contours = GetImageContours(scrImage, 752, out contourCount);
            List<Point> lps = GetSplitPoints(contours, contourCount, 800, 4500);
            if (lps.Count > 1)//提取凸点坐标
            {
                Cv2.Line(scrImage, lps[0], lps[1], Scalar.Black, 2, LineTypes.Link8);
            }
            contourCount.Clear();    // 不同大小的图像处理时,需要修改length参数
            Point[][] newContours = GetImageContours(binary, 752, out contourCount);
            List<RotatedRect> rotatedRects = GetMinRects(newContours, contourCount);
            for (int i = 0; i <rotatedRects.Count; i++)
            {
                #region 绘制Rio区域最小矩形
                Point2f[] vertices = rotatedRects[i].Points();
                #endregion
                //绘制最小矩形
                #region 绘制最小矩形
                Cv2.Line(img1, Convert.ToInt32(vertices[0].X), Convert.ToInt32(vertices[0].Y), Convert.ToInt32(vertices[1].X), Convert.ToInt32(vertices[1].Y), new Scalar(0, 0, 255), 2);
                Cv2.Line(img1, Convert.ToInt32(vertices[0].X), Convert.ToInt32(vertices[0].Y), Convert.ToInt32(vertices[3].X), Convert.ToInt32(vertices[3].Y), new Scalar(0, 0, 255), 2);
                Cv2.Line(img1, Convert.ToInt32(vertices[1].X), Convert.ToInt32(vertices[1].Y), Convert.ToInt32(vertices[2].X), Convert.ToInt32(vertices[2].Y), new Scalar(0, 0, 255), 2);
                Cv2.Line(img1, Convert.ToInt32(vertices[2].X), Convert.ToInt32(vertices[2].Y), Convert.ToInt32(vertices[3].X), Convert.ToInt32(vertices[3].Y), new Scalar(0, 0, 255), 2);
                //获取重心点
                Moments M;
                M = Cv2.Moments(vertices);
                
                double cX = M.M10 / M.M00;
                double cY = M.M01 / M.M00;
                label45.Text = cX.ToString();
                label46.Text = cY.ToString();

               // centerXY[i][0] = cX;
                //centerXY[i][1] = cY;
                //显示目标中心并提取坐标点
                Cv2.Circle(img1, (int)cX, (int)cY, 2, Scalar.Yellow, 2);
                //Cv2.ImShow("img1", img1);
                Bitmap map = MatToBitmap(img1);
                pictureBox5.Image = map;
                //Console.WriteLine("AngleRect_angle: {0}", minRect.Angle);
                #endregion
            }
           // RotatedRect rect = Cv2.MinAreaRect(contours[max_area_index]);

            
        }
        
        
        public Form1()
        {
            InitializeComponent();
            disabledbutton();
            
            vcom.Encoding = Encoding.GetEncoding("Gb2312");  //支持中文发送
            CAN_richBox.ScrollToCaret();
            textBox_receive.ScrollToCaret();
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            
            //锁定窗体大小
            this.MaximizeBox = false;
            this.ControlBox = true; //(default) / false /// 设置是否出现最大化、最小化和关闭按钮 
            //this.MaxmizeBox = true; //(default) / false /// 设置最大化按钮是否有效 
            this.MinimizeBox = true; //(default) / false /// 设置最小化按钮是否有效 

            //串口数据处理进程
            Thread trdCanDataAnalysis = new Thread(CanDataAnalysis);
            trdCanDataAnalysis.IsBackground = true;  //窗体关闭时，关闭该进程。
            trdCanDataAnalysis.Start();

            //串口数据处理进程
            Thread trdUartDataAnalysis = new Thread(UartDataAnalysis);
            trdUartDataAnalysis.IsBackground = true;  //窗体关闭时，关闭该进程。
            trdUartDataAnalysis.Start();

            //串口数据接收进程
            Thread comReceiveData = new Thread(scomReceiveData);
            comReceiveData.IsBackground = true;  //窗体关闭时，关闭该进程。
            comReceiveData.Start();

            //定时更新UI进程
            Thread regularUpdate = new Thread(RegularUpdate);
            regularUpdate.IsBackground = true;  //窗体关闭时，关闭该进程。
            regularUpdate.Start();

            //精准定时 统计
            Thread freamStatistics = new Thread(FreamStatistics);
            freamStatistics.IsBackground = true;  //窗体关闭时，关闭该进程。
            freamStatistics.Start();

            //杂项初始化：
            button2.Enabled = false;
            button2.ForeColor = Color.White;

            //button21.Attributes.Add("onClick", "document.forms[0].reset();return false;");//复位键，不可用

            m_FrameCallback = new pfnCameraGrabberFrameCallback(CameraGrabberFrameCallback);
        }

        public enum HardwareEnum
        {
            // 硬件
            Win32_Processor, // CPU 处理器
            Win32_PhysicalMemory, // 物理内存条
            Win32_Keyboard, // 键盘
            Win32_PointingDevice, // 点输入设备，包括鼠标。
            Win32_FloppyDrive, // 软盘驱动器
            Win32_DiskDrive, // 硬盘驱动器
            Win32_CDROMDrive, // 光盘驱动器
            Win32_BaseBoard, // 主板
            Win32_BIOS, // BIOS 芯片
            Win32_ParallelPort, // 并口
            Win32_SerialPort, // 串口
            Win32_SerialPortConfiguration, // 串口配置
            Win32_SoundDevice, // 多媒体设置，一般指声卡。
            Win32_SystemSlot, // 主板插槽 (ISA & PCI & AGP)
            Win32_USBController, // USB 控制器
            Win32_NetworkAdapter, // 网络适配器
            Win32_NetworkAdapterConfiguration, // 网络适配器设置
            Win32_Printer, // 打印机
            Win32_PrinterConfiguration, // 打印机设置
            Win32_PrintJob, // 打印机任务
            Win32_TCPIPPrinterPort, // 打印机端口
            Win32_POTSModem, // MODEM
            Win32_POTSModemToSerialPort, // MODEM 端口
            Win32_DesktopMonitor, // 显示器
            Win32_DisplayConfiguration, // 显卡
            Win32_DisplayControllerConfiguration, // 显卡设置
            Win32_VideoController, // 显卡细节。
            Win32_VideoSettings, // 显卡支持的显示模式。

            // 操作系统
            Win32_TimeZone, // 时区
            Win32_SystemDriver, // 驱动程序
            Win32_DiskPartition, // 磁盘分区
            Win32_LogicalDisk, // 逻辑磁盘
            Win32_LogicalDiskToPartition, // 逻辑磁盘所在分区及始末位置。
            Win32_LogicalMemoryConfiguration, // 逻辑内存配置
            Win32_PageFile, // 系统页文件信息
            Win32_PageFileSetting, // 页文件设置
            Win32_BootConfiguration, // 系统启动配置
            Win32_ComputerSystem, // 计算机信息简要
            Win32_OperatingSystem, // 操作系统信息
            Win32_StartupCommand, // 系统自动启动程序
            Win32_Service, // 系统安装的服务
            Win32_Group, // 系统管理组
            Win32_GroupUser, // 系统组帐号
            Win32_UserAccount, // 用户帐号
            Win32_Process, // 系统进程
            Win32_Thread, // 系统线程
            Win32_Share, // 共享
            Win32_NetworkClient, // 已安装的网络客户端
            Win32_NetworkProtocol, // 已安装的网络协议
            Win32_PnPEntity,//all device
        }
        /// <summary>
        /// WMI取硬件信息
        /// </summary>
        /// <param name="hardType"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        private static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
        {

            List<string> strs = new List<string>();
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
                {
                    var hardInfos = searcher.Get();
                    foreach (var hardInfo in hardInfos)
                    {
                        if (hardInfo.Properties[propKey].Value != null)
                        {
                            String str = hardInfo.Properties[propKey].Value.ToString();
                            if (str.Contains("AcTools"))
                            {
                                strs.Add(str);
                            }
                        }
                    }
                }
                return strs.ToArray();
            }
            catch
            {
                MessageBox.Show("未发现设备！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                strs = null;
            }
        }//end of func GetHarewareInfo().
        //通过WMI获取COM端口

        # region getPortByVPid
        /// <summary>
        /// Compile an array of COM port names associated with given VID and PID
        /// </summary>
        /// <param name="VID">string representing the vendor id of the USB/Serial convertor</param>
        /// <param name="PID">string representing the product id of the USB/Serial convertor</param>
        /// <returns></returns>
        private static List<string> getPortByVPid(String VID, String PID)
        {
            String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<string> comports = new List<string>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");

            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            comports.Add((string)rk6.GetValue("PortName"));
                        }
                    }
                }
            }
            return comports;
        }
        #endregion

        #region nullModemCheck
        /// <summary>
        /// Removes any comm ports that are not explicitly defined as allowed in ALLOWED_TYPES
        /// </summary>
        /// <param name="allPorts">reference to List that will be checked</param>
        /// <returns></returns>
        private static List<string> nullModemCheck(List<string> allPorts)
        {
            // Open registry to get the COM Ports available with the system
            RegistryKey regKey = Registry.LocalMachine;
            List<String> ComPort = new List<String>();
            UInt16 i = 0;
            // Defined as: private const string REG_COM_STRING ="HARDWARE\DEVICEMAP\SERIALCOMM";
            string REG_COM_STRING = "HARDWARE\\DEVICEMAP\\SERIALCOMM";
            regKey = regKey.OpenSubKey(REG_COM_STRING);

            Dictionary<string, string> tempDict = new Dictionary<string, string>();
            foreach (string p in allPorts)
            {

                if (p != null)
                {
                    tempDict.Add(p, p);
                }

            }

            // This holds any matches we may find
            string match = "";
            foreach (string subKey in regKey.GetValueNames())
            {
                // Name must contain either VCP or Seial to be valid. Process any entries NOT matching
                // Compare to subKey (name of RegKey entry)
                if (!(subKey.Contains("Serial") || subKey.Contains("VCP")))
                {
                    // Okay, this might be an illegal port.
                    // Peek in the dictionary, do we have this key? Compare to regKey.GetValue(subKey)
                    if (tempDict.TryGetValue(regKey.GetValue(subKey).ToString(), out match))
                    {
                        // Kill it!
                        ComPort.Add(match);
                        allPorts.Remove(match);
                        i++;
                        // Reset our output string
                        match = "";
                    }

                }

            }
            regKey.Close();
            return ComPort;
        }
        #endregion

        #region OpenDevice
        public bool OpenDevice(SerialPort com)
        {

            string commData = "";
            //string[] available_spectrometers = SerialPort.GetPortNames();

            string VID = (string)"0484";
            string PID = (string)"5742";
            com.BaudRate = 10000000;
            const StopBits one = StopBits.One;
            com.StopBits = one;
            com.DataBits = 8;//数据位
            com.Parity = Parity.None;
            //string[] ss = GetHarewareInfo(HardwareEnum.Win32_SerialPort, "Name");
            UInt16 count = 0;
            List<string> allPorts = getPortByVPid(VID, PID);

            List<String> ComPort = new List<String>();
            try
            {
                if ((allPorts != null) && (allPorts.Count > 0))
                {
                    ComPort = nullModemCheck(allPorts);
                }
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error");
            }
            if (ComPort != null && ComPort.Count > 0)
            {
                for (int i =0;i< ComPort.Count; i++)
                {

                    if (ComPort[i] != null)
                    {
                        commData = (string)ComPort[i];
                        ComPort.Clear();
                        com.PortName = commData;

                        try
                        {
                            if (!com.IsOpen)
                            {
                                com.Open();
                            }
                            else
                            {
                                try
                                {
                                    ComPort.RemoveAt(i);
                                }
                                catch (System.Exception ex1)
                                {
                                    MessageBox.Show("无法打开设备:" + ex1.Message, "Error"); ;
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.Message, "Error");
                            MessageBox.Show("设备异常断开，无法打开。请重新连接设备！" , "Error");

                            //continue;
                            //return;
                        }
                        if (com.IsOpen)
                        {
                            byte[] temp = new byte[com.BytesToRead + 20480];
                            com.Read(temp, 0, com.BytesToRead);    //清空串口缓存 防止影响握手
                            byte[] stopBuf = { 0x55, 0x03, 0xAA, 0x55 };
                            vcom.Write(stopBuf, 0, 4);//停止发送
                            Thread.Sleep(100);
                            com.Read(temp, 0, com.BytesToRead);    //清空串口缓存 防止影响握手
                            vcom.DiscardInBuffer();//清空输入缓存 

                            Byte[] buff = new Byte[4];
                            buff[0] = 0x55;                     //帧头
                            buff[1] = 0x02;                     //与设备握手命令
                            buff[2] = 0xaa;
                            buff[3] = 0x55;

                            com.Write(buff, 0, 4);//与设备握手
                            Thread.Sleep(1000);
                            int bufferlen = 17;
                            if (com.BytesToRead == 0)
                            {
                                com.Write(buff, 0, 4);//设置时间
                            }
                            while ((com.BytesToRead != bufferlen) && (count < 65535))
                            {
                                count++;
                                if (count >= 65534)
                                {
                                    MessageBox.Show("连接设备超时，请重新尝试连接！", "提示");
                                    return false;
                                }
                            }
                            byte[] Rxbuff = new byte[bufferlen + 1024];
                            com.Read(Rxbuff, 0, bufferlen);  //读取设置是否OK 

                            string str = System.Text.Encoding.Default.GetString(Rxbuff);
                            if (Regex.IsMatch(str, "设备连接成功 !\r\n"))
                            {
                                SendHeartTickPackage(com);                 //发送总线心跳包 0x03 心跳命令
                                com.Read(Rxbuff, 0, com.BytesToRead);      //清空前序数据
                                com.DiscardInBuffer();//清空握手数据

                                //MessageBox.Show("连接设备成功", "提示");
                                comFlag = true;

                                return true;

                            }
                            else
                            {
                                com.DiscardOutBuffer();
                                com.DiscardInBuffer();
                                com.Close();
                                MessageBox.Show("设置失败", "提示");
                                return false;
                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("查找不到设备，请检查连接状态，并尝试重新连接！", "提示");

            }
            return false;
        }
        #endregion



        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void scomReceiveData()
        {
            while (true)
            {
                Thread.Sleep(1);
                if (!comFlag)
                {
                    continue;
                }
                if (_closing) continue; //如果正在关闭，忽略操作，直接返回，尽快的完成串口监听线程的一次循环
                if (!_formclosing) continue; //窗体关闭 禁止执行线程
                if (!vcom.IsOpen) continue;  //串口被意外关闭
                try
                {
                    int _temp = vcom.BytesToRead;
                    for (; (_temp >= 16) && (vcom.IsOpen);)
                    {
                        _temp = vcom.BytesToRead;
                        byte[] buf = new byte[16];
                        if ((vcom.IsOpen))
                        { 
                            _temp -= 16;
                            vcom.Read(buf, 0, 16);
                        }
                        else
                            continue;
                        if ((buf[0] == 0xAA) && (buf[15] == 0x55))
                        {
                            lock (canRxFIFO)
                            {
                                canRxFIFO.WriteBuffer(buf, 0, 16);
                            }
                            continue;
                        }
                        else
                        {
                            for (byte i = 0 ; i < 16; i++) //寻找帧头
                            {
                                upack: if(buf[i] == 0xAA)
                                {
                                    if (i == 0) //防止截取后 第一帧就是
                                    {
                                        if (buf[15] == 0x55) //此帧是
                                        {
                                            lock (canRxFIFO)
                                            {
                                                canRxFIFO.WriteBuffer(buf, 0, 16);
                                            }
                                            i = 16; //退出
                                        }
                                    }
                                    else if ((i == 0) && (_temp == 0)) //此帧不是
                                    {
                                        lock (uartRxFIFO)
                                        {
                                            uartRxFIFO.WriteBuffer(buf, 0, 16);
                                        }
                                        i = 16; //退出
                                    }
                                    else if (_temp >= i)  //后面还有数据
                                    {
                                        byte[] _buf = new byte[1024];
                                        if ((vcom.IsOpen))
                                        {
                                            vcom.Read(_buf, 0, i);
                                            _temp -= i;
                                            if (_buf[i - 1] == 0x55) //此帧是
                                            {
                                                byte[] _temp_buf = new byte[16];
                                                Array.Copy(buf, i, _temp_buf, 0, 16 - i);
                                                Array.Copy(_buf, 0, _temp_buf, 16 - i, i);

                                                lock (canRxFIFO)
                                                {
                                                   canRxFIFO.WriteBuffer(_temp_buf, 0, 16);
                                                }
                                                lock (uartRxFIFO)
                                                {
                                                    uartRxFIFO.WriteBuffer(buf, 0, i);
                                                }
                                                i = 16;  //下一次循环
                                            }
                                            else
                                            {
                                                lock (uartRxFIFO)
                                                {
                                                    uartRxFIFO.WriteBuffer(buf, 0, i);
                                                }
                                                //复位数组 重新开始寻找
                                                byte[] _temp_buf = new byte[16];
                                                Array.Copy(buf, i, _temp_buf, 0, 16 - i);
                                                Array.Copy(_buf, 0, _temp_buf, 16 - i, i);
                                                Array.Copy(_temp_buf, 0, buf, 0, 16);

                                                i = 0;
                                                goto upack;
                                                //continue;
                                            }
                                        }
                                    }
                                    else  //不是CAN数据
                                    {
                                        lock (uartRxFIFO)
                                        {
                                            uartRxFIFO.WriteBuffer(buf, 0, 16);
                                        }
                                        i = 16;  //下一次循环
                                        //continue;
                                    }
                                }
                                if (i == 15) //循环完  未发现帧头
                                {
                                    lock (uartRxFIFO)
                                    {
                                        uartRxFIFO.WriteBuffer(buf, 0, 16);
                                    }
                                }
                            }
                            
                        }
                    }
                    if ((_temp  < 16) && (_temp > 0))  //非CAN 数据帧
                    {
                        byte[] __buf = new byte[_temp + 1024];
                        if ((vcom.IsOpen))
                        {
                            vcom.Read(__buf, 0, _temp);
                            lock (uartRxFIFO)
                            {
                                uartRxFIFO.WriteBuffer(__buf, 0, _temp);
                            }
                        }

                    }
                }
                catch
                {
                    continue;
                }

            }
        }
        /// <summary>
        /// 数据解析
        /// </summary>
        StringBuilder _canDataToDisp = new StringBuilder();
        public void CanDataAnalysis()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            //saveFileDialog.InitialDirectory = "C:\\";
            saveFileDialog.FileName = "test.txt";
            string FileName = saveFileDialog.FileName;
            saveFileDialog.Filter = " txt files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            //StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
            //sw.WriteLine("序号  " + "  ID  " + "  帧格式  " + "  帧类型  " + "  状态  " + "   数据    " + Environment.NewLine);


            try
            {
                CAN_Fream canFream_t = new CAN_Fream();
                string _canid = "xxxxxxxxxxxxxxxxxxxx"; //占位  防止内存回收
                while (true)
                {

                    Thread.Sleep(1);
                    if (!_formclosing) continue; //窗体关闭 禁止执行线程
                    if (!vcom.IsOpen) continue;  //串口被意外关闭
                    for (; (canRxFIFO.DataEnd >= 16) && (vcom.IsOpen);)
                    {
                        string _idtype, _index, _idformat, _canstate, _candatalen, _candata;
                        try
                        {

                            byte[] buf = new byte[16];

                            lock (canRxFIFO)
                            {
                                canRxFIFO.ReadBuffer(buf, 0, 16);
                                canRxFIFO.Clear(16);
                            }

                            canFream_t = (CAN_Fream)tocan.BytesToStruct(buf, typeof(CAN_Fream));    //listViewData.Invoke(listDelegate," ", Convert.ToString(listViewIndex), Convert.ToString(canFream_t.CANID), "xx", "xx", "xx", Convert.ToString(canFream_t.canDataLen & 0x0f), BitConverter.ToString(canFream_t.canData));

                            _canid = Convert.ToInt32(canFream_t.CANID).ToString("X").PadLeft(12, ' ');  //占位12位 填充空格;

                            if ((canFream_t.canDataLen & 0x40) == 0x40)
                                _idtype = "  扩展帧  ";
                            else
                                _idtype = "  标准帧  ";

                            if ((canFream_t.canDataLen & 0x80) == 0x80)
                                _idformat = "  远程帧  ";
                            else
                                _idformat = "  数据帧  ";

                            _canstate = tocan.ParsingCommand(canFream_t.CMD); //发送次数计数

                            //解析命令 心跳 
                            if (_canstate == "心跳数据")
                            {
                                acToolsHeartTickCount = 0;  //解析心跳数据 重置心跳计数
                                continue;
                            }
                            //解析 波特率设置命令状态
                            if (_canstate.Contains("波特率"))
                            {
                                if (_canstate.Contains("成功"))
                                {
                                    baudrateSetState = true;
                                }
                                else
                                    baudrateSetState = false;
                                continue; //退出  不显示

                            }

                            if (_canstate.Contains("发送"))
                                nCount_Tx++;
                            else if (_canstate.Contains("接收"))
                                nCount_Rx++;

                            _candatalen = Convert.ToString(canFream_t.canDataLen & 0x0f).PadLeft(4, ' ');  //占位12位 填充空格;

                            if (_idformat == "远程帧")
                                _candata = "Remote frame";
                            else
                                _candata = BitConverter.ToString(canFream_t.canData, 0, (canFream_t.canDataLen & 0x0f)).Replace("-", " ").PadLeft(26, ' ');  //占位12位 填充空格;//取 canFream_t.canDataLen个
                        }
                        catch //()
                        {
                            continue;
                        }

                        StringBuilder lv = new StringBuilder();
                        string _pctime = DateTime.Now.TimeOfDay.ToString().PadLeft(20, ' ');
                        listViewIndex++; //索引值计数
                        _index = Convert.ToString(listViewIndex).PadLeft(12, ' ');  //占位12位 填充空格
                                                                                    //lv.SubItems.Add(" ");
                        lv.Append(_index);

                        lv.Append(_pctime);
                        lv.Append(_idtype);
                        lv.Append(_idformat);
                        lv.Append(_canstate);
                        lv.Append(_candatalen);
                        lv.Append(_candata);
                        lv.Append(_canid);
                        lv.Append(Environment.NewLine);

                        _canDataToDisp.Append(lv);


                        StreamWriter sw = new StreamWriter(saveFileDialog.FileName, true);
                        if (first == true)
                        {
                            sw.WriteLine("序号  " + "  ID  " + "  帧格式  " + "  帧类型  " + "  状态  " +  "   数据    " + Environment.NewLine);
                        }


                        //StreamWriter sw0 = new StreamWriter(saveFileDialog.FileName,true);

                        sw.Write(_pctime + _index + _canid + _canstate + _candata);
                        sw.Write(Environment.NewLine);  //插入换行符
                                                        //sw.Dispose();
                        sw.Close();

                        //String fname = saveFileDialog.FileName;
                        //System.IO.File.WriteAllText(fname, _pctime + _index + _canid + _canstate + _candata);
                        //System.IO.File.WriteAllText(fname, Environment.NewLine);




                        /*{
                            var data = new List<csvloader>
                        {
                            new csvloader{
                                Time=_pctime,
                                Index=_index,
                                ID=_canid,
                                CANState=_canstate,
                                CANData=_candata
                            }
                        };


                            using (var writer = new StreamWriter("testflie.csv", true))
                            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                            {

                                csv.WriteRecords(data);
                            }
                        }*/
                        this.Invoke(new EventHandler(delegate
                        {
                            label22.Text = UnicodeEncoding.Default.GetBytes(_pctime + _index + _canid + _candata).Length.ToString();
                        }));
                        this.Invoke(new EventHandler(delegate
                        {
                            label21.Text = _index;
                        }));
                        first = false;
                    }

                }


            }
            catch
            {
                MessageBox.Show("输入流异常");
            }

        }
   
        

        /// <summary>
        /// 数据解析
        /// </summary>
        public void UartDataAnalysis()
        {
            while (true)
            {

                Thread.Sleep(20);
                if (!_formclosing) continue; //窗体关闭 禁止执行线程
                if (!vcom.IsOpen) continue;  //串口被意外关闭
                for (; (uartRxFIFO.DataEnd > 0) && (vcom.IsOpen);)
                {

                    try
                    {
                        //定时更新UI显示接收数据
                        lock (uartRxFIFO) //显示buf
                        {
                            int readlength = uartRxFIFO.DataCount;
                            if (readlength > 0)
                            {
                                try
                                {
                                    byte[] buf = new byte[readlength];
                                    uartRxFIFO.ReadBuffer(buf, 0, readlength);
                                    uartRxFIFO.Clear(readlength);
                                    uCount_Rx += buf.Length;
                                    UpdateText(buf, buf.Length);  //更新显示
                                    
                                }
                                catch (Exception ex)
                                {
                                    //if (_debug)
                                    {
                                        MessageBox.Show(ex.Message);
                                        MessageBox.Show("出错啦啦啦！", "RegularUpdate");
                                    }
                                    continue;
                                }
                            }

                        }
                    }
                    catch //(Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
        private void UpdateText(byte[] text, int length)
        {
            try
            {
               // nCount_Rx += length;

                //this.Setlabel_RXThread = new Thread(new ThreadStart(this.Setlabel_RXThreadProcSafe));
                //this.Setlabel_RXThread.Start();

                string str = System.Text.Encoding.Default.GetString(text);
                str = str.Replace("\0", ""); //防止textBox_receive.AppendText遇到 \0 舍弃后面的字符串
                if (!this.HEXDisplay.Checked)  //仅ASCII 模式下 处理换行，HEX模式下 按接收信息 原样显示
                {
                    str = str.Replace("\r", "");
                    str = str.Replace("\n", Environment.NewLine); //替换换行符
                    if (!str.Contains("\n")) //增加换行符
                    {
                        str += Environment.NewLine;
                    }
                }
                else//if (RXDisplayHEX.Checked)  两者互斥//显示内容转换成hex
                {
                    //byte[] ba = Encoding.Default.GetBytes(text);
                    var hexString = BitConverter.ToString(text, 0, length);
                    str = hexString.Replace("-", " 0x");
                    str = "0x" + str + " ";
                }
                _textBox_receive = str;
                this.SettextBox_receiveThread = new Thread(new ThreadStart(this.SettextBox_receiveThreadProcSafe));
                this.SettextBox_receiveThread.Start();


                this.CleartextBox_receiveThread = new Thread(new ThreadStart(this.CleartextBox_receiveThreadProcSafe));
                this.CleartextBox_receiveThread.Start();

            }
            catch (Exception ex)
            {
                //if (_debug)
                    MessageBox.Show(ex.Message);
            }

        }
        private void SettextBox_receiveThreadProcSafe()
        {
            this.SettextBox_receive(_textBox_receive);
        }

        private void SettextBox_receive(string text)
        {
            if (this.textBox_receive.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SettextBox_receive);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                //this.textBox_receive.Text = text;
                this.textBox_receive.AppendText(text);
                //this.textBox_receive.ScrollToCaret();
            }
        }

        private void CleartextBox_receiveThreadProcSafe()
        {
            this.CleartextBox_receive();
        }

        private void CleartextBox_receive()
        {
            if (this.textBox_receive.InvokeRequired)
            {
                VOIDSetTextCallback d = new VOIDSetTextCallback(CleartextBox_receive);
                this.BeginInvoke(d, new object[] { });
            }
            else
            {
                if (this.textBox_receive.GetLineFromCharIndex(this.textBox_receive.TextLength) > 100000)     //超过100W行清空一半 防止内存溢出
                {
                    string[] sLines = this.textBox_receive.Lines;
                    string[] sNewLines = new string[sLines.Length / 2 + 1];
                    try
                    {
                            Array.Copy(sLines, sLines.Length / 2, sNewLines, 0, sLines.Length - sLines.Length / 2);
                            this.textBox_receive.Lines = sNewLines;
                    }
                    catch (Exception ex)
                    {
                        if (_debug)
                            MessageBox.Show(ex.Message);
                    }

                }
            }
        }

        #endregion

        #region OpenDevice
        public bool CloseDevice(SerialPort com)
        {
            _closing = true;
            if (com.IsOpen)
            {
                com.DiscardOutBuffer();
                com.DiscardInBuffer();
                com.Close();
                if (!com.IsOpen)
                    return true;
            }
            MessageBox.Show("设备关闭失败！", "提示");
            return false;
        }

        #endregion

        private void SetDefaultsParameter()  //设置默认参数
        {
            frameType.SelectedIndex = 0;         //帧类型
            frameId.SelectedText    = "0";          //帧ID
            sendTimes.SelectedText  = "1";        //发送次数

            frameFormat.SelectedIndex = 0;        //帧格式
            sendInterval.SelectedText = "1";        //时间间隔
            canBaudrateComBox.SelectedIndex = 0;  //波特率

            frameId.SelectedText  = "00";
            canData1.SelectedText = "12";
            canData2.SelectedText = "23";
            canData3.SelectedText = "34";
            canData4.SelectedText = "45";
            canData5.SelectedText = "56";
            canData6.SelectedText = "67";
            canData7.SelectedText = "78";
            canData8.SelectedText = "89";

            string[] ports = SerialPort.GetPortNames();//获取可用串口
            if (ports.Length > 0)//ports.Length > 0说明有串口可用
            {
                comboBoxPort.Items.AddRange(ports);
                comboBoxPort.SelectedIndex = 0;//默认选第1个串口
            }
            else//未检测到串口
            {
                MessageBox.Show("无可用串口");
            }

        }

        private void Form1_Load(object sender, EventArgs e)  //
        {
            SetDefaultsParameter();


            string[] ports = SerialPort.GetPortNames();//获取可用串口
            //↓↓↓↓↓↓↓↓↓波特率下拉控件↓↓↓↓↓↓↓↓↓
            comboBoxBaudrate.SelectedIndex = 9;
            DataBit.SelectedIndex  = 0;
            StopBit.SelectedIndex  = 0;
            CheckBit.SelectedIndex = 0;

        }

        private byte CRC_8(byte[] source, int len)
        {
            byte CRC = 0;
            int i;
            int count = 0;
            while ((len--) != 0)
            {
                CRC ^= source[count];
                count++;
                for (i = 0; i < 8; i++)
                {
                    if ((CRC & 0x01) == 1)
                    {
                        CRC = (byte)((CRC >> 1) ^ 0x8C);
                    }
                    else
                    {
                        CRC >>= 1;
                    }
                }
            }
            return CRC;
        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vcom.IsOpen)
                vcom.Close();
            //this.Close(); //只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出； 
            //System.Windows.Forms.Application.Exit(); //强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出； 
            //System.Windows.Forms.Application.ExitThread(); //强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题； 
            System.Environment.Exit(0); //这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。 
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber);
            MvApi.CameraGrabber_Destroy(m_Grabber);
            _formclosing = false;
        }



        private void openButton_Click(object sender, EventArgs e)
        {
            if (!vcom.IsOpen) //未打开
            {
                _closing = false;
                vcom.Encoding = Encoding.Default;
                string strDataBit = DataBit.SelectedItem.ToString();
                string strCheckBit = CheckBit.SelectedItem.ToString();
                string strStopBit = StopBit.SelectedItem.ToString();
                Int32 iDataBit = Convert.ToInt32(strDataBit);
                vcom = new SerialPort();
                vcom.PortName = comboBoxPort.SelectedItem.ToString();
                vcom.BaudRate = Convert.ToInt32(comboBoxBaudrate.SelectedItem.ToString());//波特率;
                vcom.DataBits = iDataBit;//数据位
                switch (strStopBit)            //停止位
                {
                    case "One":
                        vcom.StopBits = StopBits.One;
                        break;
                    case "OnePointFive":
                        vcom.StopBits = StopBits.OnePointFive;
                        break;
                    case "Two":
                        vcom.StopBits = StopBits.Two;
                        break;
                    default:
                        MessageBox.Show("Error：停止位参数不正确!", "Error");
                        break;
                }
                //textBox_receive.Text += " switch (strCheckBit) ";
                switch (strCheckBit)             //校验位
                {
                    case "None":
                        vcom.Parity = Parity.None;
                        break;
                    case "Odd":
                        vcom.Parity = Parity.Odd;
                        break;
                    case "Even":
                        vcom.Parity = Parity.Odd;
                        break;
                    default:
                        MessageBox.Show("Error：校验位参数不正确!", "Error");
                        break;
                }

                vcom.ReadTimeout = 500;
                vcom.WriteTimeout = 500;
                if (!vcom.IsOpen)
                {
                    try
                    {
                        vcom.Open();
                        if (serialPort.IsOpen)
                        {
                            vcom.NewLine = "/r/n";
                            vcom.RtsEnable = true;
                        }
                        textBox1.Text += "端口已连接\n";
                    }
                    catch (System.Exception ex)
                    {
                        vcom = new SerialPort();
                        MessageBox.Show("无法打开设备:" + ex.Message, "Error"); ;
                    }

                }
                //统计使用
                com_bps = Convert.ToInt32(comboBoxBaudrate.SelectedItem.ToString());
                byte _stopbit = 0;
                byte _parity = 0;
                UInt32 _baudrate = 0;
                _baudrate = Convert.ToUInt32(comboBoxBaudrate.SelectedItem.ToString());
                switch (serialPort.StopBits.ToString())
                {
                    case "One":
                        _stopbit = 1;
                        break;
                    case "Two":
                        _stopbit = 2;
                        break;
                }
                if (serialPort.Parity.ToString() == "None")
                    _parity = 0;
                else
                    _parity = 1;


                com_bit = iDataBit + _stopbit + _parity;


               
                if (vcom.IsOpen == true)
                {
                    openButton.Enabled = false;
                    buttonFresh.Enabled = false;
                    comFlag = true;
                    button2.Enabled = true;
                    button2.ForeColor = Color.Black;

                }
            }
            else
            {
                _closing = true;
                if (CloseDevice(vcom) == true)
                {
                   
                    //清空canFIFO
                    canRxFIFO.Clear(canRxFIFO.DataCount);
                    buttonFresh.Enabled = true;
                }
            }
        }
        
        private void sendButton_Click(object sender, EventArgs e)  //发送按键
        {
            if (vcom.IsOpen)
            {
                Byte _idacc = 0, _dataacc = 0;

                if (IdAccCheckBox.Checked)
                {
                    _idacc = 1;
                }
                if (DataAccCheckBox.Checked)
                {
                    _dataacc = 1;
                }

                tocan.SendToCan(vcom,
                                canData1.Text + canData2.Text + canData3.Text + canData4.Text + canData5.Text + canData6.Text + canData7.Text + canData8.Text,
                                frameId.Text,
                                sendTimes.Text,
                                sendInterval.Text,
                                (Byte)frameType.Items.IndexOf(frameType.Text),
                                (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                                _idacc,
                                _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            }
            else
            {
                MessageBox.Show("请先打开设备！", "提示"); ;
            }
        }


        private void stopButoon_Click(object sender, EventArgs e)
        {
            byte[] stopBuf = { 0x55, 0x03, 0xAA, 0x55 };
            vcom.Write(stopBuf, 0, 4);//停止发送
        }


        private void sendTimes_TextChanged(object sender, EventArgs e)
        {
            if (sendTimes.Text.Length > 10)
            {
                sendTimes.Text = "4294967295";
                MessageBox.Show("最大发送次数为：4294967295");
            }
            else if ((Convert.ToUInt64(sendTimes.Text.ToString()) > 4294967295))
            {
                sendTimes.Text = "4294967295";
                MessageBox.Show("最大发送次数为：4294967295");
            }
        }


       private void cleanData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
                this.CAN_richBox.Clear(); //只移除所有的项
                tocan.FlushMemory(); //回收内存
                listViewIndex = 0;
                //清空统计信息
                nCount_Tx = 0;
                nCount_Rx = 0;
                lastCount_Tx = 0;
                lastCount_Rx = 0;
            

        }

        public void saveData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.CAN_richBox.Text == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string FileName = saveFileDialog.FileName;

            if (FileName.Length > 0)
            {

                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);

                streamWriter.WriteLine("序号  "+ "  ID  "+ "  帧格式  "+ "  帧类型  "+ "  状态  " + "数据长度" + "   数据    "+ Environment.NewLine);   //存储表头
                streamWriter.Write(this.CAN_richBox.Text);
                streamWriter.Write(Environment.NewLine);  //插入换行符
                streamWriter.Close();
                MessageBox.Show("文件已成功保存");
            }
        }

        private void RegularUpdate()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (_formclosing)
                {
                    Thread.Sleep(250);
                    CANDataUpdateDelegate listDelegate = new CANDataUpdateDelegate(CANDataUpdate);
                    CAN_richBox.Invoke(listDelegate);
                }

            }
        }
        void CANDataUpdate()
        {
            if (!vcom.IsOpen)
            {
                buttonFresh.Enabled = true;
                openButton.BackColor = SystemColors.Control; //恢复颜色
                openButton.UseVisualStyleBackColor = true;


                comFlag = false;

                //清空canFIFO
                if (canRxFIFO.DataCount > 0)
                {
                    canRxFIFO.Clear(canRxFIFO.DataCount);
                }
                //清空链接状态显示
                
            }
            else
            {
                //500ms 发送一次心跳
                SendHeartTickPackage(vcom);

               
            }
            
            if (_canDataToDisp.Length != 0)
            {
                lock (_canDataToDisp)
                {
                    n++;
                    if (n == 10000)
                    {
                        CAN_richBox.Text = "0";
                        n = 0;
                    }
                    CAN_richBox.Text += _canDataToDisp;
                    
                    _canDataToDisp = new StringBuilder();
                    CAN_richBox.SelectionStart = CAN_richBox.Text.Length;
                    //CAN_richBox.SelectionLength = 0;
                    //CAN_richBox.ScrollToCaret();
                }
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
                nCount_Tx = 0;
                nCount_Rx = 0;
                lastCount_Tx = 0;
                lastCount_Rx = 0;
           
                uCount_Tx = 0;
                uCount_Rx = 0;
                lastuCount_Tx = 0;
                lastuCount_Rx = 0;
           
        }

        //8输入满两个字节自动后移

        private void canData_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).SelectionLength > 0) return;  //  有选中的字符

            //HEX字符串判断是否包含中文
            if (IsIncludeChinese(((TextBox)sender).Text))
            {
                if (((TextBox)sender).Text.Length >= 1)
                {
                    string str = ((TextBox)sender).Text;
                    str = str.Substring(0, str.Length - 1);
                    ((TextBox)sender).Text = str;
                }
                MessageBox.Show("HEX输入不合法，包含中文，请更改！", "错误提示"); //单位毫秒
                return;
            }

            //HEX字符串判断是否合法
            if (IsIllegalHexadecimal(((TextBox)sender).Text))
            {
                if (((TextBox)sender).Text.Length >= 1)
                {
                    string str = ((TextBox)sender).Text;
                    str = str.Substring(0, str.Length - 1);
                    ((TextBox)sender).Text = str;
                }

                MessageBox.Show("HEX输入不合法，包含非hex 字母 请更改！", "错误提示");
                return;
            }
            if (((TextBox)sender).Text.Length >= 2) //输入超过2个字符
            {
                if ((TextBox)sender != canData8) //输入到最后一个停留 不做处理
                {
                    SelectNextControl((Control)sender, true, true, true, true); //后移
                    ((TextBox)ActiveControl).SelectAll();
                }
                else
                    return;

            }
            if (((TextBox)sender).Text.Length == 0) //删除还剩最后一个字符
            {
                if ((TextBox)sender != canData1) //删除到第一个停留 不做处理
                {
                    //if(Select((TextBox)sender )).Text.Length > 0)
                    SelectNextControl((Control)sender, false, true, true, true); //前移
                    ((TextBox)ActiveControl).SelectAll();
                }
                else
                    return;

            }
        }

        //判断字符串是否包含中文
        public bool IsIncludeChinese(string str)
        {
            Regex regex = new Regex("[\u4e00-\u9fa5]");
            Match m = regex.Match(str);
            return m.Success;
        }
        public const string PATTERN = @"([^A-Fa-f0-9]|\s+?)+";
        /// <summary>
        /// 判断十六进制字符串hex是否正确
        /// </summary>
        /// <param name="hex">十六进制字符串</param>
        /// <returns>true：不正确，false：正确</returns>
        public bool IsIllegalHexadecimal(string hex)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(hex, PATTERN);
        }

        void SendHeartTickPackage(SerialPort com)
        {
            if (com.IsOpen)
            {
                byte[] buf = new byte[] { 0x55, 0x04, 0xAA, 0x55 };
                try
                {
                    com.Write(buf, 0, 4);
                }  
                catch
                {
                    ;
                }
            }
        }
        void FreamStatistics()
        {
            while (true)
            {
                Thread.Sleep(200);
                if (vcom.IsOpen && _formclosing)
                {
                    freamStatisticsDelegate statisticsDelegate = new freamStatisticsDelegate(FreamStatisticsHandle);
                
                }
                if (!vcom.IsOpen)
                {
                    //freamStatisticsDelegate pressBarUpdate = new freamStatisticsDelegate(PressBarUpdate);
                    //防止在窗口句柄初始化之前就走到下面的代码
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    

                }

            }
        }
        void FreamStatisticsHandle()
        {
           
          
            UInt16 _busspeed = (UInt16)(((nCount_Tx - lastCount_Tx + nCount_Rx - lastCount_Rx)*5* canCountOffset) / 85000);
            if (_busspeed > 100) //防止溢出
                _busspeed = 100;
      
            lastCount_Tx  = nCount_Tx;
            lastCount_Rx  = nCount_Rx;


            _down = (int)((uCount_Tx - lastuCount_Tx) * com_bit * 5);  //限幅 //250ms
            if (_down >= com_bps)
                _down = com_bps;

            _up = (int)((uCount_Rx - lastuCount_Rx) * com_bit * 5);  //限幅
            if (_up >= com_bps)
                _up = com_bps;
            if (com_bps != 0)
            {
               
                _busRXspeed = (Int16)(((uCount_Rx - lastuCount_Rx)) * 500 * com_bit / com_bps);
                if (_busRXspeed >= 100)
                    _busRXspeed = 100;
                _busTXspeed = (Int16)(((uCount_Tx - lastuCount_Tx)) * 500 * com_bit / com_bps);
                if (_busTXspeed >= 100)
                    _busTXspeed = 100;

                lastuCount_Rx = uCount_Rx;
                lastuCount_Tx = uCount_Tx;
            }

        }
      
        private void canBaudRateButton_Click(object sender, EventArgs e)
        {
            if (vcom.IsOpen)
            {
                byte[] buf = new byte[] { 0x55, 0x05,0x00, 0xAA, 0x55 };  // 设置CAN ID  0x05 CMD  参数 baudrateIndex
                buf[2] = (byte)canBaudrateComBox.Items.IndexOf(canBaudrateComBox.Text);
                vcom.Write(buf, 0, 5);
                Thread.Sleep(200);  //睡眠 等待下位机反馈
                /*
                if (baudrateSetState)
                {
                    MessageBox.Show("CAN波特率" + canBaudrateComBox.Text.ToString() + "Kbps 设置成功！", "波特率设置");
                    canCountOffset = 1000000 / long.Parse(canBaudrateComBox.Text.ToString());
                }
                else
                    MessageBox.Show("CAN波特率" + canBaudrateComBox.Text.ToString() + "Kbps 设置失败！", "波特率设置");
                */

            }
            else
            {
                MessageBox.Show("设备未连接！", "Error");
            }
        }

        private void buttonFresh_Click(object sender, EventArgs e)
        {
            comboBoxPort.Items.Clear();
            string[] ports = SerialPort.GetPortNames();//获取可用串口
            string[] unique = ports.Distinct().ToArray(); //删除重复项
            if (unique.Length > 0)//ports.Length > 0说明有串口可用
            {
                comboBoxPort.Items.AddRange(unique);
                comboBoxPort.SelectedIndex = 0;//默认选第1个串口
            }
            else//未检测到串口
            {
                MessageBox.Show("无可用串口");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!vcom.IsOpen)
            {
                MessageBox.Show("请先打开设备！", "提示");
                return;
            }

            string strSend = TX_box.Text;//发送框数据

            if (HEXSend.Checked == true)//16进制数据格式 HXE 发送
            {

                string strHEXSend = strSend; //拷贝

                strHEXSend = strHEXSend.Replace(" ", "");//去掉空格
                strHEXSend = strHEXSend.Replace("0x", "");//去掉）0x
                strHEXSend = strHEXSend.Replace("0X", "");//去掉）0X

                //HEX字符串判断是否包含中文
                if (IsIncludeChinese(strHEXSend))
                {
                    MessageBox.Show("HEX输入不合法，包含中文，请更改！", "错误提示"); //单位毫秒
                    return;
                }

                //HEX字符串判断是否合法
                if (IsIllegalHexadecimal(strHEXSend))
                {
                    MessageBox.Show("HEX输入不合法，包含非hex 字母 请更改！", "错误提示");
                    return;
                }

                byte[] newMsg = HexToByte(strSend);
                uCount_Tx += newMsg.Length;

                //label_TX.Text = nCount_Tx.ToString();
                try
                {
                    if (vcom.IsOpen)
                        vcom.Write(newMsg, 0, newMsg.Length);//发送一行数据 
                }
                catch
                {

                }
            }
            else
            {
                //以字符串 ASCII 发送
                byte[] buffer1 = System.Text.Encoding.Default.GetBytes(TX_box.Text);
                uCount_Tx += buffer1.Length;
                string strBuffer = System.Text.Encoding.Default.GetString(buffer1, 0, buffer1.Length);
                vcom.Write(strBuffer);
                //更新发送计数

                //label_TX.Text = nCount_Tx.ToString();
            }
            //显示发送内容
            //重新设置 绿色 加粗显示发送内容
            Font oldFont, newFont;

            lock (textBox_receive)
            {
                textBox_receive.AppendText(Environment.NewLine);
                oldFont = textBox_receive.SelectionFont;
                newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
                textBox_receive.SelectionFont = newFont;
                textBox_receive.Focus();
                textBox_receive.SelectionColor = Color.Green;
                strSend = "->> " + strSend + Environment.NewLine;
                textBox_receive.AppendText(strSend);
                textBox_receive.ScrollToCaret();
                //恢复默认字体
                textBox_receive.SelectionColor = Color.Black;
                textBox_receive.SelectionFont = oldFont;
                textBox_receive.Focus();
            }
        }
        private byte[] HexToByte(string msg)
        {

            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            if ((msg.Length % 2) == 1)//补零
            {

                msg = '0' + msg;
            }
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }

        private void dmBotAcToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {

        }

        private void CheckBit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openButton.Enabled = true;
            button2.Enabled = false;
            button2.ForeColor = Color.White;
            vcom.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button15.Enabled = false;
            button16.Enabled = true;
            canbox();
            textBox1.Text += "全部电机已使能\n";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.Enabled = false;
            button15.Enabled = true;
            cantbox();
        
            textBox1.Text += "全部电机已失能\n";
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            button19.Enabled = false;
            button20.Enabled = true;
            disabledbutton();
            getpicture();
            textBox1.Text += "开启自动控制\n";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            {
                button20.Enabled = false;
                button19.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button27.Enabled = true;
                button28.Enabled = true;
                button29.Enabled = true;
            }
            textBox1.Text += "开启手动控制";
        }

        private void CAN_richBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void frameId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (speedweight>=5)
            {
                speedweight = 5;
            }
            else speedweight ++;
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (speedweight<=0.3)
            {
                speedweight = 0.3f;
            }
            else speedweight -=0.15f;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            speedweight = 1.0f;

        }
        
        private void button24_Click(object sender, EventArgs e)
        {
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FC",
                            "103",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

       
        private void button33_Click(object sender, EventArgs e)
        {
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FE",
                            "001",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "00" + "00" + "00" + "00" + "00" + "00" + "C0" + "3F",
                            "101",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            tocan.SendToCan(vcom,
                            "00" + "00" + "80" + "BF" + "00" + "00" + "C0" + "3F",
                            "103",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "00" + "00" + "00" + "00" + "00" + "00" + "C0" + "3F",
                            "103",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            tocan.SendToCan(vcom,
                            "00" + "00" + "80" + "BF" + "00" + "00" + "C0" + "3F",
                            "101",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button36_Click(object sender, EventArgs e)
        {
           
            v_des = 0.8f;
            xnow=0;
            ynow = 0;
            znow = -400;
            
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            yawnow = 0;
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "00" + "00" + "40" + "BF" + "00" + "00" + "C0" + "3F",
                            "101",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            tocan.SendToCan(vcom,
                            "00" + "00" + "40" + "BF" + "00" + "00" + "C0" + "3F",
                            "103",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
            tocan.SendToCan(vcom,
                           "00" + "00" + "40" + "BF" + "00" + "00" + "C0" + "3F",
                           "105",
                           sendTimes.Text,
                           sendInterval.Text,
                           (Byte)frameType.Items.IndexOf(frameType.Text),
                           (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                           _idacc,
                           _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button29_Click(object sender, EventArgs e)
        {
            yawnow = 0;
            inverse0(xnow, ynow, znow, ynow);
            cantrans(Coordinate.senta1,Coordinate.senta2,Coordinate.senta3,Coordinate.senta4);
        }

        private void button30_Click(object sender, EventArgs e)
        {
           

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void label25_Click(object sender, EventArgs e)
        {
            label25.Text = Coordinate.senta1.ToString();
        }

        public void label36_Click(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
            {
                IntPtr Image;
                if (MvApi.CameraGrabber_SaveImage(m_Grabber, out Image, 2000) == CameraSdkStatus.CAMERA_STATUS_SUCCESS)
                {
                    string filename = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory.ToString(),
                        string.Format("{0}.bmp", System.Environment.TickCount));

                    MvApi.CameraImage_SaveAsBmp(Image, filename);

                    MvApi.CameraImage_Destroy(Image);

                    MessageBox.Show(filename);
                    imgpath = filename;
                    textBox1.Text += imgpath;
                }
                else
                {
                    MessageBox.Show("Snap failed");
                }
            }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            InitCamera();
            textBox1.Text += "已初始化相机\n";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraShowSettingPage(m_hCamera, 1);
        }

       

        private void button32_Click(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StopLive(m_Grabber);
            textBox1.Text += "已关闭相机\n";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
                MvApi.CameraGrabber_StartLive(m_Grabber);
           // MvApi.CameraPlay(m_hCamera);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_Grabber != IntPtr.Zero)
            {
                tSdkGrabberStat stat;
                MvApi.CameraGrabber_GetStat(m_Grabber, out stat);
                string info = String.Format("| Resolution:{0}*{1} | DispFPS:{2:0.0} | CapFPS:{3:0.0} |",
                    stat.Width, stat.Height, stat.DispFps, stat.CapFps);
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {
            label33.Text = Coordinate.senta2.ToString();
        }

        private void label34_Click(object sender, EventArgs e)
        {
            label34.Text = Coordinate.senta3.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            znow -= p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xnow -= speedweight*p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ynow -= speedweight*p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ynow += speedweight*p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            moveconf0 = false;
            moveconf1 = false;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (moveconf1 == true && moveconf0 == true)
            {
                inverse(xStart, yStart, zStart);
                cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            }
            else MessageBox.Show("未设置完全起始/终点");
        }
        public void button13_Click(object sender, EventArgs e)
        {
            xEnd = xnow;
            yEnd = ynow;
            zEnd = znow;
            yawEnd = ynow;
            moveconf0 = true;
            textBox1.Text += "已保存终点\n";

        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            this.CAN_richBox.Clear(); //只移除所有的项
            tocan.FlushMemory(); //回收内存
            listViewIndex = 0;
            //清空统计信息
            nCount_Tx = 0;
            nCount_Rx = 0;
            lastCount_Tx = 0;
            lastCount_Rx = 0;

        }

        private void button33_Click_2(object sender, EventArgs e)
        {
            if (this.CAN_richBox.Text == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string FileName = saveFileDialog.FileName;

            if (FileName.Length > 0)
            {

                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, true);

                streamWriter.WriteLine("序号  " + "  ID  " + "  帧格式  " + "  帧类型  " + "  状态  " + "数据长度" + "   数据    " + Environment.NewLine);   //存储表头
                streamWriter.Write(this.CAN_richBox.Text);
                streamWriter.Write(Environment.NewLine);  //插入换行符
                streamWriter.Close();
                MessageBox.Show("文件已成功保存");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button38_Click_1(object sender, EventArgs e)
        {
            canbox();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            yawnow += 0.1f;
            inverse0(xnow, ynow, znow, yawnow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            yawnow -= 0.1f;
            inverse0(xnow, ynow, znow, yawnow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void button33_Click_1(object sender, EventArgs e)
        {

            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FD",
                            "101",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button38_Click(object sender, EventArgs e)
        {

            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FD",
                            "103",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button39_Click(object sender, EventArgs e)
        {

            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FD",
                            "105",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button40_Click(object sender, EventArgs e)
        {

            Byte _idacc = 0, _dataacc = 0;

            if (IdAccCheckBox.Checked)
            {
                _idacc = 1;
            }
            if (DataAccCheckBox.Checked)
            {
                _dataacc = 1;
            }

            tocan.SendToCan(vcom,
                            "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FF" + "FD",
                            "107",
                            sendTimes.Text,
                            sendInterval.Text,
                            (Byte)frameType.Items.IndexOf(frameType.Text),
                            (Byte)frameFormat.Items.IndexOf(frameFormat.Text),
                            _idacc,
                            _dataacc);//frameType.Items.IndexOf(frameType.Text), frameFormat.Items.IndexOf(frameFormat.Text)
        }

        private void button12_Click(object sender, EventArgs e)
        {
            xStart = xnow;
            yStart = ynow;
            zStart = znow;
            yawStart = yawnow;
            moveconf0 = true;
            textBox1.Text += "已保存始点\n";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            znow += p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            label35.Text = Coordinate.senta4.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xnow += speedweight*p_div;
            inverse(xnow, ynow, znow);
            cantrans(Coordinate.senta1, Coordinate.senta2, Coordinate.senta3, Coordinate.senta4);
            fresh();
        }
    }

}
