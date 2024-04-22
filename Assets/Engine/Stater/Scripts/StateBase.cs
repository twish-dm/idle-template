using UnityEngine;
namespace Engine
{
		abstract public class StateBase:ScriptableObject
		{
				abstract public void Enter(Stater stater);

				virtual public void Exit()
				{

				}

				virtual public void Init()
				{

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

				virtual public StateBase Clone()
				{
						return Instantiate(this);
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