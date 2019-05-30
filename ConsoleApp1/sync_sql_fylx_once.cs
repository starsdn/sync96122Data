using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// 同步
    /// </summary>
    public class sync_sql_fylx_once
    {
        private string strInsertSql = "";
        private int iId = 1; //自增ID


        public string getInsertSql()
        {
            string strSql = mainSync();
            return strSql;
        }

        private string syncFYLY(string id, string strCode)
        {
            string strSQL = $"select ID,NAMES,CategoryID,CategoryLevel FROM DIC_Matterscategory where CategoryID={id}";
            DataTable dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];//得到对应的sql
            if (dt != null && dt.Rows.Count > 0) //如果有数据
            {
                StringBuilder sb = new StringBuilder();
                int icurr = 1;
                foreach (DataRow dr in dt.Rows)
                {
                   
                    string strsql = $"insert into SYS_FYLXBASEDATA(ID,NAME,PARENT_CODE,BASELEVEL,STATE,CODE,REMARK,CREATETIME,CREATOR) values ({iId++},'{dr["NAMES"] + ""}','{strCode}','{dr["CategoryLevel"] + ""}',1,'{strCode + icurr.ToString("00")}','',sysdate,'sys');";
                    sb.AppendLine(strsql);
                    sb.AppendLine(syncFYLY(dr["ID"] + "", strCode + icurr.ToString("00")));
                    icurr++;
                }
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }

        private string mainSync()
        {
            string strSQL = $"select ID,NAMES,CategoryID,CategoryLevel FROM DIC_Matterscategory where ID in (55,56,57,58,59,60,245)";
            DataTable dt = DBUtility.DbHelperSQL.Query(strSQL).Tables[0];//得到对应的sql
            if (dt != null && dt.Rows.Count > 0) //如果有数据
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    string code;
                    switch (dr["ID"] + "")
                    {
                        case "55":
                            code = "01";
                            break;
                        case "56":
                            code = "02";
                            break;
                        case "57":
                            code = "03";
                            break;
                        case "58":
                            code = "04";
                            break;
                        case "59":
                            code = "05";
                            break;
                        case "60":
                            code = "06";
                            break;
                        case "245":
                            code = "99";
                            break;
                        default:
                            code = "99";
                            break;

                    }
                    string strsql = $"insert into SYS_FYLXBASEDATA(ID,NAME,PARENT_CODE,BASELEVEL,STATE,CODE,REMARK,CREATETIME,CREATOR) values ({iId++},'{dr["NAMES"] + ""}','','{dr["CategoryLevel"] + ""}',1,'{code}','',sysdate,'sys');";
                   
                    sb.AppendLine(strsql);
                    sb.AppendLine(syncFYLY(dr["ID"] + "", code));
                   // return strsql;
                }
                return sb.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
