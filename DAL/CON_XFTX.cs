using DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 数据访问类:CON_XFTX
	/// </summary>
	public partial class CON_XFTX
	{
		public CON_XFTX()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CON_XFTX");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			return DbHelperOra_new.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.CON_XFTX model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CON_XFTX(");
			strSql.Append("ID,XJLY,BH,SJBH,XFR,LXDH,DZYJ,DZ,FYRQ,BLQX,BT,FYNR,NRZY,YQ,FJDZ,FPSJ,JBRQ,JBYQ,LDPS,BZ,CJR,CJSJ,ZT,FJM)");
			strSql.Append(" values (");
			strSql.Append(":ID,:XJLY,:BH,:SJBH,:XFR,:LXDH,:DZYJ,:DZ,:FYRQ,:BLQX,:BT,:FYNR,:NRZY,:YQ,:FJDZ,:FPSJ,:JBRQ,:JBYQ,:LDPS,:BZ,:CJR,:CJSJ,:ZT,:FJM)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36),
					new OracleParameter(":XJLY", OracleDbType.Varchar2,36),
					new OracleParameter(":BH", OracleDbType.Varchar2,100),
					new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
					new OracleParameter(":XFR", OracleDbType.Varchar2,25),
					new OracleParameter(":LXDH", OracleDbType.Varchar2,25),
					new OracleParameter(":DZYJ", OracleDbType.Varchar2,300),
					new OracleParameter(":DZ", OracleDbType.Varchar2,300),
					new OracleParameter(":FYRQ", OracleDbType.Date),
					new OracleParameter(":BLQX", OracleDbType.Date),
					new OracleParameter(":BT", OracleDbType.Varchar2,300),
					new OracleParameter(":FYNR", OracleDbType.Clob),
					new OracleParameter(":NRZY", OracleDbType.Varchar2,4000),
					new OracleParameter(":YQ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FPSJ", OracleDbType.Date),
					new OracleParameter(":JBRQ", OracleDbType.Date),
					new OracleParameter(":JBYQ", OracleDbType.Varchar2,1000),
					new OracleParameter(":LDPS", OracleDbType.Varchar2,1000),
					new OracleParameter(":BZ", OracleDbType.Varchar2,1000),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":ZT", OracleDbType.Int32,1),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.XJLY;
			parameters[2].Value = model.BH;
			parameters[3].Value = model.SJBH;
			parameters[4].Value = model.XFR;
			parameters[5].Value = model.LXDH;
			parameters[6].Value = model.DZYJ;
			parameters[7].Value = model.DZ;
			parameters[8].Value = model.FYRQ;
			parameters[9].Value = model.BLQX;
			parameters[10].Value = model.BT;
			parameters[11].Value = model.FYNR;
			parameters[12].Value = model.NRZY;
			parameters[13].Value = model.YQ;
			parameters[14].Value = model.FJDZ;
			parameters[15].Value = model.FPSJ;
			parameters[16].Value = model.JBRQ;
			parameters[17].Value = model.JBYQ;
			parameters[18].Value = model.LDPS;
			parameters[19].Value = model.BZ;
			parameters[20].Value = model.CJR;
			parameters[21].Value = model.CJSJ;
			parameters[22].Value = model.ZT;
			parameters[23].Value = model.FJM;

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
		public bool Update(Model.CON_XFTX model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CON_XFTX set ");
			strSql.Append("XJLY=:XJLY,");
			strSql.Append("BH=:BH,");
			strSql.Append("SJBH=:SJBH,");
			strSql.Append("XFR=:XFR,");
			strSql.Append("LXDH=:LXDH,");
			strSql.Append("DZYJ=:DZYJ,");
			strSql.Append("DZ=:DZ,");
			strSql.Append("FYRQ=:FYRQ,");
			strSql.Append("BLQX=:BLQX,");
			strSql.Append("BT=:BT,");
			strSql.Append("FYNR=:FYNR,");
			strSql.Append("NRZY=:NRZY,");
			strSql.Append("YQ=:YQ,");
			strSql.Append("FJDZ=:FJDZ,");
			strSql.Append("FPSJ=:FPSJ,");
			strSql.Append("JBRQ=:JBRQ,");
			strSql.Append("JBYQ=:JBYQ,");
			strSql.Append("LDPS=:LDPS,");
			strSql.Append("BZ=:BZ,");
			strSql.Append("CJR=:CJR,");
			strSql.Append("CJSJ=:CJSJ,");
			strSql.Append("ZT=:ZT,");
			strSql.Append("FJM=:FJM");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":XJLY", OracleDbType.Varchar2,36),
					new OracleParameter(":BH", OracleDbType.Varchar2,100),
					new OracleParameter(":SJBH", OracleDbType.Varchar2,100),
					new OracleParameter(":XFR", OracleDbType.Varchar2,25),
					new OracleParameter(":LXDH", OracleDbType.Varchar2,25),
					new OracleParameter(":DZYJ", OracleDbType.Varchar2,300),
					new OracleParameter(":DZ", OracleDbType.Varchar2,300),
					new OracleParameter(":FYRQ", OracleDbType.Date),
					new OracleParameter(":BLQX", OracleDbType.Date),
					new OracleParameter(":BT", OracleDbType.Varchar2,300),
					new OracleParameter(":FYNR", OracleDbType.Clob),
					new OracleParameter(":NRZY", OracleDbType.Varchar2,4000),
					new OracleParameter(":YQ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FJDZ", OracleDbType.Varchar2,4000),
					new OracleParameter(":FPSJ", OracleDbType.Date),
					new OracleParameter(":JBRQ", OracleDbType.Date),
					new OracleParameter(":JBYQ", OracleDbType.Varchar2,1000),
					new OracleParameter(":LDPS", OracleDbType.Varchar2,1000),
					new OracleParameter(":BZ", OracleDbType.Varchar2,1000),
					new OracleParameter(":CJR", OracleDbType.Varchar2,36),
					new OracleParameter(":CJSJ", OracleDbType.Date),
					new OracleParameter(":ZT", OracleDbType.Int32,1),
					new OracleParameter(":FJM", OracleDbType.Varchar2,4000),
					new OracleParameter(":ID", OracleDbType.Varchar2,36)};
			parameters[0].Value = model.XJLY;
			parameters[1].Value = model.BH;
			parameters[2].Value = model.SJBH;
			parameters[3].Value = model.XFR;
			parameters[4].Value = model.LXDH;
			parameters[5].Value = model.DZYJ;
			parameters[6].Value = model.DZ;
			parameters[7].Value = model.FYRQ;
			parameters[8].Value = model.BLQX;
			parameters[9].Value = model.BT;
			parameters[10].Value = model.FYNR;
			parameters[11].Value = model.NRZY;
			parameters[12].Value = model.YQ;
			parameters[13].Value = model.FJDZ;
			parameters[14].Value = model.FPSJ;
			parameters[15].Value = model.JBRQ;
			parameters[16].Value = model.JBYQ;
			parameters[17].Value = model.LDPS;
			parameters[18].Value = model.BZ;
			parameters[19].Value = model.CJR;
			parameters[20].Value = model.CJSJ;
			parameters[21].Value = model.ZT;
			parameters[22].Value = model.FJM;
			parameters[23].Value = model.ID;

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
			strSql.Append("delete from CON_XFTX ");
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
			strSql.Append("delete from CON_XFTX ");
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
		public Model.CON_XFTX GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,XJLY,BH,SJBH,XFR,LXDH,DZYJ,DZ,FYRQ,BLQX,BT,FYNR,NRZY,YQ,FJDZ,FPSJ,JBRQ,JBYQ,LDPS,BZ,CJR,CJSJ,ZT,FJM from CON_XFTX ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Varchar2,36)			};
			parameters[0].Value = ID;

			Model.CON_XFTX model=new Model.CON_XFTX();
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
		public Model.CON_XFTX DataRowToModel(DataRow row)
		{
			Model.CON_XFTX model=new Model.CON_XFTX();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["XJLY"]!=null)
				{
					model.XJLY=row["XJLY"].ToString();
				}
				if(row["BH"]!=null)
				{
					model.BH=row["BH"].ToString();
				}
				if(row["SJBH"]!=null)
				{
					model.SJBH=row["SJBH"].ToString();
				}
				if(row["XFR"]!=null)
				{
					model.XFR=row["XFR"].ToString();
				}
				if(row["LXDH"]!=null)
				{
					model.LXDH=row["LXDH"].ToString();
				}
				if(row["DZYJ"]!=null)
				{
					model.DZYJ=row["DZYJ"].ToString();
				}
				if(row["DZ"]!=null)
				{
					model.DZ=row["DZ"].ToString();
				}
				if(row["FYRQ"]!=null && row["FYRQ"].ToString()!="")
				{
					model.FYRQ=DateTime.Parse(row["FYRQ"].ToString());
				}
				if(row["BLQX"]!=null && row["BLQX"].ToString()!="")
				{
					model.BLQX=DateTime.Parse(row["BLQX"].ToString());
				}
				if(row["BT"]!=null)
				{
					model.BT=row["BT"].ToString();
				}
					//model.FYNR=row["FYNR"].ToString();
				if(row["NRZY"]!=null)
				{
					model.NRZY=row["NRZY"].ToString();
				}
				if(row["YQ"]!=null)
				{
					model.YQ=row["YQ"].ToString();
				}
				if(row["FJDZ"]!=null)
				{
					model.FJDZ=row["FJDZ"].ToString();
				}
				if(row["FPSJ"]!=null && row["FPSJ"].ToString()!="")
				{
					model.FPSJ=DateTime.Parse(row["FPSJ"].ToString());
				}
				if(row["JBRQ"]!=null && row["JBRQ"].ToString()!="")
				{
					model.JBRQ=DateTime.Parse(row["JBRQ"].ToString());
				}
				if(row["JBYQ"]!=null)
				{
					model.JBYQ=row["JBYQ"].ToString();
				}
				if(row["LDPS"]!=null)
				{
					model.LDPS=row["LDPS"].ToString();
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
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
			strSql.Append("select ID,XJLY,BH,SJBH,XFR,LXDH,DZYJ,DZ,FYRQ,BLQX,BT,FYNR,NRZY,YQ,FJDZ,FPSJ,JBRQ,JBYQ,LDPS,BZ,CJR,CJSJ,ZT,FJM ");
			strSql.Append(" FROM CON_XFTX ");
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
			strSql.Append("select count(1) FROM CON_XFTX ");
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
			strSql.Append(")AS Row, T.*  from CON_XFTX T ");
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
			parameters[0].Value = "CON_XFTX";
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

