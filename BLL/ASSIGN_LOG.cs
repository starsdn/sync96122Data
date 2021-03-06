﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
	/// <summary>
	/// 交办业务流转日志表
	/// </summary>
	public partial class ASSIGN_LOG
	{
		private readonly DAL.ASSIGN_LOG dal=new DAL.ASSIGN_LOG();
		public ASSIGN_LOG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.ASSIGN_LOG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.ASSIGN_LOG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.ASSIGN_LOG GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		///// <summary>
		///// 得到一个对象实体，从缓存中
		///// </summary>
		//public Model.ASSIGN_LOG GetModelByCache()
		//{
		//	//该表无主键信息，请自定义主键/条件字段
		//	string CacheKey = "ASSIGN_LOGModel-" ;
		//	object objModel = Common.DataCache.GetCache(CacheKey);
		//	if (objModel == null)
		//	{
		//		try
		//		{
		//			objModel = dal.GetModel();
		//			if (objModel != null)
		//			{
		//				int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
		//				Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
		//			}
		//		}
		//		catch{}
		//	}
		//	return (Model.ASSIGN_LOG)objModel;
		//}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.ASSIGN_LOG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.ASSIGN_LOG> DataTableToList(DataTable dt)
		{
			List<Model.ASSIGN_LOG> modelList = new List<Model.ASSIGN_LOG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.ASSIGN_LOG model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

