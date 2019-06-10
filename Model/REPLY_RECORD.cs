using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 民意处办回复记录表
	/// </summary>
	[Serializable]
	public partial class REPLY_RECORD
	{
		public REPLY_RECORD()
		{}
		#region Model
		private string _id;
		private string _cbid;
		private string _hfnr;
		private decimal? _zt;
		private string _cjr;
		private DateTime? _cjsj;
		private decimal? _cblx;
		private string _fjdz;
		private string _fjm;
		/// <summary>
		/// id
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 处办id
		/// </summary>
		public string CBID
		{
			set{ _cbid=value;}
			get{return _cbid;}
		}
		/// <summary>
		/// 回复内容
		/// </summary>
		public string HFNR
		{
			set{ _hfnr=value;}
			get{return _hfnr;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public decimal? ZT
		{
			set{ _zt=value;}
			get{return _zt;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string CJR
		{
			set{ _cjr=value;}
			get{return _cjr;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CJSJ
		{
			set{ _cjsj=value;}
			get{return _cjsj;}
		}
		/// <summary>
		/// 处办类型
		/// </summary>
		public decimal? CBLX
		{
			set{ _cblx=value;}
			get{return _cblx;}
		}
		/// <summary>
		/// 附件地址
		/// </summary>
		public string FJDZ
		{
			set{ _fjdz=value;}
			get{return _fjdz;}
		}
		/// <summary>
		/// 附件名
		/// </summary>
		public string FJM
		{
			set{ _fjm=value;}
			get{return _fjm;}
		}
		#endregion Model

	}
}

