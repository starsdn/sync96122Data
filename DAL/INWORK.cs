using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:INWORK
    /// </summary>
    public partial class INWORK
    {
        public INWORK()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from INWORK");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            return DbHelperOra_new.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.INWORK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into INWORK(");
            strSql.Append("ID,JBSJ,JBDW,CBLX,ZT,CJR,CJSJ,ISTX,TXSJ,ISZB,ZBYH,UPDEP)");
            strSql.Append(" values (");
            strSql.Append(":ID,:JBSJ,:JBDW,:CBLX,:ZT,:CJR,:CJSJ,:ISTX,:TXSJ,:ISZB,:ZBYH,:UPDEP)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36),
                    new OracleParameter(":JBSJ", OracleDbType.Varchar2,36),
                    new OracleParameter(":JBDW", OracleDbType.Varchar2,36),
                    new OracleParameter(":CBLX", OracleDbType.Int32,4),
                    new OracleParameter(":ZT", OracleDbType.Int32,4),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":ISTX", OracleDbType.Int32,4),
                    new OracleParameter(":TXSJ", OracleDbType.Date),
                    new OracleParameter(":ISZB", OracleDbType.Int32,4),
                    new OracleParameter(":ZBYH", OracleDbType.Varchar2,36),
                    new OracleParameter(":UPDEP", OracleDbType.Int32,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.JBSJ;
            parameters[2].Value = model.JBDW;
            parameters[3].Value = model.CBLX;
            parameters[4].Value = model.ZT;
            parameters[5].Value = model.CJR;
            parameters[6].Value = model.CJSJ;
            parameters[7].Value = model.ISTX;
            parameters[8].Value = model.TXSJ;
            parameters[9].Value = model.ISZB;
            parameters[10].Value = model.ZBYH;
            parameters[11].Value = model.UPDEP;

            int rows = DbHelperOra_new.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.INWORK model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update INWORK set ");
            strSql.Append("JBSJ=:JBSJ,");
            strSql.Append("JBDW=:JBDW,");
            strSql.Append("CBLX=:CBLX,");
            strSql.Append("ZT=:ZT,");
            strSql.Append("CJR=:CJR,");
            strSql.Append("CJSJ=:CJSJ,");
            strSql.Append("ISTX=:ISTX,");
            strSql.Append("TXSJ=:TXSJ,");
            strSql.Append("ISZB=:ISZB,");
            strSql.Append("ZBYH=:ZBYH");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":JBSJ", OracleDbType.Varchar2,36),
                    new OracleParameter(":JBDW", OracleDbType.Varchar2,36),
                    new OracleParameter(":CBLX", OracleDbType.Int32,4),
                    new OracleParameter(":ZT", OracleDbType.Int32,4),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":ISTX", OracleDbType.Int32,4),
                    new OracleParameter(":TXSJ", OracleDbType.Date),
                    new OracleParameter(":ISZB", OracleDbType.Int32,4),
                    new OracleParameter(":ZBYH", OracleDbType.Varchar2,36),
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)};
            parameters[0].Value = model.JBSJ;
            parameters[1].Value = model.JBDW;
            parameters[2].Value = model.CBLX;
            parameters[3].Value = model.ZT;
            parameters[4].Value = model.CJR;
            parameters[5].Value = model.CJSJ;
            parameters[6].Value = model.ISTX;
            parameters[7].Value = model.TXSJ;
            parameters[8].Value = model.ISZB;
            parameters[9].Value = model.ZBYH;
            parameters[10].Value = model.ID;

            int rows = DbHelperOra_new.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from INWORK ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            int rows = DbHelperOra_new.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from INWORK ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperOra_new.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.INWORK GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,JBSJ,JBDW,CBLX,ZT,CJR,CJSJ,ISTX,TXSJ,ISZB,ZBYH from INWORK ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            Model.INWORK model = new Model.INWORK();
            DataSet ds = DbHelperOra_new.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.INWORK DataRowToModel(DataRow row)
        {
            Model.INWORK model = new Model.INWORK();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["JBSJ"] != null)
                {
                    model.JBSJ = row["JBSJ"].ToString();
                }
                if (row["JBDW"] != null)
                {
                    model.JBDW = row["JBDW"].ToString();
                }
                if (row["CBLX"] != null && row["CBLX"].ToString() != "")
                {
                    model.CBLX = decimal.Parse(row["CBLX"].ToString());
                }
                if (row["ZT"] != null && row["ZT"].ToString() != "")
                {
                    model.ZT = decimal.Parse(row["ZT"].ToString());
                }
                if (row["CJR"] != null)
                {
                    model.CJR = row["CJR"].ToString();
                }
                if (row["CJSJ"] != null && row["CJSJ"].ToString() != "")
                {
                    model.CJSJ = DateTime.Parse(row["CJSJ"].ToString());
                }
                if (row["ISTX"] != null && row["ISTX"].ToString() != "")
                {
                    model.ISTX = decimal.Parse(row["ISTX"].ToString());
                }
                if (row["TXSJ"] != null && row["TXSJ"].ToString() != "")
                {
                    model.TXSJ = DateTime.Parse(row["TXSJ"].ToString());
                }
                if (row["ISZB"] != null && row["ISZB"].ToString() != "")
                {
                    model.ISZB = decimal.Parse(row["ISZB"].ToString());
                }
                if (row["ZBYH"] != null)
                {
                    model.ZBYH = row["ZBYH"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,JBSJ,JBDW,CBLX,ZT,CJR,CJSJ,ISTX,TXSJ,ISZB,ZBYH ");
            strSql.Append(" FROM INWORK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra_new.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM INWORK ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOra_new.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_Int32() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from INWORK T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra_new.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Int32),
					new OracleParameter(":PageIndex", OracleDbType.Int32),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "INWORK";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra_new.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
