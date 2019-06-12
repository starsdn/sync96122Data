using DBUtility;
using framework.utils;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        private string FJ_baseurl = string.Empty;//附件基础地址

        public delegate void del_showlogs(string strContent);
        public event del_showlogs event_showLogs;

        /// <summary>
        /// 同步到 最大的 id
        /// </summary>
        /// <param name="strMaxId"></param>
        public deal_nw_DB(string strMaxId)
        {
            strMaxid = strMaxId;
            FJ_baseurl = ConfigurationManager.ConnectionStrings["FJ_baseurl"].ConnectionString;
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
                    string SourceID = dr["SOURCEID"].ToString();//数据来源ID
                    string mylyguid = string.Empty;//二期民意来源guid
                    int upReportMyly = 0;//上报民意来源对应number
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

                        // 1寒山闻钟论坛；2：12345热线；3纪委条线；4：信访条线；5省厅、总队信件办理；6督察条线来信；7支队信件转办；8其他自选项；9：96122

                        case "1":   //支队寒山闻钟
                            mylyguid = "6062178399694A078E1AACF5FDD9F481"; upReportMyly = 1; break;
                        case "2":   //支队政风行风
                            mylyguid = "0E8E2D480578471EAB622AC8DDC2A874"; upReportMyly = 2; break;
                        case "3":   //96122工单
                            mylyguid = "510521AAF5FC4F06BD58C2696BDA22E5"; upReportMyly = 9; break;
                        case "5":   //分局寒山闻钟
                            mylyguid = "0C51C38CFF464CB4B839FA663C181CDE"; upReportMyly = 8; break;
                        case "6":   //分局政风行风
                            mylyguid = "0C51C38CFF464CB4B839FA663C181CDE"; upReportMyly = 8; break;
                        case "7":   //市局信访处
                            mylyguid = "58EAE7497C054DBCB3241A15C9336795"; upReportMyly = 4; break;
                        case "8":   //市局纪委
                            mylyguid = "7B8F5B74C09243FA9E2B5540B708761D"; upReportMyly = 3; break;
                        case "9":   //1号窗口
                            mylyguid = ""; break;
                        case "10":   //市局平安民声
                            mylyguid = ""; break;
                        case "11":   //支队
                            mylyguid = "BED2CF750A634A9D876262BB670A3A39"; upReportMyly = 7; break;
                        case "12":   //市局督查
                            mylyguid = "09B7732CDBEA4009A1FA9DC5166B7690"; upReportMyly = 6; break;
                        case "13":   //其他
                            mylyguid = "EA6859A55E7A44289A6B589D887C61AC"; upReportMyly = 5; break;
                        default: break;
                    }

                    if (string.IsNullOrWhiteSpace(mylyguid)) continue;


                    string jbdw_MY1 = dr["SPONSORID"].ToString(); //承办单位
                    //如遇有多个承办单位，则取第一个为交办单位
                    if (jbdw_MY1.IndexOf(",") >= 0)
                    {
                        jbdw_MY1 = jbdw_MY1.Substring(0, jbdw_MY1.LastIndexOf(","));
                    }
                    string jbdw_MY2 = string.Empty;//民意二期交办单位
                    if (dicDEPID_GUID.ContainsKey(jbdw_MY1))
                    {
                        jbdw_MY2 = dicDEPID_GUID[jbdw_MY1]; //得到字典中对应的ID
                    }

                    //添加民意档案数据
                    string con_guid = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID
                    bool conres = MYDangan(con_guid, dr);
                    // 添加交办数据
                    string assign_guid = Guid.NewGuid().ToString("N").ToUpper();//得到32位大写的 GUID
                    Model.ASSIGN model_assign = AssignModel(assign_guid, mylyguid, con_guid, jbdw_MY2, dr);

                    //添加处办数据
                    string inwork_guid = Guid.NewGuid().ToString("N").ToUpper();//得到32位大写的 GUID
                    Model.INWORK model_inwork = InworkModel(assign_guid, inwork_guid, jbdw_MY2, dr);

                    //添加部门答复数据
                    Model.REPLY_RECORD model_reply = ReplyModel(inwork_guid, dr);

                    //添加上报数据
                    string upreport_guid = Guid.NewGuid().ToString("N").ToUpper();//得到32位大写的 GUID
                    Model.ASSIGN_UPREPORT model_upreport = UpReportModel(assign_guid, upreport_guid, upReportMyly, dr);

                    // 添加上报附件数据
                    string fjdz = dr["REPLY_CONTENTFILE"].ToString();//答复附件地址
                    if (!string.IsNullOrWhiteSpace(fjdz))
                    {
                        Model.ASSIGN_UPFJ model_upfj = UpFJModel(upreport_guid, dr);
                        bool upfjres = new BLL.ASSIGN_UPFJ().Add(model_upfj);
                    }
                    // 添加时间轴数据


                    try
                    {
                        bool assignres = new BLL.ASSIGN().Add(model_assign);
                        bool inworkres = new BLL.INWORK().Add(model_inwork);
                        bool replyres = new BLL.REPLY_RECORD().Add(model_reply);
                        bool upreportres = new BLL.ASSIGN_UPREPORT().Add(model_upreport);
                        event_showLogs("成功更新民意数据库，对应ID：" + dr["ID"]);
                    }
                    catch (Exception ex)
                    {
                        SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                    }
                    #region 更新最大ID
                    try
                    {
                        //更新最大ID
                        using (FileStream fs = new FileStream("configs/maxid.txt", FileMode.Open, FileAccess.ReadWrite))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("UTF-8")))
                            {
                                sw.WriteLine(dr["ID"] + "");
                                sw.Close();
                                fs.Close();
                                // Class1 cl = new Class1();
                                event_showLogs("成功更新configs/maxid.txt最大ID：" + dr["ID"]);
                                SysLog.WriteOptDisk("成功更新configs/maxid.txt最大ID：" + dr["ID"], AppDomain.CurrentDomain.BaseDirectory, 100);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                SysLog.WriteLog(ex, AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        #region model

        #region 民意档案
        private bool MYDangan(string con_guid, DataRow dr)
        {
            try
            {
                string SourceID = dr["SOURCEID"].ToString();//数据来源ID
                string fyrqstr = dr["REACTION_DATE"].ToString();//反映日期    
                string jbrqstr = dr["ASSIGNED_DATE"].ToString();//交办日期
                string blqxstr = dr["APPLYPERIOD"].ToString();//办理期限
                string fjdz = dr["SUMMARYFILEOLD"].ToString();//反映内容附件地址
                if (!string.IsNullOrWhiteSpace(fjdz))
                {
                    fjdz = FJ_baseurl + fjdz;
                }
                switch (SourceID)
                {
                    // 寒山闻钟论坛----------支队寒山闻钟
                    // 12345热线-------------支队政风行风
                    // 96122-----------------96122工单
                    // 纪委条线--------------市局纪委
                    // 信访条线--------------市局信访处
                    // 省厅、总队信件办理----其他
                    // 督察条线来信----------市局督察
                    // 支队信件转办----------支队
                    // 其他自选项------------分局寒山闻钟、分局政风行风

                    case "1":   //支队寒山闻钟---寒山闻钟论坛
                        #region  寒山闻钟论坛
                        Model.CON_HSWZ hswz_model = new Model.CON_HSWZ();
                        hswz_model.ID = con_guid;//主键ID（32位或36位guid）
                        hswz_model.BH = dr["SERIALNUMBER"].ToString();//编号
                        //hswz_model.BT = "";//标题
                        hswz_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            hswz_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        //hswz_model.FYLX = "";//反映类型
                        hswz_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        hswz_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //hswz_model.YQ = "";//要求
                        hswz_model.FJDZ = fjdz;//附件地址
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            hswz_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            hswz_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //hswz_model.JBYQ = "";//交办要求
                        //hswz_model.LDPS = "";//领导批示
                        //hswz_model.BZ = "";//备注
                        hswz_model.CJR = "民意一期";//创建人
                        hswz_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        hswz_model.ZT = 1;// 状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        //hswz_model.FPSJ = null;//分配时间
                        hswz_model.FJM = dr["SUMMARYFILE"].ToString();//附件名
                        bool hswz_res = new BLL.CON_HSWZ().Add(hswz_model);
                        return hswz_res;
                    #endregion
                    case "2":   //支队政风行风---12345热线
                        #region 12345热线
                        Model.CON_YESSW yessw_model = new Model.CON_YESSW();
                        yessw_model.ID = con_guid;//主键ID（32位或36位guid）
                        yessw_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        yessw_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        yessw_model.LDR = dr["REACTION_PEOPLE"].ToString();//来电人
                        yessw_model.LXDH = dr["CONTACT_PHONE"].ToString();//联系电话
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            yessw_model.FYRQ = Convert.ToDateTime(fyrqstr);//来电日期
                        }
                        //yessw_model.FYLX = "";//反映类型
                        yessw_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        yessw_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        yessw_model.FJDZ = fjdz;//附件地址
                        //yessw_model.YQ = "";//要求
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            yessw_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            yessw_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //yessw_model.JBYQ = "";//交办要求
                        yessw_model.FPSJ = null;//分配时间
                        //yessw_model.BZ = "";//备注
                        //yessw_model.LDPS = "";//领导批示
                        yessw_model.CJR = "民意一期";//创建人
                        yessw_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间（时间格式，便于数据库查看）
                        yessw_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        //yessw_model.XBDW = "";//协办单位
                        yessw_model.FJM = dr["SUMMARYFILE"].ToString();//附件名
                        bool yessw_res = new BLL.CON_YESSW().Add(yessw_model);
                        return yessw_res;
                    #endregion
                    case "3":   //96122工单---96122
                        #region 96122
                        Model.CON_JLYEE jlyee_model = new Model.CON_JLYEE();
                        jlyee_model.ID = con_guid;// 主键ID（32位或36位guid）
                        jlyee_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        jlyee_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        jlyee_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        jlyee_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            jlyee_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        //jlyee_model.SJR = "";//收件人
                        //jlyee_model.BT = "";//标题
                        jlyee_model.NRZR = dr["ZHAIYAO"].ToString();//内容摘要
                        jlyee_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        jlyee_model.FJDZ = fjdz;//附件地址
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            jlyee_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //jlyee_model.BJRQ = null;//办结日期
                        jlyee_model.SSLB = 0;//所属类别0.其他 1.投诉  2.建议 3.咨询 4.举报 5.求助 6.表扬
                        //jlyee_model.BZ = "";//备注
                        jlyee_model.CJR = "民意一期";//创建人
                        jlyee_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        jlyee_model.ZT = 1;//状态( 0.删除 1.有效)
                                           //jlyee_model.XJLY = "";// 信件来源
                        bool jlyee_res = new BLL.CON_JLYEE().Add(jlyee_model);
                        return jlyee_res;
                    #endregion
                    case "5":   //分局寒山闻钟---其他自选项
                    case "6":   //分局政风行风---其他自选项
                        #region 其他自选项
                        Model.CON_QTZXX qtzxx_model = new Model.CON_QTZXX();
                        qtzxx_model.ID = con_guid;//键ID（32位或36位guid）
                        qtzxx_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        qtzxx_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        qtzxx_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        qtzxx_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //qtzxx_model.DZYJ = "";//电子邮件
                        //qtzxx_model.DZ = "";//地址
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            qtzxx_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            qtzxx_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //qtzxx_model.BT = "";//标题
                        qtzxx_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        qtzxx_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //qtzxx_model.YQ = "";//要求
                        qtzxx_model.FJDZ = fjdz;//附件地址
                        //qtzxx_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            qtzxx_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //qtzxx_model.JBYQ = "";//交办要求
                        //qtzxx_model.LDPS = "";//领导批示
                        //qtzxx_model.BZ = "";//备注
                        qtzxx_model.CJR = "民意一期";//创建人
                        qtzxx_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        qtzxx_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        qtzxx_model.FJM = dr["SUMMARYFILE"].ToString();//附件名
                                                                       //qtzxx_model.XJLY = "";//信件来源
                        bool qtzxx_res = new BLL.CON_QTZXX().Add(qtzxx_model);
                        return qtzxx_res;
                    #endregion
                    case "7":   //市局信访处---信访条线
                        #region 信访条线
                        Model.CON_XFTX xftx_model = new Model.CON_XFTX();
                        xftx_model.ID = con_guid;// 主键ID（32位或36位guid）
                        //xftx_model.XJLY = "";// 信件来源
                        xftx_model.BH = dr["SERIALNUMBER"].ToString();  //编号
                        xftx_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        xftx_model.XFR = dr["REACTION_PEOPLE"].ToString();//信访人
                        xftx_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //xftx_model.DZYJ = "";//电子邮件
                        //xftx_model.DZ = "";//地址
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            xftx_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            xftx_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //xftx_model.BT = "";//标题
                        xftx_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        xftx_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //xftx_model.YQ = "";//要求
                        xftx_model.FJDZ = fjdz;//反应内容附件
                                               // xftx_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            xftx_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //xftx_model.JBYQ = "";//交办要求
                        //xftx_model.LDPS = "";//领导批示
                        //xftx_model.BZ = "";//备注
                        xftx_model.CJR = "民意一期";//创建人
                        xftx_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        xftx_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        xftx_model.FJM = dr["SUMMARYFILE"].ToString();//附件名

                        bool xftx_res = new BLL.CON_XFTX().Add(xftx_model);
                        return xftx_res;
                    #endregion
                    case "8":   //市局纪委---纪委条线
                        #region 纪委条线
                        Model.CON_JWTX jwtx_model = new Model.CON_JWTX();
                        jwtx_model.ID = con_guid;//主键ID（32位或36位guid）
                        jwtx_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        jwtx_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        jwtx_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        jwtx_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //jwtx_model.DZ = "";//地址
                        //jwtx_model.DZYJ = "";//电子邮件
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            jwtx_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            jwtx_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //jwtx_model.BT = "";//标题
                        jwtx_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        jwtx_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //jwtx_model.YQ = "";//要求
                        jwtx_model.FJDZ = fjdz;//附件地址
                        //jwtx_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            jwtx_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //jwtx_model.JBYQ = "";//交办要求
                        //jwtx_model.LDPS = "";//领导批示
                        //jwtx_model.BZ = "";//备注
                        jwtx_model.CJR = "民意一期";//创建人
                        jwtx_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        jwtx_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        jwtx_model.FJM = dr["SUMMARYFILE"].ToString();//附件名
                        //jwtx_model.XJLY = "";//信件来源

                        bool jwtx_res = new BLL.CON_JWTX().Add(jwtx_model);
                        return jwtx_res;
                    #endregion
                    case "9":   //1号窗口
                    case "10":   //市局平安民声
                        break;
                    case "11":   //支队---支队信件转办
                        #region 支队信件转办
                        Model.CON_ZDXJZB zdxjzb_model = new Model.CON_ZDXJZB();
                        zdxjzb_model.ID = con_guid;//主键ID（32位或36位guid）
                        zdxjzb_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        zdxjzb_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        zdxjzb_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        zdxjzb_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //zdxjzb_model.DZYJ = "";//电子邮件
                        //zdxjzb_model.DZ = "";//地址
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            zdxjzb_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            zdxjzb_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        zdxjzb_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        zdxjzb_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //zdxjzb_model.YQ = "";//要求
                        zdxjzb_model.FJDZ = fjdz;//附件地址
                        //zdxjzb_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            zdxjzb_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //zdxjzb_model.JBYQ = "";//交办要求
                        //zdxjzb_model.LDPS = "";//领导批示
                        //zdxjzb_model.BZ = "";//备注
                        zdxjzb_model.CJR = "民意一期";//创建人
                        zdxjzb_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        zdxjzb_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        zdxjzb_model.FJM = dr["SUMMARYFILE"].ToString();//附件名
                        //zdxjzb_model.XJLY = "";//信件来源

                        bool zdxjzb_res = new BLL.CON_ZDXJZB().Add(zdxjzb_model);
                        return zdxjzb_res;
                    #endregion
                    case "12":   //市局督查---督察条线来信
                        #region 督察条线来信
                        Model.CON_DCTXLX dcxtlx_model = new Model.CON_DCTXLX();
                        dcxtlx_model.ID = con_guid;//主键ID（32位或36位guid）
                        dcxtlx_model.BH = dr["SERIALNUMBER"].ToString(); //编号
                        dcxtlx_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        dcxtlx_model.FYR = dr["REACTION_PEOPLE"].ToString();//反映人
                        dcxtlx_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //dcxtlx_model.DZYJ = "";//电子邮件
                        //dcxtlx_model.DZ = "";//地址
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            dcxtlx_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            dcxtlx_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //dcxtlx_model.BT = "";//标题
                        dcxtlx_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        dcxtlx_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //dcxtlx_model.YQ = "";//要求
                        dcxtlx_model.FJDZ = fjdz;//附件地址
                        //dcxtlx_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            dcxtlx_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //dcxtlx_model.JBYQ = "";//交办要求
                        //dcxtlx_model.FYWTXZ = "";//反映问题性质
                        //dcxtlx_model.LDPS = "";//领导批示
                        //dcxtlx_model.BZ = "";//备注
                        dcxtlx_model.CJR = "民意一期";//创建人
                        dcxtlx_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        dcxtlx_model.ZT = 1;//状态( 0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        dcxtlx_model.FJM = dr["SUMMARYFILE"].ToString();//附件名拼接
                                                                        //dcxtlx_model.XJLY = "";//信件来源
                        bool dcxtlx_res = new BLL.CON_DCTXLX().Add(dcxtlx_model);
                        return dcxtlx_res;
                    #endregion
                    case "13":   //其他---省厅、总队信件办理
                        #region 省厅、总队信件办理
                        Model.CON_STZDXJBL stzdxjbl_model = new Model.CON_STZDXJBL();
                        stzdxjbl_model.ID = con_guid;//主键ID（32位或36位guid）
                        //stzdxjbl_model.XJLY = "";//信件来源
                        stzdxjbl_model.BH = dr["SERIALNUMBER"].ToString();//编号
                        stzdxjbl_model.SJBH = dr["ORIGINALSYSTEMNUM"].ToString();//上级编号
                        stzdxjbl_model.LXR = dr["REACTION_PEOPLE"].ToString();//来信人
                        stzdxjbl_model.LXDH = dr["CONTACT_PHONE"].ToString(); ;//联系电话
                        //stzdxjbl_model.DZ = "";//地址
                        //stzdxjbl_model.DZYJ = "";//电子邮件
                        if (!string.IsNullOrWhiteSpace(fyrqstr))
                        {
                            stzdxjbl_model.FYRQ = Convert.ToDateTime(fyrqstr);//反映日期
                        }
                        if (!string.IsNullOrWhiteSpace(blqxstr))
                        {
                            stzdxjbl_model.BLQX = Convert.ToDateTime(blqxstr);//办理期限
                        }
                        //stzdxjbl_model.BT = "";//标题
                        stzdxjbl_model.FYNR = dr["SUMMARY"].ToString();//反映内容
                        stzdxjbl_model.NRZY = dr["ZHAIYAO"].ToString();//内容摘要
                        //stzdxjbl_model.YQ = "";//要求
                        stzdxjbl_model.FJDZ = fjdz;//附件地址
                        //stzdxjbl_model.FPSJ = null;//分配时间
                        if (!string.IsNullOrWhiteSpace(jbrqstr))
                        {
                            stzdxjbl_model.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
                        }
                        //stzdxjbl_model.JBYQ = "";//交办要求
                        //stzdxjbl_model.LDPS = "";//领导批示
                        //stzdxjbl_model.BZ = "";//备注
                        stzdxjbl_model.CJR = "民意一期";//创建人
                        stzdxjbl_model.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
                        stzdxjbl_model.ZT = 1;//状态(0.删除 1.待交办 2.待答复 3.待答复审核 4.待转办 5.待转办审核 6.退办 7.反馈中 8.回访中 9.办结)
                        stzdxjbl_model.FJM = dr["SUMMARYFILE"].ToString();//附件名

                        bool stzdxjbl_res = new BLL.CON_STZDXJBL().Add(stzdxjbl_model);
                        return stzdxjbl_res;
                    #endregion
                    default: break;
                }
            }
            catch (Exception e)
            {
                SysLog.WriteLog(e, AppDomain.CurrentDomain.BaseDirectory);
            }
            return false;
        }
        #endregion

        #region 交办数据
        /// <summary>
        /// 交办数据
        /// </summary>
        /// <param name="assign_guid">交办id</param>
        /// <param name="mylyguid">民意来源guid 对应字典表里的guid</param>
        /// <param name="con_guid">民意档案guid</param>
        /// <param name="jbdw">交办单位</param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.ASSIGN AssignModel(string assign_guid, string mylyguid, string con_guid, string jbdw, DataRow dr)
        {
            Model.ASSIGN model_assign = new Model.ASSIGN(); //ASSIGN 主表
            model_assign.BZ = "";//备注空
            model_assign.CJR = "民意一期";//创建人
            model_assign.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
            //model_assign.HFNR = "";//各部门回复内容汇总
            model_assign.ID = assign_guid;
            model_assign.JBDW = jbdw;//交办单位
            string jbrqstr = dr["ASSIGNED_DATE"].ToString(); //交办日期
            if (!string.IsNullOrWhiteSpace(jbrqstr))
            {
                model_assign.JBRQ = Convert.ToDateTime(jbrqstr);//交办日期
            }
            //model_assign.JBYQ = "";//交办要求
            //model_assign.LDPS = "";//领导批示
            model_assign.MYLY = mylyguid;
            model_assign.MYSJDX = con_guid;//民意数据来源
            model_assign.ZT = 5; //已办结
            return model_assign;
        }
        #endregion

        #region 处办数据
        /// <summary>
        /// 处办数据
        /// </summary>
        /// <param name="assign_guid">交办id</param>
        /// <param name="inwork_guid">处办id</param>
        /// <param name="jbdw">交办单位</param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.INWORK InworkModel(string assign_guid, string inwork_guid, string jbdw, DataRow dr)
        {
            Model.INWORK model_inwork = new Model.INWORK();//处办表
            model_inwork.ID = inwork_guid;
            model_inwork.CJR = "民意一期";//创建人
            model_inwork.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
            model_inwork.ISTX = 0;
            model_inwork.ISZB = 2;//1 是 2否  是否转办
            model_inwork.JBDW = jbdw;//交办单位
            model_inwork.JBSJ = assign_guid;//交办数据
            model_inwork.CBLX = 1;//出版类型 1办理 2拒绝
            model_inwork.ZT = 6; //状态 已办结
            model_inwork.UPDEP = 1;// 上报处理部门，0：否，1：是
            return model_inwork;
        }
        #endregion

        #region 部门答复数据
        /// <summary>
        /// 部门答复数据
        /// </summary>
        /// <param name="inwork_guid">处办id</param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.REPLY_RECORD ReplyModel(string inwork_guid, DataRow dr)
        {
            Model.REPLY_RECORD model_reply = new Model.REPLY_RECORD();
            model_reply.ID = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID
            model_reply.CBID = inwork_guid;//处办id
            model_reply.HFNR = dr["REPLY_CONTENT"].ToString();//回复内容
            model_reply.ZT = 1;//状态
            model_reply.CJR = "民意一期";//创建人
            model_reply.CJSJ = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
            model_reply.CBLX = 1;//处办类型
            string fjdz = dr["REPLY_CONTENTFILEOLD"].ToString();//答复附件地址
            if (!string.IsNullOrWhiteSpace(fjdz))
            {
                fjdz = FJ_baseurl + fjdz;
            }
            model_reply.FJDZ = fjdz;//附件地址
            model_reply.FJM = dr["REPLY_CONTENTFILE"].ToString();//附件名
            return model_reply;
        }
        #endregion

        #region 上报数据
        /// <summary>
        /// 上报数据
        /// </summary>
        /// <param name="assign_guid"></param>
        /// <param name="upReportMyly"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Model.ASSIGN_UPREPORT UpReportModel(string assign_guid, string upreport_guid, int upReportMyly, DataRow dr)
        {
            string fylx_MY1 = dr["TYPES"].ToString();//民意一期反映类型
            string fyle_MY2 = string.Empty;//民意二期反映类型
            if (dicFYLXID_CODE.ContainsKey(fylx_MY1))
            {
                fyle_MY2 = dicFYLXID_CODE[fylx_MY1]; //得到字典中对应的ID
            }
            Model.ASSIGN_UPREPORT model_upreport = new Model.ASSIGN_UPREPORT();
            model_upreport.ID = upreport_guid; //得到32位大写的 GUID
            model_upreport.ASSIGN_ID = assign_guid;//交办id
            model_upreport.DEALCONTENT = dr["REPLY_CONTENT"].ToString(); //调查内容
            model_upreport.FYLX = fyle_MY2;//反映类型
            model_upreport.CREATETIME = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
            model_upreport.CREATOR = "民意一期";
            model_upreport.MYLY = upReportMyly;//民意来源 1寒山闻钟论坛；2：12345热线；3纪委条线；4：信访条线；5省厅、总队信件办理；6督察条线来信；7支队信件转办；8其他自选项；9：96122
            return model_upreport;
        }
        #endregion

        #region 上报附件
        private Model.ASSIGN_UPFJ UpFJModel(string upreport_guid, DataRow dr)
        {
            string fjdz = dr["REPLY_CONTENTFILEOLD"].ToString();//答复附件地址
            if (!string.IsNullOrWhiteSpace(fjdz))
            {
                fjdz = FJ_baseurl + fjdz;
            }
            // http://50.73.141.174:8080/uploadfile/MYPatform/txt/2019/05/17/Report20190517111342.xlsx
            fjdz = fjdz.Substring(7);
            int spliteindex = fjdz.IndexOf("/");
            string dzip = fjdz.Substring(0, spliteindex);
            string dzpath = fjdz.Substring(spliteindex);
            string dzmc = dr["REPLY_CONTENTFILE"].ToString();
            Model.ASSIGN_UPFJ model_upfj = new Model.ASSIGN_UPFJ();
            model_upfj.ID = Guid.NewGuid().ToString("N").ToUpper(); //得到32位大写的 GUID
            model_upfj.UP_ID = upreport_guid; // 上报id
            model_upfj.IP = dzip;//ip加端口
            model_upfj.FJDZ = dzpath;// 附件相对地址
            model_upfj.FJMC = dzmc; //附件名称
            model_upfj.CREATETIME = Convert.ToDateTime(dr["CREATE_DATE"].ToString());//创建时间
            model_upfj.CREATOR = "民意一期";
            return model_upfj;
        }
        #endregion
        #endregion


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
