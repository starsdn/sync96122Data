using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ASSIGN_UPFJ
	/// </summary>
	public partial class ASSIGN_UPFJ
	{
		public ASSIGN_UPFJ()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ASSIGN_UPFJ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ASSIGN_UPFJ(");
			strSql.Append("ID,UP_ID,IP,FJDZ,FJMC,CREATETIME,CREATOR)");
			strSql.Append(" values (");
			strSql.Append(":ID,:UP_ID,:IP,:FJDZ,:FJMC,:CREATETIME,:CREATOR)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":UP_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":IP", OracleDbType.Varchar2,30),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,200),
					new OracleParameter(":FJMC", OracleDbType.Varchar2,100),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UP_ID;
			parameters[2].Value = model.IP;
			parameters[3].Value = model.FJDZ;
			parameters[4].Value = model.FJMC;
			parameters[5].Value = model.CREATETIME;
			parameters[6].Value = model.CREATOR;

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
		public bool Update(Model.ASSIGN_UPFJ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ASSIGN_UPFJ set ");
			strSql.Append("ID=:ID,");
			strSql.Append("UP_ID=:UP_ID,");
			strSql.Append("IP=:IP,");
			strSql.Append("FJDZ=:FJDZ,");
			strSql.Append("FJMC=:FJMC,");
			strSql.Append("CREATETIME=:CREATETIME,");
			strSql.Append("CREATOR=:CREATOR");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":UP_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":IP", OracleDbType.Varchar2,30),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,200),
					new OracleParameter(":FJMC", OracleDbType.Varchar2,100),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.UP_ID;
			parameters[2].Value = model.IP;
			parameters[3].Value = model.FJDZ;
			parameters[4].Value = model.FJMC;
			parameters[5].Value = model.CREATETIME;
			parameters[6].Value = model.CREATOR;

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
			strSql.Append("delete from ASSIGN_UPFJ ");
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
		public Model.ASSIGN_UPFJ GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UP_ID,IP,FJDZ,FJMC,CREATETIME,CREATOR from ASSIGN_UPFJ ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Model.ASSIGN_UPFJ model=new Model.ASSIGN_UPFJ();
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
		public Model.ASSIGN_UPFJ DataRowToModel(DataRow row)
		{
			Model.ASSIGN_UPFJ model=new Model.ASSIGN_UPFJ();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["UP_ID"]!=null)
				{
					model.UP_ID=row["UP_ID"].ToString();
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["FJDZ"]!=null)
				{
					model.FJDZ=row["FJDZ"].ToString();
				}
				if(row["FJMC"]!=null)
				{
					model.FJMC=row["FJMC"].ToString();
				}
				if(row["CREATETIME"]!=null && row["CREATETIME"].ToString()!="")
				{
					model.CREATETIME=DateTime.Parse(row["CREATETIME"].ToString());
				}
				if(row["CREATOR"]!=null)
				{
					model.CREATOR=row["CREATOR"].ToString();
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
			strSql.Append("select ID,UP_ID,IP,FJDZ,FJMC,CREATETIME,CREATOR ");
			strSql.Append(" FROM ASSIGN_UPFJ ");
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
			strSql.Append("select count(1) FROM ASSIGN_UPFJ ");
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
			strSql.Append(")AS Row, T.*  from ASSIGN_UPFJ T ");
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
			parameters[0].Value = "ASSIGN_UPFJ";
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

