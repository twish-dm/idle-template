using System.Collections.Generic;

using UnityEngine;
namespace Engine
{
		[System.Serializable]
		public class StateMap
		{
				[SerializeField] private List<StateMapItem> m_StateList;
				[System.Serializable]
				public class StateMapItem
				{
						public string Name;
						public StateBase State;
				}

				private Dictionary<string, StateBase> m_StateMap;

				public void Init()
				{
						m_StateMap = new Dictionary<string, StateBase>();
						for (int i = 0; i < m_StateList.Count; i++)
								m_StateMap.Add(m_StateList[i].Name, m_StateList[i].State);
				}

				public StateBase First() => m_StateList[0].State;
				public StateBase GetState(string name)
				{
						return m_StateMap[name];
				}
		}
}