using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 96122
    /// </summary>
    [Serializable]
    public partial class CON_JLYEE
    {
        public CON_JLYEE()
        { }
        #region Model
        private string _id;
        private string _bh;
        private string _sjbh;
        private string _fyr;
        private string _lxdh;
        private DateTime? _fyrq;
        private string _sjr;
        private string _bt;
        private string _nrzr;
        private string _fynr;
        private string _fjdz;
        private DateTime? _jbrq;
        private DateTime? _bjrq;
        private decimal? _sslb;
        private string _bz;
        private string _cjr;
        private DateTime? _cjsj;
        private decimal? _zt;
        /// <summary>
        /// 主键ID（32位或36位guid）
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string BH
        {
            set { _bh = value; }
            get { return _bh; }
        }
        /// <summary>
        /// 上级编号
        /// </summary>
        public string SJBH
        {
            set { _sjbh = value; }
            get { return _sjbh; }
        }
        /// <summary>
        /// 反映人
        /// </summary>
        public string FYR
        {
            set { _fyr = value; }
            get { return _fyr; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LXDH
        {
            set { _lxdh = value; }
            get { return _lxdh; }
        }
        /// <summary>
        /// 反映日期
        /// </summary>
        public DateTime? FYRQ
        {
            set { _fyrq = value; }
            get { return _fyrq; }
        }
        /// <summary>
        /// 收件人
        /// </summary>
        public string SJR
        {
            set { _sjr = value; }
            get { return _sjr; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string BT
        {
            set { _bt = value; }
            get { return _bt; }
        }
        /// <summary>
        /// 内容摘要
        /// </summary>
        public string NRZR
        {
            set { _nrzr = value; }
            get { return _nrzr; }
        }
        /// <summary>
        /// 反映内容
        /// </summary>
        public string FYNR
        {
            set { _fynr = value; }
            get { return _fynr; }
        }
        /// <summary>
        /// 附件地址
        /// </summary>
        public string FJDZ
        {
            set { _fjdz = value; }
            get { return _fjdz; }
        }
        /// <summary>
        /// 交办日期
        /// </summary>
        public DateTime? JBRQ
        {
            set { _jbrq = value; }
            get { return _jbrq; }
        }
        /// <summary>
        /// 办结日期
        /// </summary>
        public DateTime? BJRQ
        {
            set { _bjrq = value; }
            get { return _bjrq; }
        }
        /// <summary>
        /// 所属类别1.投诉  2.建议 3.咨询 4.举报 5.求助 6.表扬
        /// </summary>
        public decimal? SSLB
        {
            set { _sslb = value; }
            get { return _sslb; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string BZ
        {
            set { _bz = value; }
            get { return _bz; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CJR
        {
            set { _cjr = value; }
            get { return _cjr; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CJSJ
        {
            set { _cjsj = value; }
            get { return _cjsj; }
        }
        /// <summary>
        /// 状态( 0.删除 1.有效)
        /// </summary>
        public decimal? ZT
        {
            set { _zt = value; }
            get { return _zt; }
        }
        #endregion Model

    }
}

