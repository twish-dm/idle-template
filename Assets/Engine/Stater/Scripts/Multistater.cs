
using UnityEngine;
namespace Engine
{
		public class Multistater:Stater
		{
				[SerializeField] private StateMap m_StateMap;
				protected override void Awake()
				{
						base.Awake();
						m_StateMap.Init();
						ApplyState(m_StateMap.First());
						
				}
				virtual public StateBase ApplyState(string stateName)
				{
						ApplyState(m_StateMap.GetState(stateName));
						return CurrentState;
				}
		}
}