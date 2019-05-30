using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类:INFO_ACCEPT_VIEW
    /// </summary>
    public partial class INFO_ACCEPT_VIEW
    {
        public INFO_ACCEPT_VIEW()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal INFOID, decimal DEPTID, DateTime DTDATE, decimal REDEPTID, string INTNUM, string CHRTITLE, string CHRDESC, decimal CLASSID, decimal TYPEID, decimal INTLEVEL, decimal USERID, decimal IS_CAI, DateTime DTAPPENDDDATE, decimal ISCHECK, decimal CHECKID, DateTime CHECKDATE, string SUBJECTID, string NAME, string CHRCLASS, decimal CATEGORYID, string CHRTYPE, string CHRTRUENAME, decimal ISGONE, string CHRNO, string FORMID, decimal ISERROR)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from INFO_ACCEPT_VIEW");
            strSql.Append(" where INFOID=:INFOID and DEPTID=:DEPTID and DTDATE=:DTDATE and REDEPTID=:REDEPTID and INTNUM=:INTNUM and CHRTITLE=:CHRTITLE and CHRDESC=:CHRDESC and CLASSID=:CLASSID and TYPEID=:TYPEID and INTLEVEL=:INTLEVEL and USERID=:USERID and IS_CAI=:IS_CAI and DTAPPENDDDATE=:DTAPPENDDDATE and ISCHECK=:ISCHECK and CHECKID=:CHECKID and CHECKDATE=:CHECKDATE and SUBJECTID=:SUBJECTID and NAME=:NAME and CHRCLASS=:CHRCLASS and CATEGORYID=:CATEGORYID and CHRTYPE=:CHRTYPE and CHRTRUENAME=:CHRTRUENAME and ISGONE=:ISGONE and CHRNO=:CHRNO and FORMID=:FORMID and ISERROR=:ISERROR ");
            OracleParameter[] parameters = {
                    new OracleParameter(":INFOID", OracleDbType.Int32,4),
                    new OracleParameter(":DEPTID", OracleDbType.Int32,4),
                    new OracleParameter(":DTDATE", OracleDbType.Date),
                    new OracleParameter(":REDEPTID", OracleDbType.Int32,4),
                    new OracleParameter(":INTNUM", OracleDbType.Varchar2,20),
                    new OracleParameter(":CHRTITLE", OracleDbType.Varchar2,512),
                    new OracleParameter(":CHRDESC", OracleDbType.Clob,4000),
                    new OracleParameter(":CLASSID", OracleDbType.Int32,4),
                    new OracleParameter(":TYPEID", OracleDbType.Int32,4),
                    new OracleParameter(":INTLEVEL", OracleDbType.Int32,4),
                    new OracleParameter(":USERID", OracleDbType.Int32,4),
                    new OracleParameter(":IS_CAI", OracleDbType.Int32,4),
                    new OracleParameter(":DTAPPENDDDATE", OracleDbType.Date),
                    new OracleParameter(":ISCHECK", OracleDbType.Int32,4),
                    new OracleParameter(":CHECKID", OracleDbType.Int32,4),
                    new OracleParameter(":CHECKDATE", OracleDbType.Date),
                    new OracleParameter(":SUBJECTID", OracleDbType.Varchar2,512),
                    new OracleParameter(":NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":CHRCLASS", OracleDbType.Varchar2,512),
                    new OracleParameter(":CATEGORYID", OracleDbType.Int32,4),
                    new OracleParameter(":CHRTYPE", OracleDbType.Varchar2,512),
                    new OracleParameter(":CHRTRUENAME", OracleDbType.Varchar2,50),
                    new OracleParameter(":ISGONE", OracleDbType.Int32,4),
                    new OracleParameter(":CHRNO", OracleDbType.Varchar2,20),
                    new OracleParameter(":FORMID", OracleDbType.Varchar2,50),
                    new OracleParameter(":ISERROR", OracleDbType.Int32,4)            };
            parameters[0].Value = INFOID;
            parameters[1].Value = DEPTID;
            parameters[2].Value = DTDATE;
            parameters[3].Value = REDEPTID;
            parameters[4].Value = INTNUM;
            parameters[5].Value = CHRTITLE;
            parameters[6].Value = CHRDESC;
            parameters[7].Value = CLASSID;
            parameters[8].Value = TYPEID;
            parameters[9].Value = INTLEVEL;
            parameters[10].Value = USERID;
            parameters[11].Value = IS_CAI;
            parameters[12].Value = DTAPPENDDDATE;
            parameters[13].Value = ISCHECK;
            parameters[14].Value = CHECKID;
            parameters[15].Value = CHECKDATE;
            parameters[16].Value = SUBJECTID;
            parameters[17].Value = NAME;
            parameters[18].Value = CHRCLASS;
            parameters[19].Value = CATEGORYID;
            parameters[20].Value = CHRTYPE;
            parameters[21].Value = CHRTRUENAME;
            parameters[22].Value = ISGONE;
            parameters[23].Value = CHRNO;
            parameters[24].Value = FORMID;
            parameters[25].Value = ISERROR;

            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.INFO_ACCEPT_VIEW GetModel(decimal INFOID, decimal DEPTID, DateTime DTDATE, decimal REDEPTID, string INTNUM, string CHRTITLE, string CHRDESC, decimal CLASSID, decimal TYPEID, decimal INTLEVEL, decimal USERID, decimal IS_CAI, DateTime DTAPPENDDDATE, decimal ISCHECK, decimal CHECKID, DateTime CHECKDATE, string SUBJECTID, string NAME, string CHRCLASS, decimal CATEGORYID, string CHRTYPE, string CHRTRUENAME, decimal ISGONE, string CHRNO, string FORMID, decimal ISERROR)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select INFOID,DEPTID,DTDATE,REDEPTID,INTNUM,CHRTITLE,CHRDESC,CLASSID,TYPEID,INTLEVEL,USERID,IS_CAI,DTAPPENDDDATE,ISCHECK,CHECKID,CHECKDATE,SUBJECTID,NAME,CHRCLASS,CATEGORYID,CHRTYPE,CHRTRUENAME,ISGONE,CHRNO,FORMID,ISERROR from INFO_ACCEPT_VIEW ");
            strSql.Append(" where INFOID=:INFOID and DEPTID=:DEPTID and DTDATE=:DTDATE and REDEPTID=:REDEPTID and INTNUM=:INTNUM and CHRTITLE=:CHRTITLE and CHRDESC=:CHRDESC and CLASSID=:CLASSID and TYPEID=:TYPEID and INTLEVEL=:INTLEVEL and USERID=:USERID and IS_CAI=:IS_CAI and DTAPPENDDDATE=:DTAPPENDDDATE and ISCHECK=:ISCHECK and CHECKID=:CHECKID and CHECKDATE=:CHECKDATE and SUBJECTID=:SUBJECTID and NAME=:NAME and CHRCLASS=:CHRCLASS and CATEGORYID=:CATEGORYID and CHRTYPE=:CHRTYPE and CHRTRUENAME=:CHRTRUENAME and ISGONE=:ISGONE and CHRNO=:CHRNO and FORMID=:FORMID and ISERROR=:ISERROR ");
            OracleParameter[] parameters = {
                    new OracleParameter(":INFOID", OracleDbType.Int32,4),
                    new OracleParameter(":DEPTID", OracleDbType.Int32,4),
                    new OracleParameter(":DTDATE", OracleDbType.Date),
                    new OracleParameter(":REDEPTID", OracleDbType.Int32,4),
                    new OracleParameter(":INTNUM", OracleDbType.Varchar2,20),
                    new OracleParameter(":CHRTITLE", OracleDbType.Varchar2,512),
                    new OracleParameter(":CHRDESC", OracleDbType.Clob,4000),
                    new OracleParameter(":CLASSID", OracleDbType.Int32,4),
                    new OracleParameter(":TYPEID", OracleDbType.Int32,4),
                    new OracleParameter(":INTLEVEL", OracleDbType.Int32,4),
                    new OracleParameter(":USERID", OracleDbType.Int32,4),
                    new OracleParameter(":IS_CAI", OracleDbType.Int32,4),
                    new OracleParameter(":DTAPPENDDDATE", OracleDbType.Date),
                    new OracleParameter(":ISCHECK", OracleDbType.Int32,4),
                    new OracleParameter(":CHECKID", OracleDbType.Int32,4),
                    new OracleParameter(":CHECKDATE", OracleDbType.Date),
                    new OracleParameter(":SUBJECTID", OracleDbType.Varchar2,512),
                    new OracleParameter(":NAME", OracleDbType.Varchar2,200),
                    new OracleParameter(":CHRCLASS", OracleDbType.Varchar2,512),
                    new OracleParameter(":CATEGORYID", OracleDbType.Int32,4),
                    new OracleParameter(":CHRTYPE", OracleDbType.Varchar2,512),
                    new OracleParameter(":CHRTRUENAME", OracleDbType.Varchar2,50),
                    new OracleParameter(":ISGONE", OracleDbType.Int32,4),
                    new OracleParameter(":CHRNO", OracleDbType.Varchar2,20),
                    new OracleParameter(":FORMID", OracleDbType.Varchar2,50),
                    new OracleParameter(":ISERROR", OracleDbType.Int32,4)            };
            parameters[0].Value = INFOID;
            parameters[1].Value = DEPTID;
            parameters[2].Value = DTDATE;
            parameters[3].Value = REDEPTID;
            parameters[4].Value = INTNUM;
            parameters[5].Value = CHRTITLE;
            parameters[6].Value = CHRDESC;
            parameters[7].Value = CLASSID;
            parameters[8].Value = TYPEID;
            parameters[9].Value = INTLEVEL;
            parameters[10].Value = USERID;
            parameters[11].Value = IS_CAI;
            parameters[12].Value = DTAPPENDDDATE;
            parameters[13].Value = ISCHECK;
            parameters[14].Value = CHECKID;
            parameters[15].Value = CHECKDATE;
            parameters[16].Value = SUBJECTID;
            parameters[17].Value = NAME;
            parameters[18].Value = CHRCLASS;
            parameters[19].Value = CATEGORYID;
            parameters[20].Value = CHRTYPE;
            parameters[21].Value = CHRTRUENAME;
            parameters[22].Value = ISGONE;
            parameters[23].Value = CHRNO;
            parameters[24].Value = FORMID;
            parameters[25].Value = ISERROR;

			Model.INFO_ACCEPT_VIEW model = new Model.INFO_ACCEPT_VIEW();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
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
        public Model.INFO_ACCEPT_VIEW DataRowToModel(DataRow row)
        {
			Model.INFO_ACCEPT_VIEW model = new Model.INFO_ACCEPT_VIEW();
            if (row != null)
            {
                if (row["INFOID"] != null && row["INFOID"].ToString() != "")
                {
                    model.INFOID = decimal.Parse(row["INFOID"].ToString());
                }
                if (row["DEPTID"] != null && row["DEPTID"].ToString() != "")
                {
                    model.DEPTID = decimal.Parse(row["DEPTID"].ToString());
                }
                if (row["DTDATE"] != null && row["DTDATE"].ToString() != "")
                {
                    model.DTDATE = DateTime.Parse(row["DTDATE"].ToString());
                }
                if (row["REDEPTID"] != null && row["REDEPTID"].ToString() != "")
                {
                    model.REDEPTID = decimal.Parse(row["REDEPTID"].ToString());
                }
                if (row["INTNUM"] != null)
                {
                    model.INTNUM = row["INTNUM"].ToString();
                }
                if (row["CHRTITLE"] != null)
                {
                    model.CHRTITLE = row["CHRTITLE"].ToString();
                }
                //model.CHRDESC=row["CHRDESC"].ToString();
                if (row["CLASSID"] != null && row["CLASSID"].ToString() != "")
                {
                    model.CLASSID = decimal.Parse(row["CLASSID"].ToString());
                }
                if (row["TYPEID"] != null && row["TYPEID"].ToString() != "")
                {
                    model.TYPEID = decimal.Parse(row["TYPEID"].ToString());
                }
                if (row["INTLEVEL"] != null && row["INTLEVEL"].ToString() != "")
                {
                    model.INTLEVEL = decimal.Parse(row["INTLEVEL"].ToString());
                }
                if (row["USERID"] != null && row["USERID"].ToString() != "")
                {
                    model.USERID = decimal.Parse(row["USERID"].ToString());
                }
                if (row["IS_CAI"] != null && row["IS_CAI"].ToString() != "")
                {
                    model.IS_CAI = decimal.Parse(row["IS_CAI"].ToString());
                }
                if (row["DTAPPENDDDATE"] != null && row["DTAPPENDDDATE"].ToString() != "")
                {
                    model.DTAPPENDDDATE = DateTime.Parse(row["DTAPPENDDDATE"].ToString());
                }
                if (row["ISCHECK"] != null && row["ISCHECK"].ToString() != "")
                {
                    model.ISCHECK = decimal.Parse(row["ISCHECK"].ToString());
                }
                if (row["CHECKID"] != null && row["CHECKID"].ToString() != "")
                {
                    model.CHECKID = decimal.Parse(row["CHECKID"].ToString());
                }
                if (row["CHECKDATE"] != null && row["CHECKDATE"].ToString() != "")
                {
                    model.CHECKDATE = DateTime.Parse(row["CHECKDATE"].ToString());
                }
                if (row["SUBJECTID"] != null)
                {
                    model.SUBJECTID = row["SUBJECTID"].ToString();
                }
                if (row["NAME"] != null)
                {
                    model.NAME = row["NAME"].ToString();
                }
                if (row["CHRCLASS"] != null)
                {
                    model.CHRCLASS = row["CHRCLASS"].ToString();
                }
                if (row["CATEGORYID"] != null && row["CATEGORYID"].ToString() != "")
                {
                    model.CATEGORYID = decimal.Parse(row["CATEGORYID"].ToString());
                }
                if (row["CHRTYPE"] != null)
                {
                    model.CHRTYPE = row["CHRTYPE"].ToString();
                }
                if (row["CHRTRUENAME"] != null)
                {
                    model.CHRTRUENAME = row["CHRTRUENAME"].ToString();
                }
                if (row["ISGONE"] != null && row["ISGONE"].ToString() != "")
                {
                    model.ISGONE = decimal.Parse(row["ISGONE"].ToString());
                }
                if (row["CHRNO"] != null)
                {
                    model.CHRNO = row["CHRNO"].ToString();
                }
                if (row["FORMID"] != null)
                {
                    model.FORMID = row["FORMID"].ToString();
                }
                if (row["ISERROR"] != null && row["ISERROR"].ToString() != "")
                {
                    model.ISERROR = decimal.Parse(row["ISERROR"].ToString());
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
            strSql.Append("select INFOID,DEPTID,DTDATE,REDEPTID,INTNUM,CHRTITLE,CHRDESC,CLASSID,TYPEID,INTLEVEL,USERID,IS_CAI,DTAPPENDDDATE,ISCHECK,CHECKID,CHECKDATE,SUBJECTID,NAME,CHRCLASS,CATEGORYID,CHRTYPE,CHRTRUENAME,ISGONE,CHRNO,FORMID,ISERROR ");
            strSql.Append(" FROM INFO_ACCEPT_VIEW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM INFO_ACCEPT_VIEW ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperOra.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.ISERROR desc");
            }
            strSql.Append(")AS Row, T.*  from INFO_ACCEPT_VIEW T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperOra.Query(strSql.ToString());
        }

       
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
