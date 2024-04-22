using System;
using System.Collections.Generic;

using UnityEngine;

namespace Engine
{
		static class DataSourcesInstance
		{
				static public Type AddData<Type>(this Type data, string key)
				{
						return DataSources.AddSource<Type>(key, data);
				}
				static public DataType GetData<DataType>(this DataType data, string key)
				{
						data = DataSources.GetSource<DataType>(key);
						Debug.Log(data);
						return data;
				}

				static public List<Type> GetDataList<Type>(this List<Type> data)
				{
						data = DataSources.GetSourceList<Type>();
						return data;
				}
				static public List<Type> GetDataList<Type>(this List<Type> data, string key)
				{
						data = DataSources.GetSourceList<Type>();
						return data;
				}
		}

}