using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 上报信息表
	/// </summary>
	[Serializable]
	public partial class ASSIGN_UPREPORT
	{
		public ASSIGN_UPREPORT()
		{}
		#region Model
		private string _id;
		private string _assign_id;
		private string _dealcontent;
		private string _fylx;
		private DateTime? _createtime;
		private string _creator;
		private decimal? _myly;
		/// <summary>
		/// id
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
		/// 调查内容
		/// </summary>
		public string DEALCONTENT
		{
			set{ _dealcontent=value;}
			get{return _dealcontent;}
		}
		/// <summary>
		/// 反映类型
		/// </summary>
		public string FYLX
		{
			set{ _fylx=value;}
			get{return _fylx;}
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
		/// <summary>
		/// 民意来源 1寒山闻钟论坛；2：12345热线；3纪委条线；4：信访条线；5省厅、总队信件办理；6督察条线来信；7支队信件转办；8其他自选项；9：96122
		/// </summary>
		public decimal? MYLY
		{
			set{ _myly=value;}
			get{return _myly;}
		}
		#endregion Model

	}
}

