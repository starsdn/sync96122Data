﻿using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ASSIGN_UPREPORT
	/// </summary>
	public partial class ASSIGN_UPREPORT
	{
		public ASSIGN_UPREPORT()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ASSIGN_UPREPORT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ASSIGN_UPREPORT(");
			strSql.Append("ID,ASSIGN_ID,DEALCONTENT,FYLX,CREATETIME,CREATOR,MYLY)");
			strSql.Append(" values (");
			strSql.Append(":ID,:ASSIGN_ID,:DEALCONTENT,:FYLX,:CREATETIME,:CREATOR,:MYLY)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":ASSIGN_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":DEALCONTENT", OracleDbType.Clob,4000),
					new OracleParameter(":FYLX", OracleDbType.Varchar2,8),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36),
					new OracleParameter(":MYLY", OracleDbType.Int32,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ASSIGN_ID;
			parameters[2].Value = model.DEALCONTENT;
			parameters[3].Value = model.FYLX;
			parameters[4].Value = model.CREATETIME;
			parameters[5].Value = model.CREATOR;
			parameters[6].Value = model.MYLY;

			int rows=DbHelperOra_new.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Model.ASSIGN_UPREPORT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ASSIGN_UPREPORT set ");
			strSql.Append("ID=:ID,");
			strSql.Append("ASSIGN_ID=:ASSIGN_ID,");
			strSql.Append("DEALCONTENT=:DEALCONTENT,");
			strSql.Append("FYLX=:FYLX,");
			strSql.Append("CREATETIME=:CREATETIME,");
			strSql.Append("CREATOR=:CREATOR,");
			strSql.Append("MYLY=:MYLY");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":ASSIGN_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":DEALCONTENT", OracleDbType.Clob,4000),
					new OracleParameter(":FYLX", OracleDbType.Varchar2,8),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36),
					new OracleParameter(":MYLY", OracleDbType.Int32,4)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ASSIGN_ID;
			parameters[2].Value = model.DEALCONTENT;
			parameters[3].Value = model.FYLX;
			parameters[4].Value = model.CREATETIME;
			parameters[5].Value = model.CREATOR;
			parameters[6].Value = model.MYLY;

			int rows=DbHelperOra_new.ExecuteSql(strSql.ToString(),parameters);
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
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ASSIGN_UPREPORT ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			int rows=DbHelperOra_new.ExecuteSql(strSql.ToString(),parameters);
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
		public Model.ASSIGN_UPREPORT GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ASSIGN_ID,DEALCONTENT,FYLX,CREATETIME,CREATOR,MYLY from ASSIGN_UPREPORT ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Model.ASSIGN_UPREPORT model=new Model.ASSIGN_UPREPORT();
			DataSet ds=DbHelperOra_new.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Model.ASSIGN_UPREPORT DataRowToModel(DataRow row)
		{
			Model.ASSIGN_UPREPORT model=new Model.ASSIGN_UPREPORT();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ASSIGN_ID"]!=null)
				{
					model.ASSIGN_ID=row["ASSIGN_ID"].ToString();
				}
					//model.DEALCONTENT=row["DEALCONTENT"].ToString();
				if(row["FYLX"]!=null)
				{
					model.FYLX=row["FYLX"].ToString();
				}
				if(row["CREATETIME"]!=null && row["CREATETIME"].ToString()!="")
				{
					model.CREATETIME=DateTime.Parse(row["CREATETIME"].ToString());
				}
				if(row["CREATOR"]!=null)
				{
					model.CREATOR=row["CREATOR"].ToString();
				}
				if(row["MYLY"]!=null && row["MYLY"].ToString()!="")
				{
					model.MYLY=decimal.Parse(row["MYLY"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ASSIGN_ID,DEALCONTENT,FYLX,CREATETIME,CREATOR,MYLY ");
			strSql.Append(" FROM ASSIGN_UPREPORT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra_new.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ASSIGN_UPREPORT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_Int32() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ASSIGN_UPREPORT T ");
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
			parameters[0].Value = "ASSIGN_UPREPORT";
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

