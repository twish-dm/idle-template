using UnityEngine;
using System;

namespace Engine
{
		public class DataSource : IDataSource
		{
				[field: SerializeField] public string Name { get; protected set; }
				virtual public object Data { get; }
				virtual public Type GetSource<Type>() { return (Type)Data; }
				public DataSource() { }
				public DataSource(string key, object data)
				{
						Name = key;
						Data = data;
				}
				public static ReturnType Create<ReturnType>(string key, object data) where ReturnType : DataSource
				{
						return (ReturnType)Activator.CreateInstance(typeof(ReturnType), key, data);
				}
		}

}