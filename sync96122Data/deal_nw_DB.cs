
using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using framework.utils;
using System.Threading;
using System.IO;

namespace sync96122Data
{
    public class deal_nw_DB
    {
        private string strMaxid; //内网96122 最大的
        private Dictionary<string, string> dicID_GUID;//全局存放两个系统对应的部门ID，交警内网的ID与民意中的GUID的对应
        public delegate void del_showlogs(string strContent);
        public event del_showlogs event_showLogs;
        /// <summary>
        /// 最大ID
        /// </summary>
        /// <param name="strMaxId"></param>
        public deal_nw_DB(string strMaxId)
        {
            strMaxid = strMaxId;
            dicID_GUID = initPartmentID(); 
        }
        /// <summary>
        /// 循环同步数据
        /// </summary>
        public void syncData_loop()
        {
            while (true)
            {
                try
                {
                    Get96122Data();
                    event_showLogs("本次同步96122数据完成，10分钟后继续……");
                    Thread.Sleep(10 * 60 * 1000);//10分钟同步一次数据
                }
                catch(Exception ex)
                {
                    event_showLogs("本次同步96122数据异常，100s后继续尝试……");
                    SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                    Thread.Sleep(100 * 1000);//线程等待100s
                    continue;
                }
            }
        }

        /// <summary>
        /// 获取96122数据并插入新民意系统对应的数据库中
        /// </summary>
        private void Get96122Data()
        {
            try
            {
                string strSql = $"select T.INFOID,t.deptid,t.dtdate,t.redeptid,t.intnum,t.chrtitle,t.dtappendddate,t.chrdesc,t.chrno,t.isgone from TRAFFIC_INFO t where isgone = -2 and deptid = 2341 and infoid >{strMaxid} order by t.infoid desc";
                DataSet dt96122 = DbHelperOra.Query(strSql); //获取某ID之上的所有数据
                event_showLogs("获取未同步数据信息");
                if (dt96122 == null || dt96122.Tables[0].Rows.Count <=0)
                {
                    event_showLogs("获取未同步数据信息为null");
                    return;
                }
                //1.遍历数据并转存到系统数据库
                foreach (DataRow dr in dt96122.Tables[0].Rows)
                {
                    try
                    {
                        //更新最大ID
                        using (FileStream fs = new FileStream("configs/maxid.txt", FileMode.Open, FileAccess.ReadWrite))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("UTF-8")))
                            {
                                sw.WriteLine(dr["INFOID"] + "");
                                sw.Close();
                                fs.Close();
                                // Class1 cl = new Class1();
                                event_showLogs("成功更新configs/maxid.txt最大ID："+ dr["INFOID"] );
                                SysLog.WriteOptDisk("成功更新configs/maxid.txt最大ID：" + dr["INFOID"], AppDomain.CurrentDomain.BaseDirectory, 100);
                            }
                        }
                    }
                    catch
                    {

                    }
                    //1 找到对应的新系统的GUID  
                    string strID = dr["redeptid"] + ""; //得到老系统的中的部门ID
                    string strNewPartId = ""; //新希望的部门ID
                    if (dicID_GUID.ContainsKey(strID))
                    {
                        strNewPartId = dicID_GUID[strID]; //得到字典中对应的ID
                    }
                    else
                    {
                        SysLog.WriteOptDisk("新系统为找到对应的部门ID老系统ID为"+ strID+ ";TRAFFIC_INFO表中INFOID为" + dr["INFOID"], AppDomain.CurrentDomain.BaseDirectory, 16);
                    }
                    //2  插入数据库
                    string StrGUID = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID
                    Model.CON_JLYEE model_96122 = new Model.CON_JLYEE();
                    model_96122.ID = StrGUID;
                    model_96122.JBRQ = Convert.ToDateTime(dr["dtdate"] + ""); //交办日期
                    model_96122.LXDH = "";//联系电话
                    model_96122.NRZR = dr["chrtitle"] + "";//内容标题
                    model_96122.SJBH = "";//上级编号
                    model_96122.SJR = "";//收件人
                    model_96122.SSLB = 0;//0 所属类别 0 其他
                    model_96122.ZT = 1; //状态 1
                    model_96122.FYRQ = Convert.ToDateTime(dr["dtdate"] + "");//反映日期
                    model_96122.FYR = "96122";//反映人
                    model_96122.FYNR = dr["chrdesc"] + ""; //反映内容
                    model_96122.FJDZ = ""; //附件地址
                    model_96122.CJSJ = DateTime.Now; //创建时间
                    model_96122.CJR = "96122"; //创建人  96122  510521aa-f5fc-4f06-bd58-c2696bda22e5
                    model_96122.BZ = "";//备注
                    model_96122.BT = dr["chrtitle"] + "";//标题
                    model_96122.BH = dr["chrno"] + ""; //编号
                    Model.ASSIGN model_assign = new Model.ASSIGN(); //ASSIGN 主表
                    model_assign.BZ = "";//备注空
                    model_assign.CJR = "96122";//创建人
                    model_assign.CJSJ = DateTime.Now;//创建时间
                    model_assign.HFNR = "";//各部门回复内容汇总
                    string strAssignId = Guid.NewGuid().ToString("N").ToUpper(); 
                    model_assign.ID = strAssignId;
                    model_assign.JBDW = strNewPartId;//交办单位
                    model_assign.JBRQ = Convert.ToDateTime(dr["dtdate"] + ""); //交办日期
                    model_assign.JBYQ = "";//交办要求
                    model_assign.LDPS = "";//领导批示
                    model_assign.MYLY = "510521AAF5FC4F06BD58C2696BDA22E5";//96122
                    model_assign.MYSJDX = StrGUID;//民意数据来源
                    model_assign.ZT = 1;
                    Model.INWORK model_inwork = new Model.INWORK();//处办表
                    model_inwork.CJR = "96122";//96122
                    model_inwork.CJSJ = DateTime.Now;//创建时间
                    model_inwork.ID = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID
                    model_inwork.ISTX = 0;
                    model_inwork.ISZB = 2;//1 是 2否  是否转办
                    model_inwork.JBDW = strNewPartId;//交办单位
                    model_inwork.JBSJ = strAssignId;//交办数据
                    model_inwork.ZT = 1; //状态


