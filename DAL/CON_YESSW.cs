using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:CON_YESSW
	/// </summary>
	public partial class CON_YESSW
	{
		public CON_YESSW()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CON_YESSW");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			return DbHelperOra_new.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.CON_YESSW model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CON_YESSW(");
			strSql.Append("ID,BH,SJBH,LDR,LXDH,FYRQ,FYLX,FYNR,NRZY,FJDZ,YQ,JBRQ,BLQX,JBYQ,FPSJ,BZ,LDPS,CJR,CJSJ,ZT,XBDW,FJM)");
			strSql.Append(" values (");
			strSql.Append(":ID,:BH,:SJBH,:LDR,:LXDH,:FYRQ,:FYLX,:FYNR,:NRZY,:FJDZ,:YQ,:JBRQ,:BLQX,:JBYQ,:FPSJ,:BZ,:LDPS,:CJR,:CJSJ,:ZT,:XBDW,:FJM)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":BH", OracleDbType.Varchar2,100),
					new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
					new OracleParameter(":LDR", OracleDbType.Varchar2,50),
					new OracleParameter(":LXDH", OracleDbType.Varchar2,25),
					new OracleParameter(":FYRQ", OracleDbType.Date),
					new OracleParameter(":FYLX", OracleDbType.Varchar2,36),
					new OracleParameter(":FYNR", OracleDbType.Clob,4000),
					new OracleParameter(":NRZY", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":YQ", OracleDbType.Varchar2,2000),
					new OracleParameter(":JBRQ", OracleDbType.Date),
					new OracleParameter(":BLQX", OracleDbType.Date),
					new OracleParameter(":JBYQ", OracleDbType.Varchar2,25),
					new OracleParameter(":FPSJ", OracleDbType.Date),
					new OracleParameter(":BZ", OracleDbType.Varchar2,500),
					new OracleParameter(":LDPS", OracleDbType.Varchar2,2000),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":ZT", OracleDbType.Int32,1),
					new OracleParameter(":XBDW", OracleDbType.Varchar2,36),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.BH;
			parameters[2].Value = model.SJBH;
			parameters[3].Value = model.LDR;
			parameters[4].Value = model.LXDH;
			parameters[5].Value = model.FYRQ;
			parameters[6].Value = model.FYLX;
			parameters[7].Value = model.FYNR;
			parameters[8].Value = model.NRZY;
			parameters[9].Value = model.FJDZ;
			parameters[10].Value = model.YQ;
			parameters[11].Value = model.JBRQ;
			parameters[12].Value = model.BLQX;
			parameters[13].Value = model.JBYQ;
			parameters[14].Value = model.FPSJ;
			parameters[15].Value = model.BZ;
			parameters[16].Value = model.LDPS;
			parameters[17].Value = model.CJR;
			parameters[18].Value = model.CJSJ;
			parameters[19].Value = model.ZT;
			parameters[20].Value = model.XBDW;
			parameters[21].Value = model.FJM;

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
		public bool Update(Model.CON_YESSW model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CON_YESSW set ");
			strSql.Append("BH=:BH,");
			strSql.Append("SJBH=:SJBH,");
			strSql.Append("LDR=:LDR,");
			strSql.Append("LXDH=:LXDH,");
			strSql.Append("FYRQ=:FYRQ,");
			strSql.Append("FYLX=:FYLX,");
			strSql.Append("FYNR=:FYNR,");
			strSql.Append("NRZY=:NRZY,");
			strSql.Append("FJDZ=:FJDZ,");
			strSql.Append("YQ=:YQ,");
			strSql.Append("JBRQ=:JBRQ,");
			strSql.Append("BLQX=:BLQX,");
			strSql.Append("JBYQ=:JBYQ,");
			strSql.Append("FPSJ=:FPSJ,");
			strSql.Append("BZ=:BZ,");
			strSql.Append("LDPS=:LDPS,");
			strSql.Append("CJR=:CJR,");
			strSql.Append("CJSJ=:CJSJ,");
			strSql.Append("ZT=:ZT,");
			strSql.Append("XBDW=:XBDW,");
			strSql.Append("FJM=:FJM");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":BH", OracleDbType.Varchar2,100),
					new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
					new OracleParameter(":LDR", OracleDbType.Varchar2,50),
					new OracleParameter(":LXDH", OracleDbType.Varchar2,25),
					new OracleParameter(":FYRQ", OracleDbType.Date),
					new OracleParameter(":FYLX", OracleDbType.Varchar2,36),
					new OracleParameter(":FYNR", OracleDbType.Clob,4000),
					new OracleParameter(":NRZY", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":YQ", OracleDbType.Varchar2,2000),
					new OracleParameter(":JBRQ", OracleDbType.Date),
					new OracleParameter(":BLQX", OracleDbType.Date),
					new OracleParameter(":JBYQ", OracleDbType.Varchar2,25),
					new OracleParameter(":FPSJ", OracleDbType.Date),
					new OracleParameter(":BZ", OracleDbType.Varchar2,500),
					new OracleParameter(":LDPS", OracleDbType.Varchar2,2000),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":ZT", OracleDbType.Int32,1),
					new OracleParameter(":XBDW", OracleDbType.Varchar2,36),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000),
					new OracleParameter(":ID", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.BH;
			parameters[1].Value = model.SJBH;
			parameters[2].Value = model.LDR;
			parameters[3].Value = model.LXDH;
			parameters[4].Value = model.FYRQ;
			parameters[5].Value = model.FYLX;
			parameters[6].Value = model.FYNR;
			parameters[7].Value = model.NRZY;
			parameters[8].Value = model.FJDZ;
			parameters[9].Value = model.YQ;
			parameters[10].Value = model.JBRQ;
			parameters[11].Value = model.BLQX;
			parameters[12].Value = model.JBYQ;
			parameters[13].Value = model.FPSJ;
			parameters[14].Value = model.BZ;
			parameters[15].Value = model.LDPS;
			parameters[16].Value = model.CJR;
			parameters[17].Value = model.CJSJ;
			parameters[18].Value = model.ZT;
			parameters[19].Value = model.XBDW;
			parameters[20].Value = model.FJM;
			parameters[21].Value = model.ID;

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
			strSql.Append("delete from CON_YESSW ");
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
			strSql.Append("delete from CON_YESSW ");
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
		public Model.CON_YESSW GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BH,SJBH,LDR,LXDH,FYRQ,FYLX,FYNR,NRZY,FJDZ,YQ,JBRQ,BLQX,JBYQ,FPSJ,BZ,LDPS,CJR,CJSJ,ZT,XBDW,FJM from CON_YESSW ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			Model.CON_YESSW model=new Model.CON_YESSW();
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
		public Model.CON_YESSW DataRowToModel(DataRow row)
		{
			Model.CON_YESSW model=new Model.CON_YESSW();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["BH"]!=null)
				{
					model.BH=row["BH"].ToString();
				}
				if(row["SJBH"]!=null)
				{
					model.SJBH=row["SJBH"].ToString();
				}
				if(row["LDR"]!=null)
				{
					model.LDR=row["LDR"].ToString();
				}
				if(row["LXDH"]!=null)
				{
					model.LXDH=row["LXDH"].ToString();
				}
				if(row["FYRQ"]!=null && row["FYRQ"].ToString()!="")
				{
					model.FYRQ=DateTime.Parse(row["FYRQ"].ToString());
				}
				if(row["FYLX"]!=null)
				{
					model.FYLX=row["FYLX"].ToString();
				}
					//model.FYNR=row["FYNR"].ToString();
				if(row["NRZY"]!=null)
				{
					model.NRZY=row["NRZY"].ToString();
				}
				if(row["FJDZ"]!=null)
				{
					model.FJDZ=row["FJDZ"].ToString();
				}
				if(row["YQ"]!=null)
				{
					model.YQ=row["YQ"].ToString();
				}
				if(row["JBRQ"]!=null && row["JBRQ"].ToString()!="")
				{
					model.JBRQ=DateTime.Parse(row["JBRQ"].ToString());
				}
				if(row["BLQX"]!=null && row["BLQX"].ToString()!="")
				{
					model.BLQX=DateTime.Parse(row["BLQX"].ToString());
				}
				if(row["JBYQ"]!=null)
				{
					model.JBYQ=row["JBYQ"].ToString();
				}
				if(row["FPSJ"]!=null && row["FPSJ"].ToString()!="")
				{
					model.FPSJ=DateTime.Parse(row["FPSJ"].ToString());
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
				}
				if(row["LDPS"]!=null)
				{
					model.LDPS=row["LDPS"].ToString();
				}
				if(row["CJR"]!=null)
				{
					model.CJR=row["CJR"].ToString();
				}
				if(row["CJSJ"]!=null && row["CJSJ"].ToString()!="")
				{
					model.CJSJ=DateTime.Parse(row["CJSJ"].ToString());
				}
				if(row["ZT"]!=null && row["ZT"].ToString()!="")
				{
					model.ZT=decimal.Parse(row["ZT"].ToString());
				}
				if(row["XBDW"]!=null)
				{
					model.XBDW=row["XBDW"].ToString();
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
			strSql.Append("select ID,BH,SJBH,LDR,LXDH,FYRQ,FYLX,FYNR,NRZY,FJDZ,YQ,JBRQ,BLQX,JBYQ,FPSJ,BZ,LDPS,CJR,CJSJ,ZT,XBDW,FJM ");
			strSql.Append(" FROM CON_YESSW ");
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
			strSql.Append("select count(1) FROM CON_YESSW ");
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
			strSql.Append(")AS Row, T.*  from CON_YESSW T ");
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
			parameters[0].Value = "CON_YESSW";
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

