using UnityEngine;
namespace Engine
{
		abstract public class StateBase:ScriptableObject
		{
				abstract public void Enter(Stater stater);
				private void OnEnable()
				{
						isInitialized = isCloned = false;
				}
				virtual public bool isInitialized { get; protected set; } = false;
				virtual public bool isCloned { get; protected set; } = false;
				virtual public void Exit()
				{

				}

				virtual public void Init()
				{
						isInitialized = true;
						
				}

				virtual public void Start()
				{

				}

				virtual public void Enable()
				{

				}

				virtual public void Disable()
				{

				}

				virtual public void FixedUpdate()
				{

				}

				virtual public void Update()
				{

				}

				virtual public void LateUpdate()
				{

				}

				virtual public void Destroy()
				{

				}
				public StateBase Clone()
				{
						StateBase stateCloned = Instantiate(this);
						stateCloned.isCloned = true;
						stateCloned.isInitialized = false;
						
						return stateCloned;
				}
		}

		//[CreateAssetMenu(fileName = "StateName", menuName = "Engine/States/StateName", order = 1)]
		public class StateBase<T1> : StateBase where T1 : Stater
		{
				virtual protected T1 stater { get; set; }
				public override void Enter(Stater stater)
				{
						this.stater = (T1)stater;
				}
				

		}
}