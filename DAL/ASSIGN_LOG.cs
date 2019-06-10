using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:ASSIGN_LOG
	/// </summary>
	public partial class ASSIGN_LOG
	{
		public ASSIGN_LOG()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ASSIGN_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ASSIGN_LOG(");
			strSql.Append("ID,ASSIGN_ID,INWORK_ID,DEPART_ID,USER_ID,EVENT,CONTENT,DEALDATE,DEALTIME,CREATETIME,CREATOR)");
			strSql.Append(" values (");
			strSql.Append(":ID,:ASSIGN_ID,:INWORK_ID,:DEPART_ID,:USER_ID,:EVENT,:CONTENT,:DEALDATE,:DEALTIME,:CREATETIME,:CREATOR)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":ASSIGN_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":INWORK_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":DEPART_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":USER_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":EVENT", OracleDbType.Int32,4),
					new OracleParameter(":CONTENT", OracleDbType.Varchar2,500),
					new OracleParameter(":DEALDATE", OracleDbType.Date),
					new OracleParameter(":DEALTIME", OracleDbType.Varchar2,10),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ASSIGN_ID;
			parameters[2].Value = model.INWORK_ID;
			parameters[3].Value = model.DEPART_ID;
			parameters[4].Value = model.USER_ID;
			parameters[5].Value = model.EVENT;
			parameters[6].Value = model.CONTENT;
			parameters[7].Value = model.DEALDATE;
			parameters[8].Value = model.DEALTIME;
			parameters[9].Value = model.CREATETIME;
			parameters[10].Value = model.CREATOR;

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
		public bool Update(Model.ASSIGN_LOG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ASSIGN_LOG set ");
			strSql.Append("ID=:ID,");
			strSql.Append("ASSIGN_ID=:ASSIGN_ID,");
			strSql.Append("INWORK_ID=:INWORK_ID,");
			strSql.Append("DEPART_ID=:DEPART_ID,");
			strSql.Append("USER_ID=:USER_ID,");
			strSql.Append("EVENT=:EVENT,");
			strSql.Append("CONTENT=:CONTENT,");
			strSql.Append("DEALDATE=:DEALDATE,");
			strSql.Append("DEALTIME=:DEALTIME,");
			strSql.Append("CREATETIME=:CREATETIME,");
			strSql.Append("CREATOR=:CREATOR");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":ASSIGN_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":INWORK_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":DEPART_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":USER_ID", OracleDbType.Varchar2,36),
					new OracleParameter(":EVENT", OracleDbType.Int32,4),
					new OracleParameter(":CONTENT", OracleDbType.Varchar2,500),
					new OracleParameter(":DEALDATE", OracleDbType.Date),
					new OracleParameter(":DEALTIME", OracleDbType.Varchar2,10),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ASSIGN_ID;
			parameters[2].Value = model.INWORK_ID;
			parameters[3].Value = model.DEPART_ID;
			parameters[4].Value = model.USER_ID;
			parameters[5].Value = model.EVENT;
			parameters[6].Value = model.CONTENT;
			parameters[7].Value = model.DEALDATE;
			parameters[8].Value = model.DEALTIME;
			parameters[9].Value = model.CREATETIME;
			parameters[10].Value = model.CREATOR;

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
			strSql.Append("delete from ASSIGN_LOG ");
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
		public Model.ASSIGN_LOG GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,ASSIGN_ID,INWORK_ID,DEPART_ID,USER_ID,EVENT,CONTENT,DEALDATE,DEALTIME,CREATETIME,CREATOR from ASSIGN_LOG ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Model.ASSIGN_LOG model=new Model.ASSIGN_LOG();
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
		public Model.ASSIGN_LOG DataRowToModel(DataRow row)
		{
			Model.ASSIGN_LOG model=new Model.ASSIGN_LOG();
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
				if(row["INWORK_ID"]!=null)
				{
					model.INWORK_ID=row["INWORK_ID"].ToString();
				}
				if(row["DEPART_ID"]!=null)
				{
					model.DEPART_ID=row["DEPART_ID"].ToString();
				}
				if(row["USER_ID"]!=null)
				{
					model.USER_ID=row["USER_ID"].ToString();
				}
				if(row["EVENT"]!=null && row["EVENT"].ToString()!="")
				{
					model.EVENT=decimal.Parse(row["EVENT"].ToString());
				}
				if(row["CONTENT"]!=null)
				{
					model.CONTENT=row["CONTENT"].ToString();
				}
				if(row["DEALDATE"]!=null && row["DEALDATE"].ToString()!="")
				{
					model.DEALDATE=DateTime.Parse(row["DEALDATE"].ToString());
				}
				if(row["DEALTIME"]!=null)
				{
					model.DEALTIME=row["DEALTIME"].ToString();
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
			strSql.Append("select ID,ASSIGN_ID,INWORK_ID,DEPART_ID,USER_ID,EVENT,CONTENT,DEALDATE,DEALTIME,CREATETIME,CREATOR ");
			strSql.Append(" FROM ASSIGN_LOG ");
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
			strSql.Append("select count(1) FROM ASSIGN_LOG ");
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
			strSql.Append(")AS Row, T.*  from ASSIGN_LOG T ");
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
			parameters[0].Value = "ASSIGN_LOG";
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

