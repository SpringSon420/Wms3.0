using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WmsModel;

namespace WmsCommon
{
	/// <summary>
	/// 数据帧处理
	/// </summary>
	public class Frame
	{
		#region 属性
		/// <summary>
		/// 实例
		/// </summary>
		public static Frame Ins = new Frame();

		/// <summary>
		/// 基信息
		/// </summary>
		public IMsg FrmMsg { get; set; }


		#endregion
		#region 帧生成

		/// <summary>
		/// 胶盘入库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <returns></returns>
		public IMsg DiskInDb(string vGoodsNu, string vDiskNu)
		{
			var obj = new MsgInDb(FrmMsg);
			//命令格式：HEAD+版本 + RK +工位+ 物料编号+胶盘编号+流水号+END
			//例如： 工位=1 ;物料编号为 A12345; 胶盘编号:X1111
			// 侧发送命令帧→ HEAD+10 + RK+1+ A12345 +X1111+1102310+END 
			obj.DaType = "RK";
			obj.LotNu = obj.WorkStation.ToString() + DateTime.Now.ToString("HHmmss");
			obj.GoodsNu = string.IsNullOrEmpty(vGoodsNu) ? "NULL" : vGoodsNu?.Trim();
			obj.DiskNu = string.IsNullOrEmpty(vDiskNu) ? "NULL" : vDiskNu?.Trim();
			obj.strFrm = string.Format("HEAD+{0}+{1}+{2}+{3}+{4}+{5}+END", obj.Ver, obj.DaType, obj.WorkStation, obj.GoodsNu, obj.DiskNu, obj.LotNu);
			obj.Buffer = Encoding.Default.GetBytes(obj.strFrm);
			return obj;
		}
		/// <summary>
		/// 胶盘出库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <returns></returns>
		public IMsg DiskOutDb(string vGoodsNu, string vDiskNu)
		{
			var obj = new MsgInDb(FrmMsg);
			//三 胶盘出库
			//命令格式：HEAD + 版本 + CK + 工位 + 物料编号 + 胶盘编号 + 流水号 + END
			//例如： 工位 = 1; 物料编号为 A12345; 胶盘编号: X1111
			//侧发送命令帧→ HEAD + CK + 1 + A12345 + X1111 + 1102310 + END
			//回应成功命令帧→  HEAD + 10 + YD + 0 + X1111 + 1102310 + END
			//接收成功帧→  HEAD + 10 + YD + 0 + NULL + 1102310 + END
			//回应失败命令帧→  HEAD + 10 + YD + 1 + NULL + 1102310 + END
			//回应失败没料命令帧→  HEAD + 10 + YD + 2 + NULL + 1102310 + END
			obj.DaType = "CK";
			obj.LotNu = obj.WorkStation.ToString() + DateTime.Now.ToString("HHmmss");
			obj.GoodsNu = string.IsNullOrEmpty(vGoodsNu) ? "NULL" : vGoodsNu?.Trim();
			obj.DiskNu = string.IsNullOrEmpty(vDiskNu) ? "NULL" : vDiskNu?.Trim();
			obj.strFrm = string.Format("HEAD+{0}+{1}+{2}+{3}+{4}+{5}+END", obj.Ver, obj.DaType, obj.WorkStation, obj.GoodsNu, obj.DiskNu, obj.LotNu);
			obj.Buffer = Encoding.Default.GetBytes(obj.strFrm);
			return obj;
		}
		/// <summary>
		/// 摆盘出库
		/// </summary>
		/// <param name="vDiskType">胶盘类型(大盘1，小盘2，高小盘3)</param>
		/// <param name="vDiskCount">胶盘数量</param>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <returns>返回</returns>
		public IMsg DiskPlatingOutDb(int vDiskType, int vDiskCount, string vGoodsNu, string vDiskNu)
		{
			var obj = new MsgPlatingOutDb(FrmMsg);
			// 1）摆盘出库
			//命令格式：HEAD+版本+BC+工位+盘类型+盘数量+物料编号+胶盘编号+流水号+END
			//例如： 工位 = 1; 盘类型(大盘，小盘，高小盘)→1，2,3；盘数量→ 1或N；物料编号为 A12345; 胶盘编号: X1111
			//	则发送命令帧→ HEAD + 10 + BC +1+ 1 + 1 + A12345 + X1111 + 1102310 + END
			//	成功命令帧→  HEAD + 10 + YD + 0 + 1102310 + X1111 + END
			//	接收成功帧→  HEAD + 10 + YD + 0 + 1102310 + NULL + END
			//	失败命令帧→  HEAD + 10 + YD + 1 + 1102310 + NULL + END
			obj.DaType = "BC";
			obj.DiskType = vDiskCount;
			obj.LotNu = obj.WorkStation.ToString() + DateTime.Now.ToString("HHmmss");
			obj.GoodsNu = string.IsNullOrEmpty(vGoodsNu) ? "NULL" : vGoodsNu?.Trim();
			obj.DiskNu = string.IsNullOrEmpty(vDiskNu) ? "NULL" : vDiskNu?.Trim();
			obj.strFrm = string.Format("HEAD+{0}+{1}+{2}+{3}+{4}+{5}+{6}+{7}+END", obj.Ver, obj.DaType, obj.WorkStation, obj.DiskType, obj.DiskCount, obj.GoodsNu, obj.DiskNu, obj.LotNu);
			obj.Buffer = Encoding.Default.GetBytes(obj.strFrm);
			return obj;
		}

