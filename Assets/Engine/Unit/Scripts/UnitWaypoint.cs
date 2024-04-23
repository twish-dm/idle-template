using UnityEngine;
using Engine.Navigation;
namespace Engine.Entities
{
		public class UnitWaypoint : INavigationStep
		{
				public Vector3 StepPosition {get;}

				public void StepReached(GameObject entity)
				{
						Debug.Log($"Step reached {entity.name}");
				}

				public void StepStarted(GameObject entity)
				{
						Debug.Log($"Step started {entity.name}");
				}
				public UnitWaypoint(Vector3 point)
				{
						StepPosition = point;
				}

		}
}