using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmsModel
{
    /// <summary>
    /// UDP通讯信息接口
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// 信息类型
        /// </summary>
        string DaType { get; set; }
		/// <summary>
		/// 1.0版本(10)
		/// </summary>
		string Ver { get; }
        /// <summary>
        /// 信息内容
        /// </summary>
        byte[] Buffer { get; set; }

		/// <summary>
		/// 信息内容长度
		/// </summary>
		int Length { get;  }

		/// <summary>
		/// 远端IP
		/// </summary>
		string RemoteIP { get; set; }

        /// <summary>
        /// 远端端口
        /// </summary>
        int RemotePort { get; set; }

        /// <summary>
        /// 本地IP
        /// </summary>
        string LocalIP { get; set; }

        /// <summary>
        /// 本地端口
        /// </summary>
        int LocalPort { get; set; }

		/// <summary>
		/// 帧字符串
		/// </summary>
		string strFrm { get; set; }
		/// <summary>
		/// 工位(1)
		/// </summary>
		int WorkStation { get; set; }

		/// <summary>
		/// 结果值
		/// </summary>
		MsgEnu ResVal { get; set; }

		/// <summary>
		/// 是否成功
		/// </summary>
		bool IsSucc { get; }

		/// <summary>
		/// 发送过程结果
		/// </summary>
		/// <returns></returns>
		string ToResult();

		/// <summary>
		/// 状态描述
		/// </summary>
		/// <returns></returns>
		string ResToString();

		/// <summary>
		/// 设置返回值
		/// </summary>
		/// <returns>返回</returns>
		IMsg SetResVal(MsgEnu vMsgEnu);
	}
}
