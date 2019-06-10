using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:SYS_FYLXBASEDATA
	/// </summary>
	public partial class SYS_FYLXBASEDATA
	{
		public SYS_FYLXBASEDATA()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.SYS_FYLXBASEDATA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_FYLXBASEDATA(");
			strSql.Append("ID,NAME,PARENT_CODE,BASELEVEL,STATE,CODE,REMARK,CREATETIME,CREATOR)");
			strSql.Append(" values (");
			strSql.Append(":ID,:NAME,:PARENT_CODE,:BASELEVEL,:STATE,:CODE,:REMARK,:CREATETIME,:CREATOR)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,4),
					new OracleParameter(":NAME", OracleDbType.Varchar2,50),
					new OracleParameter(":PARENT_CODE", OracleDbType.Varchar2,10),
					new OracleParameter(":BASELEVEL", OracleDbType.Int32,4),
					new OracleParameter(":STATE", OracleDbType.Int32,4),
					new OracleParameter(":CODE", OracleDbType.Varchar2,10),
					new OracleParameter(":REMARK", OracleDbType.Varchar2,100),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENT_CODE;
			parameters[3].Value = model.BASELEVEL;
			parameters[4].Value = model.STATE;
			parameters[5].Value = model.CODE;
			parameters[6].Value = model.REMARK;
			parameters[7].Value = model.CREATETIME;
			parameters[8].Value = model.CREATOR;

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
		public bool Update(Model.SYS_FYLXBASEDATA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_FYLXBASEDATA set ");
			strSql.Append("ID=:ID,");
			strSql.Append("NAME=:NAME,");
			strSql.Append("PARENT_CODE=:PARENT_CODE,");
			strSql.Append("BASELEVEL=:BASELEVEL,");
			strSql.Append("STATE=:STATE,");
			strSql.Append("CODE=:CODE,");
			strSql.Append("REMARK=:REMARK,");
			strSql.Append("CREATETIME=:CREATETIME,");
			strSql.Append("CREATOR=:CREATOR");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,4),
					new OracleParameter(":NAME", OracleDbType.Varchar2,50),
					new OracleParameter(":PARENT_CODE", OracleDbType.Varchar2,10),
					new OracleParameter(":BASELEVEL", OracleDbType.Int32,4),
					new OracleParameter(":STATE", OracleDbType.Int32,4),
					new OracleParameter(":CODE", OracleDbType.Varchar2,10),
					new OracleParameter(":REMARK", OracleDbType.Varchar2,100),
					new OracleParameter(":CREATETIME", OracleDbType.Date),
					new OracleParameter(":CREATOR", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.PARENT_CODE;
			parameters[3].Value = model.BASELEVEL;
			parameters[4].Value = model.STATE;
			parameters[5].Value = model.CODE;
			parameters[6].Value = model.REMARK;
			parameters[7].Value = model.CREATETIME;
			parameters[8].Value = model.CREATOR;

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
			strSql.Append("delete from SYS_FYLXBASEDATA ");
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
		public Model.SYS_FYLXBASEDATA GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,PARENT_CODE,BASELEVEL,STATE,CODE,REMARK,CREATETIME,CREATOR from SYS_FYLXBASEDATA ");
			strSql.Append(" where ");
			OracleParameter[] parameters = {
			};

			Model.SYS_FYLXBASEDATA model=new Model.SYS_FYLXBASEDATA();
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
		public Model.SYS_FYLXBASEDATA DataRowToModel(DataRow row)
		{
			Model.SYS_FYLXBASEDATA model=new Model.SYS_FYLXBASEDATA();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["NAME"]!=null)
				{
					model.NAME=row["NAME"].ToString();
				}
				if(row["PARENT_CODE"]!=null)
				{
					model.PARENT_CODE=row["PARENT_CODE"].ToString();
				}
				if(row["BASELEVEL"]!=null && row["BASELEVEL"].ToString()!="")
				{
					model.BASELEVEL=decimal.Parse(row["BASELEVEL"].ToString());
				}
				if(row["STATE"]!=null && row["STATE"].ToString()!="")
				{
					model.STATE=decimal.Parse(row["STATE"].ToString());
				}
				if(row["CODE"]!=null)
				{
					model.CODE=row["CODE"].ToString();
				}
				if(row["REMARK"]!=null)
				{
					model.REMARK=row["REMARK"].ToString();
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
			strSql.Append("select ID,NAME,PARENT_CODE,BASELEVEL,STATE,CODE,REMARK,CREATETIME,CREATOR ");
			strSql.Append(" FROM SYS_FYLXBASEDATA ");
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
			strSql.Append("select count(1) FROM SYS_FYLXBASEDATA ");
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
			strSql.Append(")AS Row, T.*  from SYS_FYLXBASEDATA T ");
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
			parameters[0].Value = "SYS_FYLXBASEDATA";
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

