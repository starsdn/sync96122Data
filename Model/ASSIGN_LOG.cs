using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 交办业务流转日志表
	/// </summary>
	[Serializable]
	public partial class ASSIGN_LOG
	{
		public ASSIGN_LOG()
		{}
		#region Model
		private string _id;
		private string _assign_id;
		private string _inwork_id;
		private string _depart_id;
		private string _user_id;
		private decimal? _event;
		private string _content;
		private DateTime? _dealdate;
		private string _dealtime;
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
		/// 交办id
		/// </summary>
		public string ASSIGN_ID
		{
			set{ _assign_id=value;}
			get{return _assign_id;}
		}
		/// <summary>
		/// 处办id
		/// </summary>
		public string INWORK_ID
		{
			set{ _inwork_id=value;}
			get{return _inwork_id;}
		}
		/// <summary>
		/// 部门id
		/// </summary>
		public string DEPART_ID
		{
			set{ _depart_id=value;}
			get{return _depart_id;}
		}
		/// <summary>
		/// 用户id
		/// </summary>
		public string USER_ID
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		/// <summary>
		/// 1交办；2交办编辑；3二次交办；4部门内部答复；5部门答复；6部门审核；7部门退回；8监察室审核；9监察室退回；10评价；11上报；12已办结；13回访
		/// </summary>
		public decimal? EVENT
		{
			set{ _event=value;}
			get{return _event;}
		}
		/// <summary>
		/// 事件内容
		/// </summary>
		public string CONTENT
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 处理日期
		/// </summary>
		public DateTime? DEALDATE
		{
			set{ _dealdate=value;}
			get{return _dealdate;}
		}
		/// <summary>
		/// 处理时间
		/// </summary>
		public string DEALTIME
		{
			set{ _dealtime=value;}
			get{return _dealtime;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime? CREATETIME
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 创建人
		/// </summary>
		public string CREATOR
		{
			set{ _creator=value;}
			get{return _creator;}
		}
		#endregion Model

	}
}

