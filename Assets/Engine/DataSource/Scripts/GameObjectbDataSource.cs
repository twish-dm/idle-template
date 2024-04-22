using UnityEngine;
using System;

namespace Engine
{
		[System.Serializable]
		public class GameObjectbDataSource : DataSource
		{
				[SerializeField] private GameObject m_Prefab;
				override public object Data { get => m_Prefab; }
				override public ComponentType GetSource<ComponentType>()
				{
						if (typeof(ComponentType).Equals(typeof(GameObject)))
								return (ComponentType)Data;

						if (m_Prefab.TryGetComponent(out ComponentType component))
								return component;
						throw new NullReferenceException($"Missing component of '{typeof(ComponentType).ToString()}'");
				}
		}

}