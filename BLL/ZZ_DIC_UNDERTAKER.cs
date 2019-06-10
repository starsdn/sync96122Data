using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    //同步一期民意数据的部门关系表
    public partial class ZZ_DIC_UNDERTAKER
    {

        private readonly DAL.ZZ_DIC_UNDERTAKER dal = new DAL.ZZ_DIC_UNDERTAKER();
        public ZZ_DIC_UNDERTAKER()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            return dal.Exists();
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.ZZ_DIC_UNDERTAKER model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ZZ_DIC_UNDERTAKER model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {

            return dal.Delete();
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.ZZ_DIC_UNDERTAKER GetModel()
        {

            return dal.GetModel();
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.ZZ_DIC_UNDERTAKER GetModelByCache()
        //{

        //    string CacheKey = "ZZ_DIC_UNDERTAKERModel-" + ;
        //    object objModel = Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel();
        //            if (objModel != null)
        //            {
        //                int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Model.ZZ_DIC_UNDERTAKER)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ZZ_DIC_UNDERTAKER> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.ZZ_DIC_UNDERTAKER> DataTableToList(DataTable dt)
        {
            List<Model.ZZ_DIC_UNDERTAKER> modelList = new List<Model.ZZ_DIC_UNDERTAKER>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.ZZ_DIC_UNDERTAKER model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.ZZ_DIC_UNDERTAKER();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = decimal.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.JIGMC = dt.Rows[n]["JIGMC"].ToString();
                    model.JIANC = dt.Rows[n]["JIANC"].ToString();
                    if (dt.Rows[n]["STATES"].ToString() != "")
                    {
                        model.STATES = decimal.Parse(dt.Rows[n]["STATES"].ToString());
                    }
                    model.REMARKS = dt.Rows[n]["REMARKS"].ToString();
                    model.CREATE_PEOPLE = dt.Rows[n]["CREATE_PEOPLE"].ToString();
                    if (dt.Rows[n]["CREATE_DATE"].ToString() != "")
                    {
                        model.CREATE_DATE = DateTime.Parse(dt.Rows[n]["CREATE_DATE"].ToString());
                    }
                    model.MODIFY_PEOPLE = dt.Rows[n]["MODIFY_PEOPLE"].ToString();
                    if (dt.Rows[n]["MODIFY_DATE"].ToString() != "")
                    {
                        model.MODIFY_DATE = DateTime.Parse(dt.Rows[n]["MODIFY_DATE"].ToString());
                    }
                    model.SHANGJBM = dt.Rows[n]["SHANGJBM"].ToString();
                    model.BIANM = dt.Rows[n]["BIANM"].ToString();
                    if (dt.Rows[n]["PARENTID"].ToString() != "")
                    {
                        model.PARENTID = decimal.Parse(dt.Rows[n]["PARENTID"].ToString());
                    }
                    model.ZHIDUIID = dt.Rows[n]["ZHIDUIID"].ToString();
                    if (dt.Rows[n]["TYPE"].ToString() != "")
                    {
                        model.TYPE = decimal.Parse(dt.Rows[n]["TYPE"].ToString());
                    }
                    if (dt.Rows[n]["ORDERNUM"].ToString() != "")
                    {
                        model.ORDERNUM = decimal.Parse(dt.Rows[n]["ORDERNUM"].ToString());
                    }
                    model.DIANXINBUMEN = dt.Rows[n]["DIANXINBUMEN"].ToString();
                    model.GUID = dt.Rows[n]["GUID"].ToString();


                    modelList.Add(model);
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
        #endregion

    }
}