using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Reflection;
using System.Linq;

namespace Engine
{
		[DefaultExecutionOrder(-100)]
		[CreateAssetMenu(fileName = "DataSources", menuName = "Engine/DataSources", order = 1)]
		public class DataSources : ScriptableObject
		{
				public static DataSources Instance { get; private set; }
				static void Initialize()
				{
						if (!Instance)
						{
								Instance = Instantiate(Resources.Load<DataSources>("DataSources"));
						}

				}

				[SerializeField] private GameObjectbDataSource[] m_Prefabs;
				[SerializeField] private MaterialDataSource[] m_Materials;
				[SerializeField] private SpriteDataSource[] m_Sprites;
				[SerializeField] private TextureDataSource[] m_Textures;
				[SerializeField] private AudioClipDataSource[] m_AudioClips;

				static private Dictionary<string, DataSource> m_DataMap = new Dictionary<string, DataSource>();

				private void OnEnable()
				{
						ApplyGameObjectbDataSource(m_Prefabs);
						ApplyGameObjectbDataSource(m_Materials);
						ApplyGameObjectbDataSource(m_Sprites);
						ApplyGameObjectbDataSource(m_Textures);
						ApplyGameObjectbDataSource(m_AudioClips);
				}

				virtual protected void ApplyGameObjectbDataSource(DataSource[] prefabs)
				{
						for (int i = 0; i < prefabs.Length; i++)
								if (!m_DataMap.ContainsKey(prefabs[i].Name))
										m_DataMap.Add(prefabs[i].Name, prefabs[i]);
				}

				static public Type GetSource<Type>(string key)
				{
						Initialize();
						return m_DataMap[key].GetSource<Type>();
				}
				static public Type AddSource<Type>(string key, object data)
				{
						Initialize();
						if (!m_DataMap.ContainsKey(key))
						{
								m_DataMap.Add(key, DataSource.Create<DataSource>(key, data));
								return m_DataMap[key].GetSource<Type>();
						}
						throw new Exception($"Already contains key '{key}' of data({data})");
				}

				static public List<Type> GetSourceList<Type>()
				{
						Initialize();
						return m_DataMap.Values.Where(data => data.Data is Type).Select((result) => (Type)result.Data).ToList();
				}

				static public List<Type> GetSourceList<Type>(string partOfKey)
				{
						Initialize();
						return m_DataMap.Values.Where(data => data.Data is Type && data.Name.IndexOf(partOfKey) > -1).Select((result) => (Type)result.Data).ToList();
				}
		}

}