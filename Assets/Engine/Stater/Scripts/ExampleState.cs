using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Engine
{
		[CreateAssetMenu(fileName = "ExampleState", menuName = "Engine/States/ExampleState", order = 1)]
		public class ExampleState : StateBase<Stater>
		{
				public override void Enter(Stater stater)
				{
						base.Enter(stater);
						Debug.Log($"State '{stater.name}'");
				}
		}
}