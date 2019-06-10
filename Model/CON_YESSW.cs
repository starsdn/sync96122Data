using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	/// <summary>
	/// 12345热线
	/// </summary>
	[Serializable]
	public partial class CON_YESSW
	{
		public CON_YESSW()
		{}
		#region Model
		private string _id;
		private string _bh;
		private string _sjbh;
		private string _ldr;
		private string _lxdh;
		private DateTime? _fyrq;
		private string _fylx;
		private string _fynr;
		private string _nrzy;
		private string _fjdz;
		private string _yq;
		private DateTime? _jbrq;
		private DateTime? _blqx;
		private string _jbyq;
		private DateTime? _fpsj;
		private string _bz;
		private string _ldps;
		private string _cjr;
		private DateTime? _cjsj;
		private decimal? _zt;
		private string _xbdw;
		private string _fjm;
		/// <summary>
		/// 主键ID（32位或36位guid）
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 编号
		/// </summary>
		public string BH
		{
			set{ _bh=value;}
			get{return _bh;}
		}
		/// <summary>
		/// 上级编号
		/// </summary>
		public string SJBH
		{
			set{ _sjbh=value;}
			get{return _sjbh;}
		}
		/// <summary>
		/// 来电人
		/// </summary>
		public string LDR
		{
			set{ _ldr=value;}
			get{return _ldr;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string LXDH
		{
			set{ _lxdh=value;}
			get{return _lxdh;}
		}
		/// <summary>
		/// 来电日期
		/// </summary>
		public DateTime? FYRQ
		{
			set{ _fyrq=value;}
			get{return _fyrq;}
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
		/// 反映内容
		/// </summary>
		public string FYNR
		{
			set{ _fynr=value;}
			get{return _fynr;}
		}
		/// <summary>
		/// 内容摘要
		/// </summary>
		public string NRZY
		{
			set{ _nrzy=value;}
			get{return _nrzy;}
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
		/// 要求
		/// </summary>
		public string YQ
		{
			set{ _yq=value;}
			get{return _yq;}
		}
		/// <summary>
		/// 交办日期
		/// </summary>
		public DateTime? JBRQ
		{
			set{ _jbrq=value;}
			get{return _jbrq;}
		}
		/// <summary>
		/// 办理期限
		/// </summary>
		public DateTime? BLQX
		{
			set{ _blqx=value;}
			get{return _blqx;}
		}
		/// <summary>
		/// 交办要求
		/// </summary>
		public string JBYQ
		{
			set{ _jbyq=value;}
			get{return _jbyq;}
		}
		/// <summary>
		/// 分配时间
		/// </summary>
		public DateTime? FPSJ
		{
			set{ _fpsj=value;}
			get{return _fpsj;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string BZ
		{
			set{ _bz=value;}
			get{return _bz;}
		}
		/// <summary>
		/// 领导批示
		/// </summary>
		public string LDPS
		{
			set{ _ldps=value;}
			get{return _ldps;}
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
		/// 创建时间（时间格式，便于数据库查看）
		/// </summary>
		public DateTime? CJSJ
		{
			set{ _cjsj=value;}
			get{return _cjsj;}
		}
		/// <summary>
		/// 状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
		/// </summary>
		public decimal? ZT
		{
			set{ _zt=value;}
			get{return _zt;}
		}
		/// <summary>
		/// 协办单位
		/// </summary>
		public string XBDW
		{
			set{ _xbdw=value;}
			get{return _xbdw;}
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

