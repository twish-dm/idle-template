using System.Collections;

using UnityEngine;
namespace Engine
{
		public class Stater : MonoBehaviour
		{
				[SerializeField] private StateBase _CurrentState;
				private StateBase m_CurrentState;
				virtual public StateBase CurrentState
				{
						get
						{
								return m_CurrentState;
						}
						set
						{
								ApplyState(value);
						}
				}
				virtual protected StateBase ApplyState(StateBase state)
				{
						m_CurrentState?.Exit();
						m_CurrentState = state;
						m_CurrentState.Enter(this);
						return m_CurrentState;
				}
				virtual protected void Start()
				{
						CurrentState?.Start();
				}
				virtual protected void Awake()
				{
						CurrentState?.Init();
				}
				virtual protected void OnEnable()
				{
						CurrentState?.Enable();
				}
				virtual protected void OnDisable()
				{
						CurrentState?.Disable();
				}
				virtual protected void OnDestroy()
				{
						CurrentState?.Destroy();
				}
				virtual protected void Update()
				{
						CurrentState?.Update();
				}
				virtual protected void FixedUpdate()
				{
						CurrentState?.FixedUpdate();
				}
				virtual protected void LateUpdate()
				{
						CurrentState?.LateUpdate();
				}
				private void OnValidate()
				{
						if(_CurrentState && _CurrentState != CurrentState)
						{
								CurrentState = _CurrentState;
						}
				}

		}
}