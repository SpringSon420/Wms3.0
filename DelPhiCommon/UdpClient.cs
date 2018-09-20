using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using WmsModel;
using System.Drawing;

namespace WmsCommon
{
	/// <summary>
	/// UDP通讯Client端
	/// </summary>
	public class UdpClient
	{
		#region 属性

		/// <summary>
		/// 实例
		/// </summary>
		public static UdpClient Ins;

		private MyInvoke mi;

		/// <summary>
		/// 本地Msg
		/// </summary>
		public IMsg LocMsg { get; set; }

		/// <summary>
		/// 通讯后修改界面信息
		/// </summary>
		public event Action<IMsg> E_ModForm;

		/// <summary>
		/// Server端在綫信息
		/// </summary>
		public event Action<string,Color> E_ServerOnLine;

		private object g_m;
		private bool loginOK;
		internal IPEndPoint remoteEP;
		internal System.Net.Sockets.UdpClient udpSend;
		private UdpState udpSendState;
		private UdpState udpReceiveState;
		private AsyncCallback readCallback;
		private AsyncCallback receiveCallback;
		private CancellationTokenSource cts = new CancellationTokenSource();
		private bool invokerAgvFirst = true;
		private Action offlineAgvInvoker;//MethodInvoker
		internal static bool connectSuccess;
		internal static bool writeBug = false;
		internal static int serverTimeout;
		private int localPort;
		private bool bUpdateFirst = true;

		public delegate void MyInvoke(byte[] plcValue);

		#endregion
		#region 方法

		/// <summary>
		/// 初始化 
		/// </summary>
		/// <param name="strLocalIP">本地IP</param>
		/// <param name="localPort">本地端口</param>
		/// <param name="remoteIP">服务器IP</param>
		/// <param name="remotePort">服务器端口</param>
		/// <param name="vModForm">接收数据修改显示事件</param>
		/// <param name="vServerOnLine">修改服务器在线或否的事件</param>
		public UdpClient(string strLocalIP, int localPort,
			string remoteIP, int remotePort, int vWorkStation,
			Action<IMsg> vModForm,
			Action<string, Color> vServerOnLine
			)
		{
			if (Ins != null) throw new Exception("对象已经存在");
			//g_m = em;
			//FrmMain frmMain = g_m as FrmMain;
			E_ModForm = vModForm;
			E_ServerOnLine = vServerOnLine;
			LocMsg = new MsgBase()
			{
				DaType = "BS",
				LocalIP = strLocalIP,
				LocalPort = localPort,
				RemoteIP = remoteIP,
				RemotePort = remotePort,
				WorkStation = vWorkStation
			};
			Frame.Ins.FrmMsg = LocMsg;

			this.localPort = localPort;
			remoteEP = new IPEndPoint(IPAddress.Parse(remoteIP), remotePort);
			lock (this)
			{
				try
				{
					udpSend = new System.Net.Sockets.UdpClient(localPort);
				}
				catch (Exception ex)
				{
					throw ex;
					//MessageBox.Show("本地端口" + localPort.ToString() + "已被占用！", "提示", MessageBoxButtons.OK);
					//if (frmMain.IsHandleCreated)
					//{
					//    Environment.Exit(0);
					//}
					//return;
				}
			}
			udpSendState = new UdpState
			{
				ipEndPoint = remoteEP,
				udpClient = udpSend
			};
			udpReceiveState = new UdpState
			{
				ipEndPoint = remoteEP,
				udpClient = udpSend
			};
			readCallback = new AsyncCallback(SendCallback);
			receiveCallback = new AsyncCallback(ReceiveCallback);
		}

		/// <summary>
		/// UDP接收回调函数
		/// </summary>
		/// <param name="iar">异步状态</param>
		internal void ReceiveCallback(IAsyncResult iar)
		{
			UdpState asyncState = iar.AsyncState as UdpState;
			if (iar.IsCompleted)
			{
				byte[] buffer = asyncState.udpClient.EndReceive(iar, ref udpReceiveState.ipEndPoint);
				#region DEBUG 移到form
				//FrmMain frmMain = g_m as FrmMain;
				//mi = new MyInvoke(UpdateForm);
				//if (buffer.Length >= 10)
				//{
				//    if (bUpdateFirst)
				//    {
				//        mi = new MyInvoke(UpdateForm);
				//        bUpdateFirst = false;
				//    }
				//    if (frmMain.frmLoginTemp != null)
				//    {
				//        if (frmMain.frmLoginTemp.IsHandleCreated)
				//        {
				//            frmMain.frmLoginTemp.BeginInvoke(mi, new object[] { buffer });
				//            serverTimeout = 0;
				//        }
				//    }
				//    else
				//    {
				//        if (frmMain.IsHandleCreated)
				//        {
				//            frmMain.BeginInvoke(mi, new object[] { buffer });
				//            serverTimeout = 0;

				//        }
				//    }
				//} 
				#endregion
				IMsg obj = Frame.Ins.FrmAnaly(buffer);
				E_ModForm?.Invoke(obj);

			}
		}