                    try
                    {
                        new BLL.CON_JLYEE().Add(model_96122); //新增96122数据
                        new BLL.ASSIGN().Add(model_assign);//assgin 
                        new BLL.INWORK().Add(model_inwork);//inwork 处办表
                        event_showLogs("成功更新民意数据库，对应96122 ID：" + dr["INFOID"]);
                     //   SysLog.WriteOptDisk("成功更新configs/maxid.txt最大ID" + dr["INFOID"], AppDomain.CurrentDomain.BaseDirectory, 100);

                    }
                    catch(Exception ex)
                    {
                        SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                    }


                }


            }
            catch (Exception ex)
            { //本地记录异常日志
                SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
            }
        }
        /// <summary>
        /// 初始化字典表
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> initPartmentID()
        {
            dicID_GUID = new Dictionary<string, string>();//实例化部门数据 ID 对应GUID
            try
            {
                string strSql = "select t.ID,NAME,GID from TRAFFIC_DEPARTMENT t where t.gid is not null";
                DataSet ds = DbHelperOra_new.Query(strSql);//获取部门ID GUID对应字段
                if (ds == null|| ds.Tables[0].Rows.Count<=0)
                {
                    SysLog.WriteOptDisk("获取部门ID对应GUID为空", AppDomain.CurrentDomain.BaseDirectory, 100);
                    return null;
                }
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if (!dicID_GUID.ContainsKey(dr["ID"] + ""))
                    {
                        dicID_GUID.Add(dr["ID"] + "", dr["GID"] + "");
                    }
                }
                SysLog.WriteOptDisk("获取部门ID对应GUID成功", AppDomain.CurrentDomain.BaseDirectory, 100);
                return dicID_GUID;
            }
            catch (Exception ex)
            {
                //记录异常日志
                SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                return null;
            }
        }
    }
}
