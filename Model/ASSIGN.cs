using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 民意交办表
    /// </summary>
    [Serializable]
    public partial class ASSIGN
    {
        public ASSIGN()
        { }
        #region Model
        private string _id;
        private string _mysjdx;
        private string _myly;
        private DateTime? _jbrq;
        private string _jbdw;
        private string _jbyq;
        private string _ldps;
        private string _bz;
        private decimal? _zt;
        private string _cjr;
        private DateTime? _cjsj;
        private string _hfnr;
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 民意数据对象
        /// </summary>
        public string MYSJDX
        {
            set { _mysjdx = value; }
            get { return _mysjdx; }
        }
        /// <summary>
        /// 民意来源
        /// </summary>
        public string MYLY
        {
            set { _myly = value; }
            get { return _myly; }
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
        /// 交办单位
        /// </summary>
        public string JBDW
        {
            set { _jbdw = value; }
            get { return _jbdw; }
        }
        /// <summary>
        /// 交办要求
        /// </summary>
        public string JBYQ
        {
            set { _jbyq = value; }
            get { return _jbyq; }
        }
        /// <summary>
        /// 领导批示
        /// </summary>
        public string LDPS
        {
            set { _ldps = value; }
            get { return _ldps; }
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
        /// 数据状态1待答复2需审核3已审核4退办5已办结 6待上报（所有部门审核通过且事件已处理）7已查看(所有部门审核通过且事件被全部拒办)
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
        /// 各部门回复内容汇总
        /// </summary>
        public string HFNR
        {
            set { _hfnr = value; }
            get { return _hfnr; }
        }
        #endregion Model

    }
}