		/// <summary>
		/// UDP发送回调函数
		/// </summary>
		/// <param name="ar">异步状态</param>
		internal void SendCallback(IAsyncResult ar)
		{
			UdpState asyncState = ar.AsyncState as UdpState;
			if (ar.IsCompleted)
			{
				asyncState.udpClient.EndSend(ar);
				if (serverTimeout > 5)
				{
					//MethodInvoker invoker = null;
					serverTimeout = 6;
					//FrmMain frmMain = g_m as FrmMain;
					//if (frmMain.frmLoginTemp != null)
					//{
					//    MessageBox.Show("连接失败SendCallback" + remoteEP.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					//}
					//if (string.IsNullOrEmpty(GblMod.Ins.LoginPerson.UserName)) return;
					E_ServerOnLine?.Invoke("服务器掉线", Color.Red);
					#region DEBUG 
					//else if (frmMain.lblServerOnLine.InvokeRequired)
					//{
					//    if (invokerAgvFirst)
					//    {
					//        invokerAgvFirst = false;
					//        if (invoker == null)
					//        {
					//            invoker = delegate
					//            {
					//                frmMain.lblServerOnLine.BackColor = Color.Red;
					//                frmMain.lblServerOnLine.Text = "服务器掉线";
					//            };
					//        }
					//        offlineAgvInvoker = invoker;
					//    }
					//    else
					//    {
					//        frmMain.lblServerOnLine.Invoke(offlineAgvInvoker);
					//    }
					//}
					//else
					//{
					//    frmMain.lblServerOnLine.BackColor = Color.Red;
					//    frmMain.lblServerOnLine.Text = "服务器掉线";
					//} 
					#endregion
				}
			}
		}

