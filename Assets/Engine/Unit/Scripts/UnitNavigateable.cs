using UnityEngine;
using UnityEngine.AI;

namespace Engine.Entities
{
		[RequireComponent(typeof(NavMeshAgent))]
		public class UnitNavigateable : Multistater
		{
				protected override void Awake()
				{
						base.Awake();
				}
		}
}