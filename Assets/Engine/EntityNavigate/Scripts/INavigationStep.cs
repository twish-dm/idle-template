
using UnityEngine;

namespace Engine.Navigation
{
		public interface INavigationStep
		{
				Vector3 StepPosition { get; }
				void StepReached(GameObject entity);
				void StepStarted(GameObject entity);
		}
}