		internal void UpdateForm(byte[] plcValue)
		{
			//FrmMain frmMain = g_m as FrmMain;
		//	if (string.IsNullOrEmpty(GblMod.Ins.LoginPerson.UserName)) return;

			#region DEBUG 待解析
			//if (frmMain.frmLoginTemp != null)
			//{
			//    if (loginOK)
			//    {
			//        //接收HouseData
			//        if (plcValue[7] == 3 && plcValue[8] == 1)
			//        {
			//            for (int i = 0; i < 20; i++)
			//            {
			//                SettingHelper.modelHourseArray[i] = new Hourse();
			//                SettingHelper.modelHourseArray[i].Status = plcValue.Skip<byte>(9).ElementAt<byte>(i * 13);
			//                byte[] bytesModelId = plcValue.Skip<byte>(i * 13 + 10).Take<byte>(12).ToArray<byte>();
			//                string strModelId = Encoding.Default.GetString(bytesModelId);
			//                SettingHelper.modelHourseArray[i].ModelID = strModelId;
			//            }
			//        }
			//        //HouseIdLocked
			//        if (plcValue[7] == 5 && plcValue[8] == 1)
			//        {
			//            if (plcValue[9] > 0)
			//            {
			//                for (int i = 0; i < plcValue[9] / 3; i++)
			//                {
			//                    SettingHelper.houseLocked[i] = plcValue.Skip<byte>(10).ElementAt<byte>(3 * i + 1);
			//                }
			//            }
			//            frmMain.frmLoginTemp.DialogResult = DialogResult.OK;
			//        }
			//    }
			//    //验证登录信息
			//    if (plcValue[7] == 0x81 && plcValue[8] == 1)
			//    {
			//        if (plcValue[9] == 0)
			//        {
			//            loginOK = true;
			//            try
			//            {
			//                frmMain.frmLoginTemp.heartBeat.Abort();
			//            }
			//            catch
			//            {
			//            }
			//        }
			//        if (plcValue[9] == 1)
			//        {
			//            MessageBox.Show("登录失败，该账号不存在或者密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//            return;
			//        }
			//        if (plcValue[9] == 2)
			//        {
			//            MessageBox.Show("登录失败，该账号已经在线！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			//            return;
			//        }
			//    }
			//}
			//else
			//{
			//    if (plcValue.Length >= 10)
			//    {
			//        try
			//        {
			//            //在线交互检测
			//            if (plcValue[7] == 0x85 && plcValue[8] == 1)
			//            {
			//                serverTimeout = 0;
			//            }
			//            //RobotRealData
			//            if (plcValue[7] == 2 && plcValue[8] == 2)
			//            {
			//                int robotAlertValue = plcValue[9];//故障位
			//                SettingHelper.robotMoving = plcValue[10];//堆垛机动作
			//                SettingHelper.robotSystem = plcValue[11];//堆垛机系统状态
			//                SettingHelper.robotStatus = plcValue[12];//堆垛机实时状态
			//                SettingHelper.robotLinkCon = plcValue[13];//堆垛机联机状态
			//                SettingHelper.Contrlsystem = plcValue[14];
			//                if (robotAlertValue == 0 && SettingHelper.robotLinkCon == 1)
			//                {
			//                    frmMain.lblRobotErrorDis.Text = "无故障";
			//                    frmMain.lblRobotErrorDis.BackColor = SystemColors.ActiveCaption;
			//                    frmMain.toolStripStatusRobotInfo.Text = "堆垛机在线，状态正常";
			//                    frmMain.toolStripStatusRobotInfo.BackColor = Color.FromArgb(192, 255, 192);
			//                    frmMain.toolStripStatusRobotInfo.ForeColor = Color.Black;
			//                }
			//                else
			//                {
			//                    frmMain.lblRobotErrorDis.Text = "有故障";
			//                    frmMain.lblRobotErrorDis.BackColor = Color.Red;
			//                    if (SettingHelper.robotLinkCon == 0)
			//                    {
			//                        frmMain.toolStripStatusRobotInfo.Text = "堆垛机掉线异常";
			//                    }
			//                    else
			//                    {
			//                        frmMain.toolStripStatusRobotInfo.Text = SettingHelper.robotAlertInformation[robotAlertValue - 1];
			//                    }
			//                    frmMain.toolStripStatusRobotInfo.BackColor = Color.Red;
			//                    frmMain.toolStripStatusRobotInfo.ForeColor = Color.Yellow;
			//                }

			//                if (plcValue[10] == 0)
			//                {
			//                    frmMain.lblMovingDis.Text = "待机";
			//                }
			//                else
			//                {
			//                    frmMain.lblMovingDis.Text = "执行任务";
			//                }

			//                if (SettingHelper.robotSystem == 1)
			//                {
			//                    frmMain.lblStackerSysDis.Text = "运行";
			//                    frmMain.lblStackerSysDis.BackColor = SystemColors.ActiveCaption;
			//                }
			//                else
			//                {
			//                    frmMain.lblStackerSysDis.Text = "关闭";
			//                    frmMain.lblStackerSysDis.BackColor = Color.Red;
			//                }

			//                if (SettingHelper.robotStatus == 32)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "故障";
			//                    frmMain.lblRobotStatusDis.BackColor = Color.Red;
			//                    //frmMain.lblRobotStatusDis.ForeColor = Color.White;
			//                }
			//                else
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "";
			//                    frmMain.lblRobotStatusDis.BackColor = SystemColors.ActiveCaption;
			//                    //frmMain.lblRobotStatusDis.ForeColor = Color.Black;
			//                }
			//                if (SettingHelper.robotStatus == 1)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "联机";
			//                }
			//                if (SettingHelper.robotStatus == 2)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "手动";
			//                }
			//                if (SettingHelper.robotStatus == 4)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "半自动";
			//                }
			//                if (SettingHelper.robotStatus == 8)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "工作中";
			//                }
			//                if (SettingHelper.robotStatus == 16)
			//                {
			//                    frmMain.lblRobotStatusDis.Text = "待机";
			//                }

			//                if (SettingHelper.robotLinkCon == 1)
			//                {
			//                    frmMain.lblRobotOnline.Text = "堆垛机 联机";
			//                    frmMain.lblRobotOnline.BackColor = Color.Green;

			//                }
			//                else
			//                {
			//                    frmMain.lblRobotOnline.Text = "堆垛机 脱机";
			//                    frmMain.lblRobotOnline.BackColor = Color.Red;
			//                }
			//                if (SettingHelper.Contrlsystem == 1)
			//                {
			//                    frmMain.lblConnect.Text = "在线";
			//                    frmMain.lblConnect.Visible = false;
			//                    frmMain.lblConnect.BackColor = Color.White;
			//                }
			//                else
			//                {
			//                    frmMain.lblConnect.Visible = true;
			//                    frmMain.lblConnect.BackColor = Color.Red;
			//                    frmMain.lblConnect.Text = "上位机与总控PLC连接失败";
			//                }
			//            }
			//            //AgvRealData
			//            if (plcValue[7] == 2 && plcValue[8] == 1)
			//            {
			//                SettingHelper.agvRfid = plcValue[9];
			//                SettingHelper.agvErrorInfor = plcValue[10];
			//                int agvAlertValue = plcValue[10];
			//                SettingHelper.agvStatusDis = plcValue[11];
			//                int realStatus = plcValue[11];
			//                SettingHelper.agvStatus = plcValue[12];
			//                SettingHelper.agvBattering = plcValue[13];
			//                SettingHelper.agvVolutage = plcValue[14];
			//                SettingHelper.agvLinkCon = plcValue[15];
			//                if ((agvAlertValue == 0 || agvAlertValue == 200) && SettingHelper.agvLinkCon == 1)
			//                {
			//                    frmMain.lblAgvErrDis.Text = "无故障";
			//                    frmMain.lblAgvErrDis.BackColor = SystemColors.ActiveCaption;
			//                    frmMain.toolStripStatusAgvInfo.Text = "AGV在线，状态正常";
			//                    frmMain.toolStripStatusAgvInfo.BackColor = Color.FromArgb(192, 255, 192);
			//                    frmMain.toolStripStatusAgvInfo.ForeColor = Color.Black;
			//                }
			//                else
			//                {
			//                    if (SettingHelper.agvLinkCon == 0)
			//                    {
			//                        frmMain.toolStripStatusAgvInfo.Text = "AGV 掉线异常";
			//                    }
			//                    else
			//                    {
			//                        frmMain.toolStripStatusAgvInfo.Text = SettingHelper.agvAlertInformation[agvAlertValue - 1];
			//                    }
			//                    frmMain.toolStripStatusAgvInfo.BackColor = Color.Red;
			//                    frmMain.toolStripStatusAgvInfo.ForeColor = Color.Yellow;
			//                    frmMain.lblAgvErrDis.Text = "有故障";
			//                    frmMain.lblAgvErrDis.BackColor = Color.Red;
			//                }
			//                if (SettingHelper.agvStatus == 32)
			//                {
			//                    frmMain.lblStatusDis.Text = "故障";
			//                    frmMain.lblStatusDis.BackColor = Color.Red;
			//                    frmMain.lblStatusDis.ForeColor = SystemColors.ActiveCaption;
			//                }
			//                else
			//                {
			//                    frmMain.lblStatusDis.BackColor = SystemColors.ActiveCaption;
			//                    frmMain.lblStatusDis.ForeColor = Color.Black;
			//                    if (SettingHelper.agvStatus == 1)
			//                    {
			//                        frmMain.lblStatusDis.Text = "自动";
			//                    }
			//                    else if (SettingHelper.agvStatus == 2)
			//                    {
			//                        frmMain.lblStatusDis.Text = "手动";
			//                    }
			//                    else if (SettingHelper.agvStatus == 4)
			//                    {
			//                        frmMain.lblStatusDis.Text = "半自动";
			//                    }
			//                    else if (SettingHelper.agvStatus == 8)
			//                    {
			//                        frmMain.lblStatusDis.Text = "定位中";
			//                    }
			//                    else if (SettingHelper.agvStatus == 16)
			//                    {
			//                        frmMain.lblStatusDis.Text = "待机";
			//                    }
			//                    else if (SettingHelper.agvStatus == 0)
			//                    {
			//                        frmMain.lblStatusDis.Text = "";
			//                    }
			//                }


			//                if (SettingHelper.agvLinkCon == 1)
			//                {
			//                    frmMain.lblAgvOnline.Text = "AGV 联机";
			//                    frmMain.lblAgvOnline.BackColor = Color.Green;
			//                }
			//                else
			//                {
			//                    frmMain.lblAgvOnline.Text = "AGV 脱机";
			//                    frmMain.lblAgvOnline.BackColor = Color.Red;
			//                }
			//                switch (SettingHelper.agvBattering)
			//                {
			//                    case 0:
			//                        frmMain.lblAgvChargeDis.Text = "未充电";
			//                        break;
			//                    case 1:
			//                        frmMain.lblAgvChargeDis.Text = "充电中";
			//                        break;
			//                    case 2:
			//                        frmMain.lblAgvChargeDis.Text = "充满电";
			//                        break;
			//                    default:
			//                        break;
			//                }
			//                if (SettingHelper.agvVolutage == 1)
			//                {
			//                    frmMain.lblVoltageDis.Text = "正常";
			//                }
			//                else
			//                {
			//                    frmMain.lblVoltageDis.Text = "低压";
			//                }
			//                switch (realStatus)
			//                {
			//                    case 1:
			//                        frmMain.lblAgvInfo.Text = "AGV 在原点待命";
			//                        break;
			//                    case 2:
			//                        frmMain.lblAgvInfo.Text = "AGV 调度到工位";
			//                        break;
			//                    case 3:
			//                        frmMain.lblAgvInfo.Text = "AGV 接料完成";
			//                        break;
			//                    case 4:
			//                        frmMain.lblAgvInfo.Text = "AGV 已把模具运到原点";
			//                        break;
			//                    case 5:
			//                        frmMain.lblAgvInfo.Text = "AGV 送料完成";
			//                        break;
			//                    case 6:
			//                        frmMain.lblAgvInfo.Text = "AGV 已把空栈板运到原点";
			//                        break;
			//                    default:
			//                        break;
			//                }
			//            }
			//            //HouseData
			//            if (plcValue[7] == 3 && plcValue[8] == 1)
			//            {
			//                for (int i = 0; i < 20; i++)
			//                {
			//                    Label lblhourse = frmMain.pnlWarehouse.Controls["p" + (i + 1).ToString()] as Label;
			//                    SettingHelper.modelHourseArray[i] = new Hourse
			//                    {
			//                        Status = plcValue.Skip<byte>(9).ElementAt<byte>(i * 13)
			//                    };
			//                    byte[] bytesModelId = plcValue.Skip<byte>(i * 13 + 10).Take<byte>(12).ToArray<byte>();
			//                    string strModelId = Encoding.Default.GetString(bytesModelId);
			//                    SettingHelper.modelHourseArray[i].ModelID = strModelId;

			//                    if (SettingHelper.modelHourseArray[i].Status == 0)
			//                    {
			//                        lblhourse.Image = Resources.unit_Pic;
			//                    }
			//                    if (SettingHelper.modelHourseArray[i].Status == 1)
			//                    {
			//                        lblhourse.Image = Resources.stack_pic;
			//                    }
			//                    if (SettingHelper.modelHourseArray[i].Status == 2)
			//                    {
			//                        lblhourse.Image = Resources.Mode_Pic2;
			//                    }
			//                    if ((SettingHelper.modelHourseArray[i].Status == 0) || (SettingHelper.modelHourseArray[i].Status == 1) || (SettingHelper.modelHourseArray[i].ModelID.Trim().Equals("")))
			//                    {
			//                        lblhourse.Text = Convert.ToString(i + 1);
			//                    }
			//                    else
			//                    {
			//                        lblhourse.Text = SettingHelper.modelHourseArray[i].ModelID;
			//                    }
			//                }
			//            }
			//            //HouseIdLocked
			//            if (plcValue[7] == 5 && plcValue[8] == 1)
			//            {
			//                if (plcValue[9] > 0)
			//                {
			//                    for (int i = 0; i < (plcValue[9] / 3); i++)
			//                    {
			//                        SettingHelper.houseLocked[i] = plcValue.Skip<byte>(10).ElementAt<byte>(3 * i + 1);

			//                        if (SettingHelper.houseLocked[i] > 0 && SettingHelper.houseLocked[i] < 21)
			//                        {
			//                            Label lblHouse = frmMain.pnlWarehouse.Controls["p" + SettingHelper.houseLocked[i].ToString()] as Label;
			//                            lblHouse.Enabled = false;
			//                        }
			//                    }
			//                }
			//            }
			//            //TaskStatusUpdate  
			//            if (plcValue[7] == 5 && plcValue[8] == 2)
			//            {
			//                string houseId = Convert.ToString(plcValue[11]);
			//                if (plcValue[10] == 1 || plcValue[10] == 2)
			//                {
			//                    for (int i = 0; i < SettingHelper.taskList.Count; i++)
			//                    {
			//                        if (SettingHelper.taskList[i].TaskHourseId == houseId && SettingHelper.taskList[i].TaskStatus != "已执行")
			//                        {
			//                            switch (plcValue[9])
			//                            {
			//                                case 1:
			//                                    SettingHelper.taskList[i].TaskStatus = "执行中";
			//                                    frmMain.UpdateDgvTaskList(houseId, SettingHelper.taskList[i].TaskStatus);
			//                                    frmMain.txtSetModel.Text = "";
			//                                    if (!frmMain.txtModelRfid.Text.Contains("扫码枪错误"))
			//                                    {
			//                                        frmMain.txtModelRfid.Text = "";
			//                                    }
			//                                    break;
			//                                case 2:
			//                                    SettingHelper.taskList[i].TaskStatus = "已执行";
			//                                    frmMain.UpdateDgvTaskList(houseId, SettingHelper.taskList[i].TaskStatus);
			//                                    SettingHelper.taskList.RemoveAt(i);
			//                                    break;
			//                                default:
			//                                    break;
			//                            }
			//                        }
			//                    }
			//                }
			//                if (plcValue[9] == 2)
			//                {
			//                    Label lblHouse = frmMain.pnlWarehouse.Controls["p" + houseId] as Label;
			//                    lblHouse.Enabled = true;
			//                }
			//            }
			//            //顺带模具入库，2018年1月10日17:44:31
			//            if (plcValue[7] == 5 && plcValue[8] == 3)
			//            {
			//                if (plcValue[9] == 1)
			//                {
			//                    frmMain.btnOutedIn.Enabled = true;
			//                    frmMain.btnOutedIn.BackColor = Color.Teal;
			//                    frmMain.btnOutedIn.ForeColor = Color.White;

			//                }
			//                if (plcValue[9] == 0)
			//                {
			//                    frmMain.btnOutedIn.Enabled = false;
			//                    frmMain.btnOutedIn.BackColor = Color.Silver;
			//                    frmMain.btnOutedIn.ForeColor = Color.Black;
			//                }
			//            }
			//        }
			//        catch
			//        {
			//        }
			//        frmMain.lblServerOnLine.BackColor = Color.Green;
			//        frmMain.lblServerOnLine.Text = "服务器在线";
			//    }
			//} 
			#endregion
		}

