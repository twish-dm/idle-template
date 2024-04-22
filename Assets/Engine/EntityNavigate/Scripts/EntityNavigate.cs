using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Engine.Navigation
{
		public class EntityNavigate
		{
				public EntityNavigate(float pathEndThreshold = 0.1f)
				{
						m_Targets = new Queue<INavigationStep>();
						m_PathEndThreshold = pathEndThreshold;
						IsStart = false;
						IsComplete = false;
				}
				public event UnityAction OnComplete, OnStart, OnStep;
				private NavMeshAgent m_NavMeshAgent;
				private MonoBehaviour m_Parent;
				private IEnumerator m_MoveQueue;
				private float m_PathEndThreshold = 0.1f;
				private bool m_HasPath = false;
				private Queue<INavigationStep> m_Targets;
				virtual public bool IsComplete { get; protected set; } = false;
				virtual public bool IsStart { get; protected set; } = false;
				virtual public void Init<T>(T target) where T : MonoBehaviour
				{
						m_NavMeshAgent = target.GetComponent<NavMeshAgent>();
						if (m_NavMeshAgent)
								throw new NullReferenceException($"'NavMeshAgent' not found");

						m_NavMeshAgent.avoidancePriority = UnityEngine.Random.Range(0, int.MaxValue);
						m_Parent = target;

				}

				virtual public void ApplyTarget(INavigationStep target)
				{
						m_Targets.Enqueue(target);

						if (m_MoveQueue == null)
						{
								IsStart = true;
								IsComplete = false;
								m_MoveQueue = MoveQueue();
								m_Parent.StartCoroutine(m_MoveQueue);
						}
				}
				protected Vector3 GetNavMeshPoint(Vector3 point, float maxDistance = float.MaxValue)
				{
						return NavMesh.SamplePosition(point, out NavMeshHit hit, maxDistance, m_NavMeshAgent.areaMask) ? hit.position : point;
				}

				virtual protected IEnumerator MoveQueue()
				{
						while (m_Targets.TryDequeue(out INavigationStep target))
						{
								m_NavMeshAgent.SetDestination(GetNavMeshPoint(target.StepPosition));
								target.StepStarted(m_Parent.gameObject);
								OnStart?.Invoke();
								yield return null;
								yield return new WaitWhile(() => IsEndOfPath());
								target.StepReached(m_Parent.gameObject);
								OnStep?.Invoke();
						}
						m_MoveQueue = null;
						m_HasPath = false;
						IsStart = false;
						IsComplete = true;
						OnComplete?.Invoke();
				}




				protected bool IsEndOfPath()
				{
						m_HasPath |= m_NavMeshAgent.hasPath;
						if (m_HasPath && m_NavMeshAgent.remainingDistance <= m_NavMeshAgent.stoppingDistance + m_PathEndThreshold)
						{
								// Arrived
								m_HasPath = false;
								return true;
						}

						return false;
				}
		}
}