using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmsModel
{
	/// <summary>
	/// 结果描述
	/// </summary>
	public enum MsgEnu
	{
		/// <summary>
		/// 成功
		/// </summary>
		Succ = 0,

		/// <summary>
		/// 失败
		/// </summary>
		Fail,

		/// <summary>
		/// 没料 
		/// </summary>
		NoMatter,

		/// <summary>
		/// 硬件设备操作成功完成
		/// </summary>
		SuccOperFinish,

		/// <summary>
		/// 接收数组为空
		/// </summary>
		RecvNull,

		/// <summary>
		/// 发送数组为空
		/// </summary>
		SendNull,
		/// <summary>
		/// 字符串数组为空或长度不足
		/// </summary>
		StringNull,

		/// <summary>
		/// 服务器与客户端版本不一致
		/// </summary>
		VerErr,

		/// <summary>
		/// 帧头或帧尾错误
		/// </summary>
		ErrHeadEnd,

		/// <summary>
		/// 入库命令数组长度不足
		/// </summary>
		ErrRKLen,

		/// <summary>
		/// 出库命令数组长度不足
		/// </summary>
		ErrCKLen,

		/// <summary>
		/// 摆盘出库命令数组长度不足
		/// </summary>
		ErrBCLen,

		/// <summary>
		/// 摆盘入库命令数组长度不足
		/// </summary>
		ErrBRLen,

		/// <summary>
		/// 回应命令数组长度不足
		/// </summary>
		ErrYDLen,

		/// <summary>
		/// 工位信息非数值
		/// </summary>
		ErrWorkStation,

		/// <summary>
		/// 命令不存在
		/// </summary>
		ErrCmdNo,

		/// <summary>
		/// 操作编码非数值
		/// </summary>
		ErrOpCode,

		/// <summary>
		/// 盘数量非数值
		/// </summary>
		ErrDiskNo,

		/// <summary>
		/// 盘类型非数值
		/// </summary>
		ErrDiskTypeNo,

		/// <summary>
		/// 盘数量不能小于零
		/// </summary>
		ErrDiskCountLeZero,
		/// <summary>
		/// 发送失败
		/// </summary>
		ErrSendFail,
	}

	/// <summary>
	/// 常量及描述的定义
	/// </summary>
	public class MsgConst
	{
		/// <summary>
		/// 1.0版本(10)
		/// </summary>
		public const string cVersion = "10";

		/// <summary>
		/// 命令数组最小长度(4)
		/// </summary>
		public const int cMinLen = 4;

		/// <summary>
		/// 帧头(HEAD)
		/// </summary>
		public const string cHead = "HEAD";

		/// <summary>
		/// 帧尾(END)
		/// </summary>
		public const string cEnd = "END";

	}
	/// <summary>
	/// UDP通讯基类
	/// </summary>
	public class MsgBase : IMsg
	{
		#region 属性
		/// <summary>
		/// 信息类型
		/// </summary>
		public string DaType { get; set; }
		/// <summary>
		/// 1.0版本(10)
		/// </summary>
		public string Ver
		{
			get { return MsgConst.cVersion; }
		}
		/// <summary>
		/// 信息内容
		/// </summary>
		public byte[] Buffer { get; set; }
		/// <summary>
		/// 信息内容长度
		/// </summary>
		public int Length
		{
			get { return Buffer != null ? Buffer.Length : 0; }
		}

		/// <summary>
		/// 远端IP
		/// </summary>
		public string RemoteIP { get; set; }

		/// <summary>
		/// 远端端口
		/// </summary>
		public int RemotePort { get; set; }

		/// <summary>
		/// 本地IP
		/// </summary>
		public string LocalIP { get; set; }

		/// <summary>
		/// 本地端口
		/// </summary>
		public int LocalPort { get; set; }

		/// <summary>
		/// 帧字符串
		/// </summary>
		public string strFrm { get; set; }


		/// <summary>
		/// 工位(1)
		/// </summary>
		public int WorkStation { get; set; }

		/// <summary>
		/// 结果值
		/// </summary>
		public MsgEnu ResVal { get; set; }

		/// <summary>
		/// 是否成功
		/// </summary>
		public bool IsSucc
		{
			get { return ResVal == MsgEnu.Succ; }
		}
		#endregion

		/// <summary>
		/// 接收结果描述(MsgDesc)
		/// </summary>
		protected string[] DescRes = new string[]
		{
			"成功",//0
			"失败",
			"没料",
			"硬件设备操作成功完成",
			"接收数组为空",
			"发送数组为空",//5
			"字符串数组为空或长度不足",
			"服务器与客户端版本不一致",
			"帧头或帧尾错误",
			"入库命令数组长度不足",
			"出库命令数组长度不足",//10
			"摆盘出库命令数组长度不足",
			"摆盘入库命令数组长度不足",
			"回应命令数组长度不足",
			"工位信息非数值",
			"命令不存在",//15
			"操作编码非数值",
			"盘数量非数值",
			"盘类型非数值",
			"盘数量不能小于零",
			"发送失败",//20
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
		};

		/// <summary>
		/// 初始化
		/// </summary>
		public MsgBase()
		{
			WorkStation = 1;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		/// <param name="vIP">远程IP</param>
		/// <param name="vPort">远程端口</param>
		public MsgBase(IMsg vMsg, string vIP = "0.0.0.0", int vPort = 0)
		{
			DaType = vMsg.DaType;
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vIP;
			LocalPort = vPort;
			WorkStation = vMsg.WorkStation;
		}
		/// <summary>
		/// 异常值转字符串
		/// </summary>
		/// <returns>返回</returns>
		public virtual string ToResult()
		{
			return InResToString(ResVal);
		}
		/// <summary>
		/// 状态描述
		/// </summary>
		/// <returns>返回</returns>
		public virtual string ResToString()
		{
			return InResToString(ResVal);
		}
		protected string InResToString(MsgEnu vMsgEnu)
		{
			int tmp = (int)vMsgEnu;
			if (tmp < 0 || tmp >= DescRes.Length)
				return string.Empty;
			return DescRes[tmp];
		}
		/// <summary>
		/// 设置返回值
		/// </summary>
		/// <returns></returns>
		public IMsg SetResVal(MsgEnu vMsgEnu)
		{
			ResVal = vMsgEnu;
			return this;
		}
	}
	/// <summary>
	/// 入库信息
	/// </summary>
	public class MsgInDb : MsgBase, IMsg
	{
		#region 属性
		/// <summary>
		/// 物料编码
		/// </summary>
		public string GoodsNu { get; set; }
		/// <summary>
		/// 胶盘编码
		/// </summary>
		public string DiskNu { get; set; }

		/// <summary>
		/// 流水号
		/// </summary>
		public string LotNu { get; set; }
		//add 
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public MsgInDb()
		{
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgInDb(IMsg vMsg)
		{
			DaType = "RK";
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}

	}

	/// <summary>
	/// 应答信息
	/// </summary>
	public class MsgBack : MsgBase, IMsg
	{
		/// <summary>
		/// 返回的代码
		/// </summary>
		public MsgEnu RetCode { get; set; }
		/// <summary>
		/// 胶盘编码
		/// </summary>
		public string DiskNu { get; set; }

		/// <summary>
		/// 流水号
		/// </summary>
		public string LotNu { get; set; }
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgBack()
		{
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgBack(IMsg vMsg)
		{
			DaType = "YD";
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}

		/// <summary>
		/// 状态描述
		/// </summary>
		/// <returns>返回</returns>
		public override string ResToString()
		{
			return InResToString(RetCode);
		}

		/// <summary>
		/// 转字符串
		/// </summary>
		/// <returns>返回</returns>
		public override string ToString()
		{
			string str = @"胶盘编码:{0};
流水号:{1};";
			var res = string.Format(str, DiskNu, LotNu);
			res += base.ToString();
			return res;
		}
	}

	/// <summary>
	/// 出库信息
	/// </summary>
	public class MsgOutDb : MsgBase, IMsg
	{
		#region 属性
		/// <summary>
		/// 物料编码
		/// </summary>
		public string GoodsNu { get; set; }
		/// <summary>
		/// 胶盘编码
		/// </summary>
		public string DiskNu { get; set; }

		/// <summary>
		/// 流水号
		/// </summary>
		public string LotNu { get; set; }
		//add 
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public MsgOutDb()
		{
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgOutDb(IMsg vMsg)
		{
			DaType = "CK";
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}

	}

	/// <summary>
	/// 摆盘出库
	/// </summary>
	public class MsgPlatingOutDb : MsgBase, IMsg
	{
		#region 属性
		/// <summary>
		/// 盘类型(大盘1，小盘2，高小盘3)
		/// </summary>
		public int DiskType { get; set; }

		/// <summary>
		/// 盘数量
		/// </summary>
		public int DiskCount { get; set; }

		/// <summary>
		/// 物料编码
		/// </summary>
		public string GoodsNu { get; set; }

		/// <summary>
		/// 胶盘编码
		/// </summary>
		public string DiskNu { get; set; }

		/// <summary>
		/// 流水号
		/// </summary>
		public string LotNu { get; set; }
		//add 
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public MsgPlatingOutDb()
		{
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgPlatingOutDb(IMsg vMsg)
		{
			DaType = "BC";
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}

	}

	/// <summary>
	/// 摆盘入库
	/// </summary>
	public class MsgPlatingInDb : MsgBase, IMsg
	{
		#region 属性
		/// <summary>
		/// 物料编码
		/// </summary>
		public string GoodsNu { get; set; }

		/// <summary>
		/// 胶盘编码
		/// </summary>
		public string DiskNu { get; set; }

		/// <summary>
		/// 流水号
		/// </summary>
		public string LotNu { get; set; }
		//add 
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		public MsgPlatingInDb()
		{
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgPlatingInDb(IMsg vMsg)
		{
			DaType = "BR";
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}
	}
	/// <summary>
	/// 应答信息
	/// </summary>
	public class MsgError : MsgBase, IMsg
	{
		/// <summary>
		/// 错误描述
		/// </summary>
		public string ErrDesc { get; set; }
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		public MsgError(MsgEnu vVal)
		{
			DaType = "ER";
			ErrDesc = string.Empty;
			ResVal = vVal;
		}
		/// <summary>
		/// 初始化
		/// </summary>
		public MsgError(string vDesc)
		{
			DaType = "ER";
			ErrDesc = vDesc;
		}
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="vMsg">信息</param>
		/// <param name="vVal">错误值</param>
		public MsgError(IMsg vMsg, MsgEnu vVal)
		{
			DaType = "ER";

			ResVal = vVal;
			Buffer = null;
			RemoteIP = vMsg.RemoteIP;
			RemotePort = vMsg.RemotePort;
			LocalIP = vMsg.LocalIP;
			LocalPort = vMsg.LocalPort;
			WorkStation = vMsg.WorkStation;
		}
		public override string ToResult()
		{
			return DescRes[(int)ResVal];
		}
	}
}