		#region 注釋
		///// <summary>
		///// UDP异步开始发送
		///// </summary>
		///// <param name="packData">数据信息</param>
		///// <param name="length">数据长度</param>
		//public void AddSendMsg(byte[] packData, int length)
		//{
		//    try
		//    {
		//        udpSend.BeginSend(packData, length, readCallback, udpSendState);
		//    }
		//    catch
		//    {
		//    }
		//} 
		#endregion
		#region UDP异步开始发送
		/// <summary>
		/// UDP异步开始发送
		/// </summary>
		/// <param name="vMsg">数据信息</param>
		public IMsg SendStart(IMsg vMsg)
		{
			try
			{
				if (vMsg.Length <= 0)
					return vMsg.SetResVal(MsgEnu.SendNull);

				udpSend.BeginSend(vMsg.Buffer, vMsg.Length, readCallback, udpSendState);
				return vMsg;
			}
			catch
			{
			}
			return new MsgError(MsgEnu.ErrSendFail);
		}
		/// <summary>
		/// 发送胶盘入库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		public IMsg SendInDb(string vGoodsNu, string vDiskNu)
		{
			var obj = Frame.Ins.DiskInDb(vGoodsNu, vDiskNu);
			if (!obj.IsSucc) return obj;
			return SendStart(obj);
		}
		/// <summary>
		/// 发送胶盘出库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		public IMsg SendOutDb(string vGoodsNu, string vDiskNu)
		{
			var obj = Frame.Ins.DiskOutDb(vGoodsNu, vDiskNu);
			if (!obj.IsSucc) return obj;
			return SendStart(obj);
		}

