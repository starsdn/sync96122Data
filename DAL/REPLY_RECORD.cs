using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:REPLY_RECORD
	/// </summary>
	public partial class REPLY_RECORD
	{
		public REPLY_RECORD()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from REPLY_RECORD");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			return DbHelperOra_new.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.REPLY_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into REPLY_RECORD(");
			strSql.Append("ID,CBID,HFNR,ZT,CJR,CJSJ,CBLX,FJDZ,FJM)");
			strSql.Append(" values (");
			strSql.Append(":ID,:CBID,:HFNR,:ZT,:CJR,:CJSJ,:CBLX,:FJDZ,:FJM)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":CBID", OracleDbType.Varchar2,36),
					new OracleParameter(":HFNR", OracleDbType.Clob),
					new OracleParameter(":ZT", OracleDbType.Int32,4),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":CBLX", OracleDbType.Int32,4),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.CBID;
			parameters[2].Value = model.HFNR;
			parameters[3].Value = model.ZT;
			parameters[4].Value = model.CJR;
			parameters[5].Value = model.CJSJ;
			parameters[6].Value = model.CBLX;
			parameters[7].Value = model.FJDZ;
			parameters[8].Value = model.FJM;

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
		public bool Update(Model.REPLY_RECORD model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update REPLY_RECORD set ");
			strSql.Append("CBID=:CBID,");
			strSql.Append("HFNR=:HFNR,");
			strSql.Append("ZT=:ZT,");
			strSql.Append("CJR=:CJR,");
			strSql.Append("CJSJ=:CJSJ,");
			strSql.Append("CBLX=:CBLX,");
			strSql.Append("FJDZ=:FJDZ,");
			strSql.Append("FJM=:FJM");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":CBID", OracleDbType.Varchar2,36),
					new OracleParameter(":HFNR", OracleDbType.Clob),
					new OracleParameter(":ZT", OracleDbType.Int32,4),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":CBLX", OracleDbType.Int32,4),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000),
					new OracleParameter(":ID", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.CBID;
			parameters[1].Value = model.HFNR;
			parameters[2].Value = model.ZT;
			parameters[3].Value = model.CJR;
			parameters[4].Value = model.CJSJ;
			parameters[5].Value = model.CBLX;
			parameters[6].Value = model.FJDZ;
			parameters[7].Value = model.FJM;
			parameters[8].Value = model.ID;

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
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from REPLY_RECORD ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from REPLY_RECORD ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOra_new.ExecuteSql(strSql.ToString());
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
		public Model.REPLY_RECORD GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,CBID,HFNR,ZT,CJR,CJSJ,CBLX,FJDZ,FJM from REPLY_RECORD ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			Model.REPLY_RECORD model=new Model.REPLY_RECORD();
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
		public Model.REPLY_RECORD DataRowToModel(DataRow row)
		{
			Model.REPLY_RECORD model=new Model.REPLY_RECORD();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["CBID"]!=null)
				{
					model.CBID=row["CBID"].ToString();
				}
				if(row["HFNR"]!=null)
				{
					model.HFNR=row["HFNR"].ToString();
				}
				if(row["ZT"]!=null && row["ZT"].ToString()!="")
				{
					model.ZT=decimal.Parse(row["ZT"].ToString());
				}
				if(row["CJR"]!=null)
				{
					model.CJR=row["CJR"].ToString();
				}
				if(row["CJSJ"]!=null && row["CJSJ"].ToString()!="")
				{
					model.CJSJ=DateTime.Parse(row["CJSJ"].ToString());
				}
				if(row["CBLX"]!=null && row["CBLX"].ToString()!="")
				{
					model.CBLX=decimal.Parse(row["CBLX"].ToString());
				}
				if(row["FJDZ"]!=null)
				{
					model.FJDZ=row["FJDZ"].ToString();
				}
				if(row["FJM"]!=null)
				{
					model.FJM=row["FJM"].ToString();
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
			strSql.Append("select ID,CBID,HFNR,ZT,CJR,CJSJ,CBLX,FJDZ,FJM ");
			strSql.Append(" FROM REPLY_RECORD ");
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
			strSql.Append("select count(1) FROM REPLY_RECORD ");
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
			strSql.Append(")AS Row, T.*  from REPLY_RECORD T ");
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
			parameters[0].Value = "REPLY_RECORD";
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