		/// <summary>
		/// 摆盘入库
		/// </summary>
		/// <param name="vGoodsNu">物料编号</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <returns></returns>
		public IMsg MsgPlatingInDb(string vGoodsNu, string vDiskNu)
		{
			var obj = new MsgPlatingInDb(FrmMsg);
			//命令格式：HEAD+版本 + BR +工位+ 物料编号+胶盘编号+流水号+END
			//例如： 工位=1 ;物料编号为 A12345; 胶盘编号:X1111
			// 侧发送命令帧→ HEAD+10 + RK+1+ A12345 +X1111+1102310+END 
			obj.DaType = "BR";
			obj.LotNu = obj.WorkStation.ToString() + DateTime.Now.ToString("HHmmss");
			obj.GoodsNu = string.IsNullOrEmpty(vGoodsNu) ? "NULL" : vGoodsNu?.Trim();
			obj.DiskNu = string.IsNullOrEmpty(vDiskNu) ? "NULL" : vDiskNu?.Trim();
			obj.strFrm = string.Format("HEAD+{0}+{1}+{2}+{3}+{4}+{5}+END", obj.Ver, obj.DaType, obj.WorkStation, obj.GoodsNu, obj.DiskNu, obj.LotNu);
			obj.Buffer = Encoding.Default.GetBytes(obj.strFrm);
			return obj;
		}
		/// <summary>
		/// 命令应答
		/// </summary>
		/// <param name="vResCode">结果编码(成功0，失败1，没料2,操作完成3)</param>
		/// <param name="vDiskNu">胶盘编号</param>
		/// <param name="vLotNu">接收命令帧的流水号</param>
		/// <returns></returns>
		public IMsg MsgBack(MsgEnu vResCode, string vDiskNu, string vLotNu)
		{
			var obj = new MsgBack(FrmMsg);
			obj.DaType = "YD";
			if (string.IsNullOrEmpty(vLotNu)) return obj;
			// 二   回应命令帧格式：HEAD + 版本 + YD + 操作结果编码 + 胶盘编号 + 流水号 + END
			//成功命令帧→  HEAD + 10 + HY + 0 + X1111 + 1102310 + END
			//失败命令帧→  HEAD + 10 + HY + 1 + NULL + 1102310 + END
			obj.RetCode = vResCode;
			vDiskNu = string.IsNullOrEmpty(vDiskNu) ? "NULL" : vDiskNu?.Trim();
			obj.strFrm = string.Format("HEAD+{0}+{1}+{2}+{3}+{4}+END", obj.Ver, obj.DaType, (int)obj.RetCode, vDiskNu, vLotNu);
			obj.Buffer = Encoding.Default.GetBytes(obj.strFrm);
			return obj;
		}
		#endregion

