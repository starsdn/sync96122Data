using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    //同步一期民意数据的反映类型关系表
    public partial class ZZ_DIC_MATTERSCATEGORY
    {

        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZZ_DIC_MATTERSCATEGORY");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };

            return DbHelperOra_new.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.ZZ_DIC_MATTERSCATEGORY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ZZ_DIC_MATTERSCATEGORY(");
            strSql.Append("ID,NAMES,CATEGORYID,CATEGORYLEVEL,STATES,REMARKS,CREATE_PEOPLE,CREATE_DATE,MODIFY_PEOPLE,MODIFY_DATE,Int32CODE,PARAMID,CODE");
            strSql.Append(") values (");
            strSql.Append(":ID,:NAMES,:CATEGORYID,:CATEGORYLEVEL,:STATES,:REMARKS,:CREATE_PEOPLE,:CREATE_DATE,:MODIFY_PEOPLE,:MODIFY_DATE,:Int32CODE,:PARAMID,:CODE");
            strSql.Append(") ");

            OracleParameter[] parameters = {
                        new OracleParameter(":ID", OracleDbType.Int32,4) ,
                        new OracleParameter(":NAMES", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CATEGORYID", OracleDbType.Int32,4) ,
                        new OracleParameter(":CATEGORYLEVEL", OracleDbType.Int32,4) ,
                        new OracleParameter(":STATES", OracleDbType.Int32,4) ,
                        new OracleParameter(":REMARKS", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_DATE", OracleDbType.Date) ,
                        new OracleParameter(":MODIFY_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":MODIFY_DATE", OracleDbType.Date) ,
                        new OracleParameter(":Int32CODE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":PARAMID", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CODE", OracleDbType.Varchar2,10)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAMES;
            parameters[2].Value = model.CATEGORYID;
            parameters[3].Value = model.CATEGORYLEVEL;
            parameters[4].Value = model.STATES;
            parameters[5].Value = model.REMARKS;
            parameters[6].Value = model.CREATE_PEOPLE;
            parameters[7].Value = model.CREATE_DATE;
            parameters[8].Value = model.MODIFY_PEOPLE;
            parameters[9].Value = model.MODIFY_DATE;
            parameters[10].Value = model.NUMBERCODE;
            parameters[11].Value = model.PARAMID;
            parameters[12].Value = model.CODE;
            DbHelperOra_new.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.ZZ_DIC_MATTERSCATEGORY model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ZZ_DIC_MATTERSCATEGORY set ");

            strSql.Append(" ID = :ID , ");
            strSql.Append(" NAMES = :NAMES , ");
            strSql.Append(" CATEGORYID = :CATEGORYID , ");
            strSql.Append(" CATEGORYLEVEL = :CATEGORYLEVEL , ");
            strSql.Append(" STATES = :STATES , ");
            strSql.Append(" REMARKS = :REMARKS , ");
            strSql.Append(" CREATE_PEOPLE = :CREATE_PEOPLE , ");
            strSql.Append(" CREATE_DATE = :CREATE_DATE , ");
            strSql.Append(" MODIFY_PEOPLE = :MODIFY_PEOPLE , ");
            strSql.Append(" MODIFY_DATE = :MODIFY_DATE , ");
            strSql.Append(" Int32CODE = :Int32CODE , ");
            strSql.Append(" PARAMID = :PARAMID , ");
            strSql.Append(" CODE = :CODE  ");
            strSql.Append(" where  ");

            OracleParameter[] parameters = {
                        new OracleParameter(":ID", OracleDbType.Int32,4) ,
                        new OracleParameter(":NAMES", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CATEGORYID", OracleDbType.Int32,4) ,
                        new OracleParameter(":CATEGORYLEVEL", OracleDbType.Int32,4) ,
                        new OracleParameter(":STATES", OracleDbType.Int32,4) ,
                        new OracleParameter(":REMARKS", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CREATE_DATE", OracleDbType.Date) ,
                        new OracleParameter(":MODIFY_PEOPLE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":MODIFY_DATE", OracleDbType.Date) ,
                        new OracleParameter(":Int32CODE", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":PARAMID", OracleDbType.Varchar2,100) ,
                        new OracleParameter(":CODE", OracleDbType.Varchar2,10)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.NAMES;
            parameters[2].Value = model.CATEGORYID;
            parameters[3].Value = model.CATEGORYLEVEL;
            parameters[4].Value = model.STATES;
            parameters[5].Value = model.REMARKS;
            parameters[6].Value = model.CREATE_PEOPLE;
            parameters[7].Value = model.CREATE_DATE;
            parameters[8].Value = model.MODIFY_PEOPLE;
            parameters[9].Value = model.MODIFY_DATE;
            parameters[10].Value = model.NUMBERCODE;
            parameters[11].Value = model.PARAMID;
            parameters[12].Value = model.CODE;
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
            strSql.Append("delete from ZZ_DIC_MATTERSCATEGORY ");
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
        public Model.ZZ_DIC_MATTERSCATEGORY GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, NAMES, CATEGORYID, CATEGORYLEVEL, STATES, REMARKS, CREATE_PEOPLE, CREATE_DATE, MODIFY_PEOPLE, MODIFY_DATE, Int32CODE, PARAMID, CODE  ");
            strSql.Append("  from ZZ_DIC_MATTERSCATEGORY ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
            };


            Model.ZZ_DIC_MATTERSCATEGORY model = new Model.ZZ_DIC_MATTERSCATEGORY();
            DataSet ds = DbHelperOra_new.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = decimal.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.NAMES = ds.Tables[0].Rows[0]["NAMES"].ToString();
                if (ds.Tables[0].Rows[0]["CATEGORYID"].ToString() != "")
                {
                    model.CATEGORYID = decimal.Parse(ds.Tables[0].Rows[0]["CATEGORYID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CATEGORYLEVEL"].ToString() != "")
                {
                    model.CATEGORYLEVEL = decimal.Parse(ds.Tables[0].Rows[0]["CATEGORYLEVEL"].ToString());
                }
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
                model.NUMBERCODE = ds.Tables[0].Rows[0]["NUMBERCODE"].ToString();
                model.PARAMID = ds.Tables[0].Rows[0]["PARAMID"].ToString();
                model.CODE = ds.Tables[0].Rows[0]["CODE"].ToString();

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
            strSql.Append(" FROM ZZ_DIC_MATTERSCATEGORY ");
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
            strSql.Append(" FROM ZZ_DIC_MATTERSCATEGORY ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOra_new.Query(strSql.ToString());
        }


    }
}

