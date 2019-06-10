using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 上报附件地址
	/// </summary>
	[Serializable]
	public partial class ASSIGN_UPFJ
	{
		public ASSIGN_UPFJ()
		{}
		#region Model
		private string _id;
		private string _up_id;
		private string _ip;
		private string _fjdz;
		private string _fjmc;
		private DateTime? _createtime;
		private string _creator;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 上报id
		/// </summary>
		public string UP_ID
		{
			set{ _up_id=value;}
			get{return _up_id;}
		}
		/// <summary>
		/// ip加端口
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 附件相对地址
		/// </summary>
		public string FJDZ
		{
			set{ _fjdz=value;}
			get{return _fjdz;}
		}
		/// <summary>
		/// 附件名称
		/// </summary>
		public string FJMC
		{
			set{ _fjmc=value;}
			get{return _fjmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CREATETIME
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		#endregion Model

	}
}

