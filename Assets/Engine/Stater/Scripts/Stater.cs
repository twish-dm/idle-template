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
						_CurrentState = m_CurrentState = state;
						m_CurrentState?.Enter(this);
						Debug.Log($"Enter state '{m_CurrentState}'");
						if (m_CurrentState && !m_CurrentState.isInitialized)
						{
								m_CurrentState.Init();
								Debug.Log($"Init state '{m_CurrentState}'");
						}
						Debug.Log($"isInited  '{m_CurrentState.isInitialized}'");
						return m_CurrentState;
				}
				virtual protected void Start()
				{
						if (CurrentState != null) CurrentState.Start();
				}
				virtual protected void Awake()
				{
						
				}
				virtual protected void OnEnable()
				{
						if (CurrentState != null) CurrentState?.Enable();
				}
				virtual protected void OnDisable()
				{
						if (CurrentState != null) CurrentState.Disable();
				}
				virtual protected void OnDestroy()
				{
						if (CurrentState != null) CurrentState.Destroy();
				}
				virtual protected void Update()
				{
						if(CurrentState != null) CurrentState.Update();
				}
				virtual protected void FixedUpdate()
				{
						if (CurrentState != null) CurrentState.FixedUpdate();
				}
				virtual protected void LateUpdate()
				{
						if (CurrentState != null) CurrentState.LateUpdate();
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