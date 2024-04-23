using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Navigation;
namespace Engine.Entities
{
		[CreateAssetMenu(fileName = "UnitNavigateable", menuName = "Engine/States/UnitNavigateable", order = 1)]
		public class UnitNavigateState : StateBase<UnitNavigateable>
		{
				private Navigate m_Navigate;
				public override void Init()
				{
						base.Init();

						m_Navigate = new Navigate(0.1f);
						m_Navigate.Init(stater);
						Debug.Log("INIT");
				}
				public override void Enter(Stater stater)
				{
						base.Enter(stater);
				}

				public override void Update()
				{
						base.Update();
						if(Input.GetMouseButtonDown(0))
						{
								Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
								if(Physics.Raycast(ray, out RaycastHit hit, float.MaxValue))
								{
										m_Navigate.ApplyTarget(new UnitWaypoint(hit.point));
								}
						}
				}
		}
}