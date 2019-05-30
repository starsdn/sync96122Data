using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    /// <summary>
    /// INFO_ACCEPT_VIEW
    /// </summary>
    public partial class INFO_ACCEPT_VIEW
    {
        private readonly DAL.INFO_ACCEPT_VIEW dal = new DAL.INFO_ACCEPT_VIEW();
        public INFO_ACCEPT_VIEW()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal INFOID, decimal DEPTID, DateTime DTDATE, decimal REDEPTID, string INTNUM, string CHRTITLE, string CHRDESC, decimal CLASSID, decimal TYPEID, decimal INTLEVEL, decimal USERID, decimal IS_CAI, DateTime DTAPPENDDDATE, decimal ISCHECK, decimal CHECKID, DateTime CHECKDATE, string SUBJECTID, string NAME, string CHRCLASS, decimal CATEGORYID, string CHRTYPE, string CHRTRUENAME, decimal ISGONE, string CHRNO, string FORMID, decimal ISERROR)
        {
            return dal.Exists(INFOID, DEPTID, DTDATE, REDEPTID, INTNUM, CHRTITLE, CHRDESC, CLASSID, TYPEID, INTLEVEL, USERID, IS_CAI, DTAPPENDDDATE, ISCHECK, CHECKID, CHECKDATE, SUBJECTID, NAME, CHRCLASS, CATEGORYID, CHRTYPE, CHRTRUENAME, ISGONE, CHRNO, FORMID, ISERROR);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.INFO_ACCEPT_VIEW GetModel(decimal INFOID, decimal DEPTID, DateTime DTDATE, decimal REDEPTID, string INTNUM, string CHRTITLE, string CHRDESC, decimal CLASSID, decimal TYPEID, decimal INTLEVEL, decimal USERID, decimal IS_CAI, DateTime DTAPPENDDDATE, decimal ISCHECK, decimal CHECKID, DateTime CHECKDATE, string SUBJECTID, string NAME, string CHRCLASS, decimal CATEGORYID, string CHRTYPE, string CHRTRUENAME, decimal ISGONE, string CHRNO, string FORMID, decimal ISERROR)
        {

            return dal.GetModel(INFOID, DEPTID, DTDATE, REDEPTID, INTNUM, CHRTITLE, CHRDESC, CLASSID, TYPEID, INTLEVEL, USERID, IS_CAI, DTAPPENDDDATE, ISCHECK, CHECKID, CHECKDATE, SUBJECTID, NAME, CHRCLASS, CATEGORYID, CHRTYPE, CHRTRUENAME, ISGONE, CHRNO, FORMID, ISERROR);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.INFO_ACCEPT_VIEW> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.INFO_ACCEPT_VIEW> DataTableToList(DataTable dt)
        {
            List <Model.INFO_ACCEPT_VIEW > modelList = new List<Model.INFO_ACCEPT_VIEW>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
				Model.INFO_ACCEPT_VIEW model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