		/// <summary>
		/// 发送摆盘出库
		/// </summary>
		/// <param name="vDiskType">胶盘类型(大盘1，小盘2，高小盘3)</param>
		/// <param name="vDiskCount">胶盘数量</param>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		public IMsg SendPlatingOutDb(int vDiskType, int vDiskCount, string vGoodsNu, string vDiskNu)
		{
			var obj = Frame.Ins.DiskPlatingOutDb(vDiskType, vDiskCount, vGoodsNu, vDiskNu);
			if (!obj.IsSucc) return obj;
			return SendStart(obj);
		}

		/// <summary>
		/// 发送摆盘入库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		public IMsg SendPlatingInDb(string vGoodsNu, string vDiskNu)
		{
			var obj = Frame.Ins.MsgPlatingInDb(vGoodsNu, vDiskNu);
			if (!obj.IsSucc) return obj;
			return SendStart(obj);
		}

		/// <summary>
		/// 发送命令应答
		/// </summary>
		/// <param name="vResCode">结果编码(成功0，失败1，没料2)</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <param name="vLotNu">接收命令帧的流水号</param>
		public IMsg SendBack(MsgEnu vResCode, string vDiskNu, string vLotNu)
		{
			var obj = Frame.Ins.MsgBack(vResCode, vDiskNu, vLotNu);
			if (!obj.IsSucc) return obj;
			return SendStart(obj);
		}
		#endregion
		/// <summary>
		/// 启动线程
		/// </summary>
		public void SendThr()
		{
			new Thread(new ThreadStart(SendMsg)) { IsBackground = true }.Start();
		}

