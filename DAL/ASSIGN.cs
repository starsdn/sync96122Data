using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:ASSIGN
    /// </summary>
    public partial class ASSIGN
    {
        public ASSIGN()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ASSIGN");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            return DbHelperOra_new.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.ASSIGN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ASSIGN(");
            strSql.Append("ID,MYSJDX,MYLY,JBRQ,JBDW,JBYQ,LDPS,BZ,ZT,CJR,CJSJ,HFNR)");
            strSql.Append(" values (");
            strSql.Append(":ID,:MYSJDX,:MYLY,:JBRQ,:JBDW,:JBYQ,:LDPS,:BZ,:ZT,:CJR,:CJSJ,:HFNR)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36),
                    new OracleParameter(":MYSJDX", OracleDbType.Varchar2,36),
                    new OracleParameter(":MYLY", OracleDbType.Varchar2,36),
                    new OracleParameter(":JBRQ", OracleDbType.Date),
                    new OracleParameter(":JBDW", OracleDbType.Varchar2,2000),
                    new OracleParameter(":JBYQ", OracleDbType.Varchar2,2000),
                    new OracleParameter(":LDPS", OracleDbType.Varchar2,2000),
                    new OracleParameter(":BZ", OracleDbType.Varchar2,2000),
                    new OracleParameter(":ZT", OracleDbType.Int32,4),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":HFNR", OracleDbType.Clob,4000)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.MYSJDX;
            parameters[2].Value = model.MYLY;
            parameters[3].Value = model.JBRQ;
            parameters[4].Value = model.JBDW;
            parameters[5].Value = model.JBYQ;
            parameters[6].Value = model.LDPS;
            parameters[7].Value = model.BZ;
            parameters[8].Value = model.ZT;
            parameters[9].Value = model.CJR;
            parameters[10].Value = model.CJSJ;
            parameters[11].Value = model.HFNR;

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
        public bool Update(Model.ASSIGN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ASSIGN set ");
            strSql.Append("MYSJDX=:MYSJDX,");
            strSql.Append("MYLY=:MYLY,");
            strSql.Append("JBRQ=:JBRQ,");
            strSql.Append("JBDW=:JBDW,");
            strSql.Append("JBYQ=:JBYQ,");
            strSql.Append("LDPS=:LDPS,");
            strSql.Append("BZ=:BZ,");
            strSql.Append("ZT=:ZT,");
            strSql.Append("CJR=:CJR,");
            strSql.Append("CJSJ=:CJSJ,");
            strSql.Append("HFNR=:HFNR");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":MYSJDX", OracleDbType.Varchar2,36),
                    new OracleParameter(":MYLY", OracleDbType.Varchar2,36),
                    new OracleParameter(":JBRQ", OracleDbType.Date),
                    new OracleParameter(":JBDW", OracleDbType.Varchar2,2000),
                    new OracleParameter(":JBYQ", OracleDbType.Varchar2,2000),
                    new OracleParameter(":LDPS", OracleDbType.Varchar2,2000),
                    new OracleParameter(":BZ", OracleDbType.Varchar2,2000),
                    new OracleParameter(":ZT", OracleDbType.Int32,4),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":HFNR", OracleDbType.Clob,4000),
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)};
            parameters[0].Value = model.MYSJDX;
            parameters[1].Value = model.MYLY;
            parameters[2].Value = model.JBRQ;
            parameters[3].Value = model.JBDW;
            parameters[4].Value = model.JBYQ;
            parameters[5].Value = model.LDPS;
            parameters[6].Value = model.BZ;
            parameters[7].Value = model.ZT;
            parameters[8].Value = model.CJR;
            parameters[9].Value = model.CJSJ;
            parameters[10].Value = model.HFNR;
            parameters[11].Value = model.ID;

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
            strSql.Append("delete from ASSIGN ");
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
            strSql.Append("delete from ASSIGN ");
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
        public Model.ASSIGN GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MYSJDX,MYLY,JBRQ,JBDW,JBYQ,LDPS,BZ,ZT,CJR,CJSJ,HFNR from ASSIGN ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            Model.ASSIGN model = new Model.ASSIGN();
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
        public Model.ASSIGN DataRowToModel(DataRow row)
        {
            Model.ASSIGN model = new Model.ASSIGN();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["MYSJDX"] != null)
                {
                    model.MYSJDX = row["MYSJDX"].ToString();
                }
                if (row["MYLY"] != null)
                {
                    model.MYLY = row["MYLY"].ToString();
                }
                if (row["JBRQ"] != null && row["JBRQ"].ToString() != "")
                {
                    model.JBRQ = DateTime.Parse(row["JBRQ"].ToString());
                }
                if (row["JBDW"] != null)
                {
                    model.JBDW = row["JBDW"].ToString();
                }
                if (row["JBYQ"] != null)
                {
                    model.JBYQ = row["JBYQ"].ToString();
                }
                if (row["LDPS"] != null)
                {
                    model.LDPS = row["LDPS"].ToString();
                }
                if (row["BZ"] != null)
                {
                    model.BZ = row["BZ"].ToString();
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
                //model.HFNR=row["HFNR"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MYSJDX,MYLY,JBRQ,JBDW,JBYQ,LDPS,BZ,ZT,CJR,CJSJ,HFNR ");
            strSql.Append(" FROM ASSIGN ");
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
            strSql.Append("select count(1) FROM ASSIGN ");
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
            strSql.Append(")AS Row, T.*  from ASSIGN T ");
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
			parameters[0].Value = "ASSIGN";
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

