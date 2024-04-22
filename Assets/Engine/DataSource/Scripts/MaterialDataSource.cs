using UnityEngine;
using System;

namespace Engine
{
		[System.Serializable]
		public class MaterialDataSource : DataSource
		{
				[SerializeField] private Material m_Material;
				override public object Data { get => m_Material; }
				override public MaterialType GetSource<MaterialType>()
				{
						if (typeof(MaterialType).Equals(typeof(Material)))
								return (MaterialType)Data;
						throw new NullReferenceException($"Missing material of '{typeof(MaterialType).ToString()}'");
				}

		}

}