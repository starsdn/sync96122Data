using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 反应类型字典表
	/// </summary>
	[Serializable]
	public partial class SYS_FYLXBASEDATA
	{
		public SYS_FYLXBASEDATA()
		{}
		#region Model
		private decimal _id;
		private string _name;
		private string _parent_code;
		private decimal? _baselevel;
		private decimal? _state;
		private string _code;
		private string _remark;
		private DateTime? _createtime;
		private string _creator;
		/// <summary>
		/// id
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 字典名称
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 上级code
		/// </summary>
		public string PARENT_CODE
		{
			set{ _parent_code=value;}
			get{return _parent_code;}
		}
		/// <summary>
		/// 等级
		/// </summary>
		public decimal? BASELEVEL
		{
			set{ _baselevel=value;}
			get{return _baselevel;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public decimal? STATE
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 代码
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK
		{
			set{ _remark=value;}
			get{return _remark;}
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