		public void SendMsg()
		{
			try
			{
				udpSend.Connect(remoteEP);
			}
			catch
			{
				//if (string.IsNullOrEmpty(GblMod.Ins.LoginPerson.UserName)) return;
				E_ServerOnLine?.Invoke("服务器掉线", Color.Red);
				#region DEBUG 待验
				//FrmMain frmMain = g_m as FrmMain;
				//if (frmMain.frmLoginTemp != null)
				//{
				//    MessageBox.Show("连接失败SendMsg" + remoteEP.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				//}
				//else
				//{
				//MethodInvoker invoker = null;
				//if (frmMain.lblServerOnLine.InvokeRequired)
				//{
				//    if (invokerAgvFirst)
				//    {
				//        invokerAgvFirst = false;
				//        if (invoker == null)
				//        {
				//            invoker = delegate
				//            {
				//                frmMain.lblServerOnLine.BackColor = Color.Red;
				//                frmMain.lblServerOnLine.Text = "服务器掉线";
				//            };
				//        }
				//        offlineAgvInvoker = invoker;
				//    }
				//    else
				//    {
				//        frmMain.lblServerOnLine.Invoke(offlineAgvInvoker);
				//    }
				//}
				//else
				//{
				//    frmMain.lblServerOnLine.BackColor = Color.Red;
				//    frmMain.lblServerOnLine.Text = "服务器掉线";
				//}
				// } 
				#endregion

			}
			connectSuccess = true;
			while (!cts.Token.IsCancellationRequested)
			{
				ReceiveMessages();
				Thread.Sleep(30);
			}
		}
		public void ReceiveMessages()
		{
			lock (this)
			{
				try
				{
					udpSend.BeginReceive(receiveCallback, udpReceiveState);
				}
				catch (SocketException)
				{
					//string.Format($"SocketException:{exception}");
				}
			}
		}

		/// <summary>
		/// 关闭客户端套接
		/// </summary>
		public void CloseClient()
		{
			cts.Cancel();
			Thread.Sleep(200);
			if (udpSend != null)
			{
				udpSend.Close();
			}
		}
		#region 注釋
		//public void SendReadPack()
		//{
		//    serverTimeout++;
		//    byte[] packData = new byte[11];
		//    packData[0] = 0xbf;
		//    packData[1] = 0;
		//    packData[2] = 11;
		//    packData[3] = 0x4d;
		//    packData[4] = 1;
		//    packData[5] = 0;
		//    packData[6] = 0;
		//    packData[7] = 5;
		//    packData[8] = 1;
		//    packData[9] = 1;
		//    packData[10] = 3;
		//    if (serverTimeout < 10)
		//    {
		//        AddSendMsg(packData, 11);//0x0501
		//    }
		//}  
		#endregion
		#endregion
	}
}