		/// <summary>
		/// 帧解析
		/// </summary>
		/// <param name="vFrm">帧数组</param>
		/// <param name="vIP">远程IP</param>
		/// <param name="vPort">远程端口</param>
		/// <returns>返回</returns>
		public IMsg FrmAnaly(byte[] vFrm, string vIP = "0.0.0.0", int vPort = 0)
		{
			if (vFrm == null || vFrm.Length <= 0)
				return new MsgError(MsgEnu.RecvNull);

			string recv = Encoding.Default.GetString(vFrm);
			string[] split = recv.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);

			if (split == null || split.Length < MsgConst.cMinLen)
				return new MsgError(MsgEnu.StringNull);
			int last = split.Length - 1;
			if (split[0] != MsgConst.cHead || split[last] != MsgConst.cEnd)
				return new MsgError(MsgEnu.ErrHeadEnd);
			if (split[1] != MsgConst.cVersion)
				return new MsgError(MsgEnu.VerErr);

			var msgInfo = FrmMsg;
			if (vPort > 0)
				msgInfo = new MsgBase(FrmMsg, vIP, vPort);

			switch (split[2])
			{
				case "RK":
					{
						//命令格式：HEAD+版本 + RK +工位+ 物料编号+胶盘编号+流水号+END
						if (split.Length < 8)
							return new MsgError(MsgEnu.ErrRKLen);
						var msg = new MsgInDb(msgInfo);
						msg.strFrm = recv;
						int tmp = 0;
						bool flag = int.TryParse(split[3], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrWorkStation);
						msg.WorkStation = tmp;

						msg.GoodsNu = split[4] != "NULL" ? split[4] : string.Empty;
						msg.DiskNu = split[5] != "NULL" ? split[5] : string.Empty;
						msg.LotNu = split[6] != "NULL" ? split[6] : string.Empty;
						return msg;
					}
				case "CK":
					{
						//命令格式：HEAD+版本 + CK +工位+ 物料编号+胶盘编号+流水号+END
						if (split.Length < 8)
							return new MsgError(MsgEnu.ErrCKLen);
						var msg = new MsgOutDb(msgInfo);
						msg.strFrm = recv;

						int tmp = 0;
						bool flag = int.TryParse(split[3], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrWorkStation);
						msg.WorkStation = tmp;

						msg.GoodsNu = split[4] != "NULL" ? split[4] : string.Empty;
						msg.DiskNu = split[5] != "NULL" ? split[5] : string.Empty;
						msg.LotNu = split[6] != "NULL" ? split[6] : string.Empty;
						return msg;
					}
				case "YD":
					{
						//回应命令帧格式：HEAD+ 版本 + YD+ 操作编码+胶盘编号+流水号+END
						if (split.Length < 7)
							return new MsgError(MsgEnu.ErrYDLen);
						var msg = new MsgBack(msgInfo);
						msg.strFrm = recv;

						int tmp = 0;
						bool flag = int.TryParse(split[3], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrOpCode);
						msg.RetCode = (MsgEnu)tmp;

						msg.DiskNu = split[4] != "NULL" ? split[5] : string.Empty;
						msg.LotNu = split[5];
						return msg;
					}
				case "BC":
					{
						//1）摆盘出库
						//命令格式：HEAD +版本+ BC +工位+盘类型+盘数量
						//+ 物料编号+胶盘编号+流水号+END
						var msg = new MsgPlatingOutDb(msgInfo);
						msg.strFrm = recv;
						if (split.Length < 10) return msg.SetResVal(MsgEnu.ErrBCLen);

						int tmp = 0;
						bool flag = int.TryParse(split[3], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrWorkStation);
						msg.WorkStation = tmp;

						flag = int.TryParse(split[4], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrDiskTypeNo);
						msg.DiskType = tmp;


						flag = int.TryParse(split[5], out tmp);
						if (!flag) return msg.SetResVal(MsgEnu.ErrWorkStation);
						if (tmp < 0) return msg.SetResVal(MsgEnu.ErrDiskCountLeZero);
						msg.DiskCount = tmp;

						msg.GoodsNu = split[6] != "NULL" ? split[6] : string.Empty;
						msg.DiskNu = split[7] != "NULL" ? split[7] : string.Empty;
						msg.LotNu = split[8] != "NULL" ? split[8] : string.Empty;
						return msg;
					}
				case "BR":
					{
						//2）摆盘入库
						//命令格式：HEAD + 版本 + BR + 工位 + 物料编号 + 胶盘编号 + 流水号 + END
						if (split.Length < 8)
							return new MsgError(MsgEnu.ErrBRLen);
						var msg = new MsgPlatingInDb(msgInfo);
						msg.strFrm = recv;

						int tmp = 0;
						bool flag = int.TryParse(split[3], out tmp);
						if (!flag) msg.SetResVal(MsgEnu.ErrWorkStation);
						msg.WorkStation = tmp;

						msg.GoodsNu = split[4] != "NULL" ? split[4] : string.Empty;
						msg.DiskNu = split[5] != "NULL" ? split[5] : string.Empty;
						msg.LotNu = split[6] != "NULL" ? split[6] : string.Empty;
						return msg;
					}
			}
			return new MsgError(MsgEnu.ErrCmdNo);
		}
	}
	#region 客户端与服务端通讯协议

	//客户端与服务端通讯协议


	//为便于硬件PLC的有序通讯，定义客户端和服务端直接的信息交互协议,定义如下协议
	//制定时间：2018-8-30 
	//制定人： 
	//协议版本：10
	//编码格式：默认

	//说明

	//流水号的生成规则：
	//  流水号= 工位+ 时+分+秒;
	//  例如1号工位10点23分10秒 流水号是 1102310. 
	//空串：NULL.
	//协议版本(1.0):当协议的客户端与服务端不一致时，提示版本不一致且停止执行命令

	// 操作编码：
	//			0)成功
	//			1）失败
	//			2）没料（出库时没有物料或错误的物料编号）

	//一 胶盘入库
	//   命令格式：HEAD+版本 + RK +工位+ 物料编号+胶盘编号+流水号+END

	//例如： 工位=1 ;物料编号为 A12345;胶盘编号:X1111 
	//侧发送命令帧→ HEAD+10 + RK+1+ A12345 +X1111+1102310+END

	//二   回应命令帧格式：HEAD+ 版本 + YD+ 操作编码+胶盘编号+流水号+END

	//	成功命令帧→  HEAD+10 + YD+ 0+X1111+1102310+END
	//	失败命令帧→  HEAD+10 + YD+ 1+NULL+1102310+END 

	//三 胶盘出库
	//命令格式：HEAD+版本 + CK +工位+ 物料编号+胶盘编号+流水号+END

	//例如： 工位=1 ;物料编号为 A12345;胶盘编号:X1111 
	//	侧发送命令帧→ HEAD + CK+1+  A12345 +X1111+1102310+END

	//    回应成功命令帧→  HEAD+10 + YD+ 0+X1111+1102310+END
	//	接收成功帧→  HEAD +10 + YD+ 0+NULL+1102310+END
	//    回应失败命令帧→  HEAD+10 + YD+ 1+NULL+1102310+END
	//    回应失败没料命令帧→  HEAD+10 + YD+ 2+NULL+1102310+END 

	//三 摆盘
	//  1）摆盘出库
	//  命令格式：HEAD +版本+ BC +工位+盘类型+盘数量+ 物料编号+胶盘编号+流水号+END	

	//例如： 工位=1 ;盘类型(大盘，小盘，高小盘)→1，2,3；盘数量→ 1或N；物料编号为 A12345;胶盘编号:X1111 
	//则发送命令帧→ HEAD+10 + BC+1+1+1+  A12345 +X1111+1102310+END

	//	成功命令帧→  HEAD+10 + YD+ 0+1102310+X1111+END
	//	接收成功帧→  HEAD +10 + YD+ 0+1102310+NULL+END
	//	失败命令帧→  HEAD +10+ YD+ 1+1102310+NULL +END 

	//2）摆盘入库
	//  命令格式：HEAD+版本 + BR +工位+ 物料编号+胶盘编号+流水号+END

	//例如： 工位=1 ;物料编号为 A12345;胶盘编号:X1111 
	//则发送命令帧→ HEAD+10  + BC+1+  A12345 +X1111+1102310+END

	//	成功命令帧→  HEAD +10 + YD+ 0+X1111+1102310+END
	//	接收成功帧→  HEAD +10 + YD+ 0+NULL+1102310+END
	//	失败命令帧→  HEAD +10 + YD+ 1+NULL+1102310+END 
	#endregion
}
