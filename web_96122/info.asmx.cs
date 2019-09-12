using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using System.Web;
using System.Web.Services;
using web_96122.DBHelper;

namespace web_96122
{
    /// <summary>
    /// info 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class info : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 96122调用此接口插入数据
        /// </summary>
        /// <param name="intNum"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="redeptid"></param>
        /// <returns></returns>
        [WebMethod]
        public int AddInfo(string intNum, string title, string content, string redeptid)
        {
            //获取交办单位在新民意中对应的guid
            string depguid = string.Empty;
            string depsql = "select gid from TRAFFIC_DEPARTMENT t where id='2341'";
            DataSet depDS = DbHelperOra.Query(depsql);

            if (depDS != null && depDS.Tables[0] != null && depDS.Tables[0].Rows.Count > 0)
            {
                depguid = depDS.Tables[0].Rows[0][0].ToString();
            }

            if (!string.IsNullOrEmpty(depguid))
            {
                try
                {
                    #region 民意档案
                    string con_guid = Guid.NewGuid().ToString("N").ToUpper(); //民意档案id
                    AddJLYEE(con_guid, title, content, intNum);
                    #endregion

                    #region 交办
                    string assign_guid = Guid.NewGuid().ToString("N").ToUpper();//交办id
                    AddAssign(assign_guid, con_guid, depguid);
                    #endregion

                    #region 处办
                    string inwork_guid = Guid.NewGuid().ToString("N").ToUpper();//处办id
                    AddInwork(inwork_guid, assign_guid, depguid);
                    #endregion
                    return 1;
                }
                catch (Exception e)
                {
                    sysLog.WriteOptDisk("添加新民意数据异常【error】" + e.Message + e.StackTrace);
                }
            }
            else
            {
                sysLog.WriteOptDisk("未获取到交办单位guid");
            }
            return 0;  //0 失败  1成功
        }

        #region 将数据插入新民意
        /// <summary>
        /// 添加民意档案数据
        /// </summary>
        /// <param name="con_guid">民意档案id</param>
        /// <param name="title">标题</param>
        /// <param name="content">反映内容</param>
        /// <param name="intnum">96122formid</param>
        /// <returns></returns>
        private int AddJLYEE(string con_guid, string title, string content, string intnum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CON_JLYEE(");
            strSql.Append("ID,BH,BT,FYNR,JBRQ,CJR,CJSJ,ZT,FYRQ,INTNUM)");
            strSql.Append(" values (");
            strSql.Append(":ID,:BH,:BT,:FYNR,:JBRQ,:CJR,:CJSJ,:ZT,:FYRQ,:INTNUM)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":BH", OracleType.VarChar,100),
                    new OracleParameter(":BT", OracleType.VarChar,500),
                    new OracleParameter(":FYNR", OracleType.Clob),
                    new OracleParameter(":JBRQ", OracleType.DateTime),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime),
                    new OracleParameter(":ZT", OracleType.Int32,1),
                    new OracleParameter(":FYRQ", OracleType.DateTime),
                    new OracleParameter(":INTNUM",OracleType.VarChar,50)};
            parameters[0].Value = con_guid;
            parameters[1].Value = intnum;
            parameters[2].Value = title;
            parameters[3].Value = content;
            parameters[4].Value = DateTime.Now;
            parameters[5].Value = "96122";
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = 1;
            parameters[8].Value = DateTime.Now;
            parameters[9].Value = intnum;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 添加交办数据
        /// </summary>
        /// <param name="assign_guid">交办id</param>
        /// <param name="con_guid">民意档案id</param>
        /// <param name="jbdw">交办单位</param>
        /// <returns></returns>
        private int AddAssign(string assign_guid, string con_guid, string jbdw)
        {
            StringBuilder insertSql_assign = new StringBuilder();
            insertSql_assign.Append("insert into ASSIGN(");
            insertSql_assign.Append("ID,MYSJDX,MYLY,JBRQ,JBDW,ZT,CJR,CJSJ)");
            insertSql_assign.Append(" values (");
            insertSql_assign.Append(":ID,:MYSJDX,:MYLY,:JBRQ,:JBDW,:ZT,:CJR,:CJSJ)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":MYSJDX", OracleType.VarChar,36),
                    new OracleParameter(":MYLY", OracleType.VarChar,36),
                    new OracleParameter(":JBRQ", OracleType.DateTime),
                    new OracleParameter(":JBDW", OracleType.VarChar,2000),
                    new OracleParameter(":ZT", OracleType.Int32,4),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime)
                };
            parameters[0].Value = assign_guid;
            parameters[1].Value = con_guid;
            parameters[2].Value = "510521AAF5FC4F06BD58C2696BDA22E5";
            parameters[3].Value = DateTime.Now;
            parameters[4].Value = jbdw;
            parameters[5].Value = 1;
            parameters[6].Value = "96122";
            parameters[7].Value = DateTime.Now;
            int rows = DbHelperOra.ExecuteSql(insertSql_assign.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 添加处办数据
        /// </summary>
        /// <param name="inworkid">处办id</param>
        /// <param name="assignid">交办id</param>
        /// <param name="jbdw">交办单位</param>
        /// <returns></returns>
        private int AddInwork(string inworkid, string assignid, string jbdw)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into INWORK(");
            strSql.Append("ID,JBSJ,JBDW,ZT,CJR,CJSJ)");
            strSql.Append(" values (");
            strSql.Append(":ID,:JBSJ,:JBDW,:ZT,:CJR,:CJSJ)");
            OracleParameter[] parameters = {
                    new OracleParameter(":ID", OracleType.VarChar,36),
                    new OracleParameter(":JBSJ", OracleType.VarChar,36),
                    new OracleParameter(":JBDW", OracleType.VarChar,36),
                    new OracleParameter(":ZT", OracleType.Int32,4),
                    new OracleParameter(":CJR", OracleType.VarChar,36),
                    new OracleParameter(":CJSJ", OracleType.DateTime)};
            parameters[0].Value = inworkid;
            parameters[1].Value = assignid;
            parameters[2].Value = jbdw;
            parameters[3].Value = 1;
            parameters[4].Value = "96122";
            parameters[5].Value = DateTime.Now;

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        #endregion
    }
}
