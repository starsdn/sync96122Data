using DBUtility;
using framework.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;

namespace syncPlatformData
{
    public class deal_nw_DB
    {
        private string strMaxid; //同步到 最大的 id

        private Dictionary<string, string> dicDEPID_GUID;//全局存放两个系统对应的部门ID，民意一期的ID与民意二期的GUID的对应

        private Dictionary<string, string> dicFYLXID_CODE;//全局存放两个系统对应的反映类型，民意一期的ID与民意二期的CODE的对应

        public delegate void del_showlogs(string strContent);
        public event del_showlogs event_showLogs;

        /// <summary>
        /// 同步到 最大的 id
        /// </summary>
        /// <param name="strMaxId"></param>
        public deal_nw_DB(string strMaxId)
        {
            strMaxid = strMaxId;
            initDepartDic();//初始化部门字典，民意一期的ID与民意二期的GUID的对应
            initFYLXDic();//初始化反映类型字典，民意一期的ID与民意二期的CODE的对应
        }

        public void syncData_loop()
        {
            bool bloop = true;
            while (bloop)
            {
                try
                {
                    GetPlatformData();
                    event_showLogs("本次同步民意一期数据完成……");
                    Thread.Sleep(10 * 1000);//线程等待10s
                }
                catch (Exception ex)
                {
                    event_showLogs("本次同步民意一期数据异常，100s后继续尝试……");
                    SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                    Thread.Sleep(100 * 1000);//线程等待100s
                    continue;
                }
            }
        }
        /// <summary>
        /// 获取民意一期数据并插入新民意系统对应的数据库中
        /// </summary>
        private void GetPlatformData()
        {
            try
            {

                string strSql = $"select top 1000 * from Data_processingissues t where  id >{strMaxid} order by id";//每次读取1000条数据
                DataSet dt_MY1 = DbHelperSQL.Query(strSql); //获取某ID之上的所有数据
                event_showLogs("获取民意一期数据未同步数据信息");
                if (dt_MY1 == null || dt_MY1.Tables[0].Rows.Count <= 0)
                {
                    event_showLogs("获取民意一期数据未同步数据信息为null");
                    return;
                }
                //1.遍历数据并转存到系统数据库
                foreach (DataRow dr in dt_MY1.Tables[0].Rows)
                {

                    //id 
                    //SourceID 数据来源ID
                    //OriginalsystemID 原系统ID
                    //Originalsystemnum 原系统编号
                    //Reaction_People 反应人
                    //Contact_Phone 联系手机
                    //Summary 内容提要
                    //Types 反应类型
                    //Reaction_Date 反映日期
                    //Assigned_Date 交办日期
                    //Applyperiod 办理期限
                    //Reply_Content 答复内容
                    //Whetherabnormal 是否异常数据 没数据
                    //SMSevaluation 短信评价       没数据
                    //TakeState 接办状态           没数据
                    //state                        没数据
                    //Create_People
                    //Create_Date
                    //Modify_People
                    //Modify_Date
                    //Remarks 备注
                    //Serialnumber 编号
                    //SponsorID 承办单位ID
                    //SummaryFile 内容提要附件
                    //Reply_ContentFile 答复内容附件
                    //SummaryFileold
                    //Reply_ContentFileold
                    //SJR
                    //ZHAIYAO 摘要
                    //YXTFJ

                    string SourceID = dr["SOURCEID"].ToString();//数据来源ID
                    string mylyguid = string.Empty;//二期民意来源guid
                    switch (SourceID)
                    {
                        //6062178399694A078E1AACF5FDD9F481 寒山闻钟论坛----------支队寒山闻钟
                        //0E8E2D480578471EAB622AC8DDC2A874 12345热线-------------支队政风行风
                        //510521AAF5FC4F06BD58C2696BDA22E5 96122-----------------96122工单
                        //7B8F5B74C09243FA9E2B5540B708761D 纪委条线--------------市局纪委
                        //58EAE7497C054DBCB3241A15C9336795 信访条线--------------市局信访处
                        //EA6859A55E7A44289A6B589D887C61AC 省厅、总队信件办理----其他
                        //09B7732CDBEA4009A1FA9DC5166B7690 督察条线来信----------市局督察
                        //BED2CF750A634A9D876262BB670A3A39 支队信件转办----------支队
                        //0C51C38CFF464CB4B839FA663C181CDE 其他自选项------------分局寒山闻钟、分局政风行风

                        case "1":   //支队寒山闻钟
                            mylyguid = "6062178399694A078E1AACF5FDD9F481"; break;
                        case "2":   //支队政风行风
                            mylyguid = "0E8E2D480578471EAB622AC8DDC2A874"; break;
                        case "3":   //96122工单
                            mylyguid = "510521AAF5FC4F06BD58C2696BDA22E5"; break;
                        case "5":   //分局寒山闻钟
                            mylyguid = "0C51C38CFF464CB4B839FA663C181CDE"; break;
                        case "6":   //分局政风行风
                            mylyguid = "0C51C38CFF464CB4B839FA663C181CDE"; break;
                        case "7":   //市局信访处
                            mylyguid = "58EAE7497C054DBCB3241A15C9336795"; break;
                        case "8":   //市局纪委
                            mylyguid = "7B8F5B74C09243FA9E2B5540B708761D"; break;
                        case "9":   //1号窗口
                            mylyguid = ""; break;
                        case "10":   //市局平安民声
                            mylyguid = ""; break;
                        case "11":   //支队
                            mylyguid = "BED2CF750A634A9D876262BB670A3A39"; break;
                        case "12":   //市局督查
                            mylyguid = "09B7732CDBEA4009A1FA9DC5166B7690"; break;
                        case "13":   //其他
                            mylyguid = "EA6859A55E7A44289A6B589D887C61AC"; break;
                        default: break;
                    }

                    if (string.IsNullOrWhiteSpace(mylyguid)) continue;

                    #region 添加民意档案数据
                    string con_guid = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID

                    #endregion

                    #region 添加交办数据
                    string assign_guid = Guid.NewGuid().ToString("N").ToUpper();//得到32位大写的 GUID
                    Model.ASSIGN model_assign = new Model.ASSIGN(); //ASSIGN 主表
                    model_assign.BZ = "";//备注空
                    model_assign.CJR = "民意一期";//创建人
                    model_assign.CJSJ = DateTime.Now;//创建时间
                    model_assign.HFNR = "";//各部门回复内容汇总
                    model_assign.ID = assign_guid;
                    model_assign.JBDW = "";//交办单位
                    model_assign.JBRQ = Convert.ToDateTime(dr["assigned_date"] + ""); //交办日期
                    model_assign.JBYQ = "";//交办要求
                    model_assign.LDPS = "";//领导批示
                    model_assign.MYLY = mylyguid;//96122
                    model_assign.MYSJDX = con_guid;//民意数据来源
                    model_assign.ZT = 5; //已办结
                    #endregion

                    #region 添加处办数据
                    string inwork_guid = Guid.NewGuid().ToString("N").ToUpper();//得到32位大写的 GUID
                    Model.INWORK model_inwork = new Model.INWORK();//处办表
                    model_inwork.ID = inwork_guid;
                    model_inwork.CJR = "民意一期";//创建人
                    model_inwork.CJSJ = DateTime.Now;//创建时间
                    model_inwork.ISTX = 0;
                    model_inwork.ISZB = 2;//1 是 2否  是否转办
                    model_inwork.JBDW = "";//交办单位
                    model_inwork.JBSJ = assign_guid;//交办数据
                    model_inwork.ZT = 6; //状态 已办结
                    #endregion

                    #region 添加部门答复数据
                    Model.REPLY_RECORD model_reply = new Model.REPLY_RECORD();
                    model_reply.ID = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID

                    model_reply.CBID = inwork_guid;//处办id
                    model_reply.HFNR = dr["REPLY_CONTENT"].ToString();//回复内容
                    model_reply.ZT = 1;//状态
                    model_reply.CJR = "民意一期";//创建人
                    model_reply.CJSJ = DateTime.Now;//创建时间
                    model_reply.CBLX = 1;//处办类型
                    model_reply.FJDZ = "";//附件地址
                    model_reply.FJM = "";//附件名
                    #endregion

                    #region 添加上报数据
                    Model.ASSIGN_UPREPORT model_upreport = new Model.ASSIGN_UPREPORT();
                    #endregion

                    #region 添加上报附件数据

                    #endregion

                    #region 添加时间轴数据

                    #endregion

                    #region 更新最大ID
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
                                event_showLogs("成功更新configs/maxid.txt最大ID：" + dr["INFOID"]);
                                SysLog.WriteOptDisk("成功更新configs/maxid.txt最大ID：" + dr["INFOID"], AppDomain.CurrentDomain.BaseDirectory, 100);
                            }
                        }
                    }
                    catch
                    { }
                    #endregion
                }
            }
            catch
            {

            }
        }


        #region 初始化字典

        /// <summary>
        /// 部门字典，全局存放两个系统对应的部门ID，民意一期的ID与民意二期的GUID的对应
        /// </summary>
        /// <returns></returns>
        private void initDepartDic()
        {
            dicDEPID_GUID = new Dictionary<string, string>();//实例化部门数据 ID 对应GUID
            try
            {
                DataSet ds = new BLL.ZZ_DIC_UNDERTAKER().GetList("guid is not null");//获取部门ID GUID对应字段
                if (ds == null || ds.Tables[0].Rows.Count <= 0)
                {
                    SysLog.WriteOptDisk("获取部门   ID对应GUID为空", AppDomain.CurrentDomain.BaseDirectory, 100);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!dicDEPID_GUID.ContainsKey(dr["ID"].ToString()))
                    {
                        dicDEPID_GUID.Add(dr["ID"].ToString(), dr["GUID"].ToString());
                    }
                }
                SysLog.WriteOptDisk("获取部门   ID对应GUID成功", AppDomain.CurrentDomain.BaseDirectory, 100);
            }
            catch (Exception ex)
            {
                //记录异常日志
                SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
            }
        }


        /// <summary>
        /// 反映类型字典，全局存放两个系统对应的反映类型，民意一期的ID与民意二期的CODE的对应
        /// </summary>
        /// <returns></returns>
        private void initFYLXDic()
        {
            dicFYLXID_CODE = new Dictionary<string, string>();//实例化反映类型  ID对应CODE
            try
            {
                DataSet ds = new BLL.ZZ_DIC_MATTERSCATEGORY().GetList("");//获取反映类型   ID对应CODE对应字段
                if (ds == null || ds.Tables[0].Rows.Count <= 0)
                {
                    SysLog.WriteOptDisk("获取反映类型   ID对应CODE为空", AppDomain.CurrentDomain.BaseDirectory, 100);
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!dicFYLXID_CODE.ContainsKey(dr["ID"].ToString()))
                    {
                        dicFYLXID_CODE.Add(dr["ID"].ToString(), dr["CODE"].ToString());
                    }
                }
                SysLog.WriteOptDisk("获取反映类型   ID对应CODE成功", AppDomain.CurrentDomain.BaseDirectory, 100);
            }
            catch (Exception ex)
            {
                //记录异常日志
                SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        #endregion
    }
}
