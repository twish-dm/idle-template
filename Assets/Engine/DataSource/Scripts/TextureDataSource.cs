using UnityEngine;
using System;

namespace Engine
{
		[System.Serializable]
		public class TextureDataSource : DataSource
		{
				[SerializeField] private Texture m_Texture;
				override public object Data { get => m_Texture; }
				override public TextureType GetSource<TextureType>()
				{
						if (typeof(TextureType).Equals(typeof(Texture)))
								return (TextureType)Data;
						throw new NullReferenceException($"Missing material of '{typeof(TextureType).ToString()}'");
				}

		}

}