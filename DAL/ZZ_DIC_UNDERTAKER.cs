using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    //同步一期民意数据的部门关系表
    public partial class ZZ_DIC_UNDERTAKER
    {

        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZZ_DIC_UNDERTAKER");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

            return DbHelperOra_new.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.ZZ_DIC_UNDERTAKER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZZ_DIC_UNDERTAKER(");
            strSql.Append("ID,JIGMC,JIANC,STATES,REMARKS,CREATE_PEOPLE,CREATE_DATE,MODIFY_PEOPLE,MODIFY_DATE,SHANGJBM,BIANM,PARENTID,ZHIDUIID,TYPE,ORDERNUM,DIANXINBUMEN,GUID");
            strSql.Append(") values (");
            strSql.Append(":ID,:JIGMC,:JIANC,:STATES,:REMARKS,:CREATE_PEOPLE,:CREATE_DATE,:MODIFY_PEOPLE,:MODIFY_DATE,:SHANGJBM,:BIANM,:PARENTID,:ZHIDUIID,:TYPE,:ORDERNUM,:DIANXINBUMEN,:GUID");
            strSql.Append(") ");

            OracleParameter[] parameters = {
                        new OracleParameter(":ID", OracleDbType.Int32,4) ,
                        new OracleParameter(":JIGMC", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":JIANC", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":STATES", OracleDbType.Int32,4) ,
                        new OracleParameter(":REMARKS", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_DATE", OracleDbType.Date) ,
                        new OracleParameter(":MODIFY_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":MODIFY_DATE", OracleDbType.Date) ,
                        new OracleParameter(":SHANGJBM", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":BIANM", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":PARENTID", OracleDbType.Int32,4) ,
                        new OracleParameter(":ZHIDUIID", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":TYPE", OracleDbType.Int32,4) ,
                        new OracleParameter(":ORDERNUM", OracleDbType.Int32,4) ,
                        new OracleParameter(":DIANXINBUMEN", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":GUID", OracleDbType.Varchar2,36)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.JIGMC;
            parameters[2].Value = model.JIANC;
            parameters[3].Value = model.STATES;
            parameters[4].Value = model.REMARKS;
            parameters[5].Value = model.CREATE_PEOPLE;
            parameters[6].Value = model.CREATE_DATE;
            parameters[7].Value = model.MODIFY_PEOPLE;
            parameters[8].Value = model.MODIFY_DATE;
            parameters[9].Value = model.SHANGJBM;
            parameters[10].Value = model.BIANM;
            parameters[11].Value = model.PARENTID;
            parameters[12].Value = model.ZHIDUIID;
            parameters[13].Value = model.TYPE;
            parameters[14].Value = model.ORDERNUM;
            parameters[15].Value = model.DIANXINBUMEN;
            parameters[16].Value = model.GUID;
            DbHelperOra_new.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ZZ_DIC_UNDERTAKER model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZZ_DIC_UNDERTAKER set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" JIGMC = :JIGMC , ");
            strSql.Append(" JIANC = :JIANC , ");
            strSql.Append(" STATES = :STATES , ");
            strSql.Append(" REMARKS = :REMARKS , ");
            strSql.Append(" CREATE_PEOPLE = :CREATE_PEOPLE , ");
            strSql.Append(" CREATE_DATE = :CREATE_DATE , ");
            strSql.Append(" MODIFY_PEOPLE = :MODIFY_PEOPLE , ");
            strSql.Append(" MODIFY_DATE = :MODIFY_DATE , ");
            strSql.Append(" SHANGJBM = :SHANGJBM , ");
            strSql.Append(" BIANM = :BIANM , ");
            strSql.Append(" PARENTID = :PARENTID , ");
            strSql.Append(" ZHIDUIID = :ZHIDUIID , ");
            strSql.Append(" TYPE = :TYPE , ");
            strSql.Append(" ORDERNUM = :ORDERNUM , ");
            strSql.Append(" DIANXINBUMEN = :DIANXINBUMEN , ");
            strSql.Append(" GUID = :GUID  ");
            strSql.Append(" where  ");

            OracleParameter[] parameters = {
                        new OracleParameter(":ID", OracleDbType.Int32,4) ,
                        new OracleParameter(":JIGMC", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":JIANC", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":STATES", OracleDbType.Int32,4) ,
                        new OracleParameter(":REMARKS", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_DATE", OracleDbType.Date) ,
                        new OracleParameter(":MODIFY_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":MODIFY_DATE", OracleDbType.Date) ,
                        new OracleParameter(":SHANGJBM", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":BIANM", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":PARENTID", OracleDbType.Int32,4) ,
                        new OracleParameter(":ZHIDUIID", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":TYPE", OracleDbType.Int32,4) ,
                        new OracleParameter(":ORDERNUM", OracleDbType.Int32,4) ,
                        new OracleParameter(":DIANXINBUMEN", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":GUID", OracleDbType.Varchar2,36)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.JIGMC;
            parameters[2].Value = model.JIANC;
            parameters[3].Value = model.STATES;
            parameters[4].Value = model.REMARKS;
            parameters[5].Value = model.CREATE_PEOPLE;
            parameters[6].Value = model.CREATE_DATE;
            parameters[7].Value = model.MODIFY_PEOPLE;
            parameters[8].Value = model.MODIFY_DATE;
            parameters[9].Value = model.SHANGJBM;
            parameters[10].Value = model.BIANM;
            parameters[11].Value = model.PARENTID;
            parameters[12].Value = model.ZHIDUIID;
            parameters[13].Value = model.TYPE;
            parameters[14].Value = model.ORDERNUM;
            parameters[15].Value = model.DIANXINBUMEN;
            parameters[16].Value = model.GUID;
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
        public bool Delete()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZZ_DIC_UNDERTAKER ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };


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
        /// 得到一个对象实体
        /// </summary>
        public Model.ZZ_DIC_UNDERTAKER GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, JIGMC, JIANC, STATES, REMARKS, CREATE_PEOPLE, CREATE_DATE, MODIFY_PEOPLE, MODIFY_DATE, SHANGJBM, BIANM, PARENTID, ZHIDUIID, TYPE, ORDERNUM, DIANXINBUMEN, GUID  ");
            strSql.Append("  from ZZ_DIC_UNDERTAKER ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };


            Model.ZZ_DIC_UNDERTAKER model = new Model.ZZ_DIC_UNDERTAKER();
            DataSet ds = DbHelperOra_new.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = decimal.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.JIGMC = ds.Tables[0].Rows[0]["JIGMC"].ToString();
                model.JIANC = ds.Tables[0].Rows[0]["JIANC"].ToString();
                if (ds.Tables[0].Rows[0]["STATES"].ToString() != "")
                {
                    model.STATES = decimal.Parse(ds.Tables[0].Rows[0]["STATES"].ToString());
                }
                model.REMARKS = ds.Tables[0].Rows[0]["REMARKS"].ToString();
                model.CREATE_PEOPLE = ds.Tables[0].Rows[0]["CREATE_PEOPLE"].ToString();
                if (ds.Tables[0].Rows[0]["CREATE_DATE"].ToString() != "")
                {
                    model.CREATE_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["CREATE_DATE"].ToString());
                }
                model.MODIFY_PEOPLE = ds.Tables[0].Rows[0]["MODIFY_PEOPLE"].ToString();
                if (ds.Tables[0].Rows[0]["MODIFY_DATE"].ToString() != "")
                {
                    model.MODIFY_DATE = DateTime.Parse(ds.Tables[0].Rows[0]["MODIFY_DATE"].ToString());
                }
                model.SHANGJBM = ds.Tables[0].Rows[0]["SHANGJBM"].ToString();
                model.BIANM = ds.Tables[0].Rows[0]["BIANM"].ToString();
                if (ds.Tables[0].Rows[0]["PARENTID"].ToString() != "")
                {
                    model.PARENTID = decimal.Parse(ds.Tables[0].Rows[0]["PARENTID"].ToString());
                }
                model.ZHIDUIID = ds.Tables[0].Rows[0]["ZHIDUIID"].ToString();
                if (ds.Tables[0].Rows[0]["TYPE"].ToString() != "")
                {
                    model.TYPE = decimal.Parse(ds.Tables[0].Rows[0]["TYPE"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ORDERNUM"].ToString() != "")
                {
                    model.ORDERNUM = decimal.Parse(ds.Tables[0].Rows[0]["ORDERNUM"].ToString());
                }
                model.DIANXINBUMEN = ds.Tables[0].Rows[0]["DIANXINBUMEN"].ToString();
                model.GUID = ds.Tables[0].Rows[0]["GUID"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ZZ_DIC_UNDERTAKER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra_new.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM ZZ_DIC_UNDERTAKER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOra_new.Query(strSql.ToString());
        }


    }
}

