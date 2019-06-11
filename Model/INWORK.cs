using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 民意处办表  
    /// </summary>
    [Serializable]
    public partial class INWORK
    {
        public INWORK()
        { }
        #region Model
        private string _id;
        private string _jbsj;
        private string _jbdw;
        private decimal? _cblx;
        private decimal? _zt;
        private string _cjr;
        private DateTime? _cjsj;
        private decimal? _istx = 0M;
        private DateTime? _txsj;
        private decimal? _iszb = 2M;
		private string _zbyh;
        private decimal? _updep;
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 交办数据id
        /// </summary>
        public string JBSJ
        {
            set { _jbsj = value; }
            get { return _jbsj; }
        }
        /// <summary>
        /// 交办单位
        /// </summary>
        public string JBDW
        {
            set { _jbdw = value; }
            get { return _jbdw; }
        }
        /// <summary>
        /// 处办类型1办理2拒办
        /// </summary>
        public decimal? CBLX
        {
            set { _cblx = value; }
            get { return _cblx; }
        }
        /// <summary>
        /// 数据有效性状态1待答复2待交办回复3待审核4退办5待办结6已办结
        /// </summary>
        public decimal? ZT
        {
            set { _zt = value; }
            get { return _zt; }
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
        /// 是否提醒
        /// </summary>
        public decimal? ISTX
        {
            set { _istx = value; }
            get { return _istx; }
        }
        /// <summary>
        /// 提醒时间
        /// </summary>
        public DateTime? TXSJ
        {
            set { _txsj = value; }
            get { return _txsj; }
        }
        /// <summary>
        /// 是否转办给其他同事1是2否
        /// </summary>
        public decimal? ISZB
        {
            set { _iszb = value; }
            get { return _iszb; }
        }
        /// <summary>
        /// 转办用户
        /// </summary>
        public string ZBYH
        {
            set { _zbyh = value; }
            get { return _zbyh; }
        }

        /// <summary>
        /// 上报处理部门，0：否，1：是
        /// </summary>
        public decimal? UPDEP
        {
            set { _updep = value; }
            get { return _updep; }
        }
        #endregion Model

    }
}

