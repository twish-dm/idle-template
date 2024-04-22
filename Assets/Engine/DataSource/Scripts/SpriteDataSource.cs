using UnityEngine;
using System;

namespace Engine
{
		[System.Serializable]
		public class SpriteDataSource : DataSource
		{
				[SerializeField] private Sprite m_Sprite;
				override public object Data { get => m_Sprite; }
				override public SpriteType GetSource<SpriteType>()
				{
						if (typeof(SpriteType).Equals(typeof(Material)))
								return (SpriteType)Data;
						throw new NullReferenceException($"Missing material of '{typeof(SpriteType).ToString()}'");
				}

		}

}