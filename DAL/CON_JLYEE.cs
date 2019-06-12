using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:CON_JLYEE
    /// </summary>
    public partial class CON_JLYEE
    {
        public CON_JLYEE()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CON_JLYEE");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            return DbHelperOra_new.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CON_JLYEE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CON_JLYEE(");
            strSql.Append("ID,BH,SJBH,FYR,LXDH,FYRQ,SJR,BT,NRZR,FYNR,FJDZ,JBRQ,BJRQ,SSLB,BZ,CJR,CJSJ,ZT,XJLY)");
            strSql.Append(" values (");
            strSql.Append(":ID,:BH,:SJBH,:FYR,:LXDH,:FYRQ,:SJR,:BT,:NRZR,:FYNR,:FJDZ,:JBRQ,:BJRQ,:SSLB,:BZ,:CJR,:CJSJ,:ZT,:XJLY)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36),
                    new OracleParameter(":BH", OracleDbType.Varchar2,100),
                    new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
                    new OracleParameter(":FYR", OracleDbType.Varchar2,50),
                    new OracleParameter(":LXDH", OracleDbType.Varchar2,36),
                    new OracleParameter(":FYRQ", OracleDbType.Date),
                    new OracleParameter(":SJR", OracleDbType.Varchar2,50),
                    new OracleParameter(":BT", OracleDbType.Varchar2,500),
                    new OracleParameter(":NRZR", OracleDbType.Clob),
                    new OracleParameter(":FYNR", OracleDbType.Clob),
                    new OracleParameter(":FJDZ", OracleDbType.Varchar2,300),
                    new OracleParameter(":JBRQ", OracleDbType.Date),
                    new OracleParameter(":BJRQ", OracleDbType.Date),
                    new OracleParameter(":SSLB", OracleDbType.Int32,1),
                    new OracleParameter(":BZ", OracleDbType.Varchar2,500),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":ZT", OracleDbType.Int32,1),
                    new OracleParameter(":XJLY", OracleDbType.Varchar2,200)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.BH;
            parameters[2].Value = model.SJBH;
            parameters[3].Value = model.FYR;
            parameters[4].Value = model.LXDH;
            parameters[5].Value = model.FYRQ;
            parameters[6].Value = model.SJR;
            parameters[7].Value = model.BT;
            parameters[8].Value = model.NRZR;
            parameters[9].Value = model.FYNR;
            parameters[10].Value = model.FJDZ;
            parameters[11].Value = model.JBRQ;
            parameters[12].Value = model.BJRQ;
            parameters[13].Value = model.SSLB;
            parameters[14].Value = model.BZ;
            parameters[15].Value = model.CJR;
            parameters[16].Value = model.CJSJ;
            parameters[17].Value = model.ZT;
            parameters[18].Value = model.XJLY;

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
        public bool Update(Model.CON_JLYEE model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CON_JLYEE set ");
            strSql.Append("BH=:BH,");
            strSql.Append("SJBH=:SJBH,");
            strSql.Append("FYR=:FYR,");
            strSql.Append("LXDH=:LXDH,");
            strSql.Append("FYRQ=:FYRQ,");
            strSql.Append("SJR=:SJR,");
            strSql.Append("BT=:BT,");
            strSql.Append("NRZR=:NRZR,");
            strSql.Append("FYNR=:FYNR,");
            strSql.Append("FJDZ=:FJDZ,");
            strSql.Append("JBRQ=:JBRQ,");
            strSql.Append("BJRQ=:BJRQ,");
            strSql.Append("SSLB=:SSLB,");
            strSql.Append("BZ=:BZ,");
            strSql.Append("CJR=:CJR,");
            strSql.Append("CJSJ=:CJSJ,");
            strSql.Append("ZT=:ZT");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":BH", OracleDbType.Varchar2,100),
                    new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
                    new OracleParameter(":FYR", OracleDbType.Varchar2,50),
                    new OracleParameter(":LXDH", OracleDbType.Varchar2,36),
                    new OracleParameter(":FYRQ", OracleDbType.Date),
                    new OracleParameter(":SJR", OracleDbType.Varchar2,50),
                    new OracleParameter(":BT", OracleDbType.Varchar2,500),
                    new OracleParameter(":NRZR", OracleDbType.Clob),
                    new OracleParameter(":FYNR", OracleDbType.Clob),
                    new OracleParameter(":FJDZ", OracleDbType.Varchar2,300),
                    new OracleParameter(":JBRQ", OracleDbType.Date),
                    new OracleParameter(":BJRQ", OracleDbType.Date),
                    new OracleParameter(":SSLB", OracleDbType.Int32,1),
                    new OracleParameter(":BZ", OracleDbType.Varchar2,500),
                    new OracleParameter(":CJR", OracleDbType.Varchar2,36),
                    new OracleParameter(":CJSJ", OracleDbType.Date),
                    new OracleParameter(":ZT", OracleDbType.Int32,1),
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)};
            parameters[0].Value = model.BH;
            parameters[1].Value = model.SJBH;
            parameters[2].Value = model.FYR;
            parameters[3].Value = model.LXDH;
            parameters[4].Value = model.FYRQ;
            parameters[5].Value = model.SJR;
            parameters[6].Value = model.BT;
            parameters[7].Value = model.NRZR;
            parameters[8].Value = model.FYNR;
            parameters[9].Value = model.FJDZ;
            parameters[10].Value = model.JBRQ;
            parameters[11].Value = model.BJRQ;
            parameters[12].Value = model.SSLB;
            parameters[13].Value = model.BZ;
            parameters[14].Value = model.CJR;
            parameters[15].Value = model.CJSJ;
            parameters[16].Value = model.ZT;
            parameters[17].Value = model.ID;

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
            strSql.Append("delete from CON_JLYEE ");
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
            strSql.Append("delete from CON_JLYEE ");
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
        public Model.CON_JLYEE GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BH,SJBH,FYR,LXDH,FYRQ,SJR,BT,NRZR,FYNR,FJDZ,JBRQ,BJRQ,SSLB,BZ,CJR,CJSJ,ZT from CON_JLYEE ");
            strSql.Append(" where ID=:ID ");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleDbType.Varchar2,36)           };
            parameters[0].Value = ID;

            Model.CON_JLYEE model = new Model.CON_JLYEE();
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
        public Model.CON_JLYEE DataRowToModel(DataRow row)
        {
            Model.CON_JLYEE model = new Model.CON_JLYEE();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["BH"] != null)
                {
                    model.BH = row["BH"].ToString();
                }
                if (row["SJBH"] != null)
                {
                    model.SJBH = row["SJBH"].ToString();
                }
                if (row["FYR"] != null)
                {
                    model.FYR = row["FYR"].ToString();
                }
                if (row["LXDH"] != null)
                {
                    model.LXDH = row["LXDH"].ToString();
                }
                if (row["FYRQ"] != null && row["FYRQ"].ToString() != "")
                {
                    model.FYRQ = DateTime.Parse(row["FYRQ"].ToString());
                }
                if (row["SJR"] != null)
                {
                    model.SJR = row["SJR"].ToString();
                }
                if (row["BT"] != null)
                {
                    model.BT = row["BT"].ToString();
                }
                //model.NRZR=row["NRZR"].ToString();
                //model.FYNR=row["FYNR"].ToString();
                if (row["FJDZ"] != null)
                {
                    model.FJDZ = row["FJDZ"].ToString();
                }
                if (row["JBRQ"] != null && row["JBRQ"].ToString() != "")
                {
                    model.JBRQ = DateTime.Parse(row["JBRQ"].ToString());
                }
                if (row["BJRQ"] != null && row["BJRQ"].ToString() != "")
                {
                    model.BJRQ = DateTime.Parse(row["BJRQ"].ToString());
                }
                if (row["SSLB"] != null && row["SSLB"].ToString() != "")
                {
                    model.SSLB = decimal.Parse(row["SSLB"].ToString());
                }
                if (row["BZ"] != null)
                {
                    model.BZ = row["BZ"].ToString();
                }
                if (row["CJR"] != null)
                {
                    model.CJR = row["CJR"].ToString();
                }
                if (row["CJSJ"] != null)
                {
                    model.CJSJ = DateTime.Parse(row["CJSJ"].ToString());
                }
                if (row["ZT"] != null && row["ZT"].ToString() != "")
                {
                    model.ZT = decimal.Parse(row["ZT"].ToString());
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
            strSql.Append("select ID,BH,SJBH,FYR,LXDH,FYRQ,SJR,BT,NRZR,FYNR,FJDZ,JBRQ,BJRQ,SSLB,BZ,CJR,CJSJ,ZT ");
            strSql.Append(" FROM CON_JLYEE ");
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
            strSql.Append("select count(1) FROM CON_JLYEE ");
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
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CON_JLYEE T ");
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
					new OracleParameter(":PageSize", OracleDbType.Number),
					new OracleParameter(":PageIndex", OracleDbType.Number),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "CON_JLYEE";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


