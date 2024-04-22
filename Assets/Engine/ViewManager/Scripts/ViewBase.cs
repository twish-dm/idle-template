using System.Collections.Generic;
using System.Threading.Tasks;

using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Engine.Views
{
		public class ViewBase : MonoBehaviour
		{
				[field: SerializeField] public bool IsOverlay { get; set; }
				[SerializeField] private Image m_Background;
				[SerializeField] private RectTransform m_Content;
				public bool IsFocused { get; protected set; }

				virtual protected void OnEnable()
				{
						Color color = m_Background.color;
						color.a = 0;
						m_Background.color = color;
						m_Content.anchoredPosition = Vector2.up * 1920;
						
				}
				virtual protected void OnDisable()
				{
						Color color = m_Background.color;
						color.a = 0;
						m_Background.color = color;
						m_Content.anchoredPosition = Vector2.up * 1920;
				}
				async virtual public Task FocusIn()
				{
						IsFocused = true;
						m_Background.DOKill();
						m_Content.DOKill();

						gameObject.SetActive(true);
						m_Background.raycastTarget = true;
						transform.SetAsLastSibling();
						m_Background.DOFade(1, .25f);
						await m_Content.DOAnchorPosY(0, .5f).AsyncWaitForCompletion();
				}
				async virtual public Task FocusOut()
				{
						IsFocused = false;
						m_Background.DOKill();
						m_Content.DOKill();

						m_Background.DOFade(0, 0.25f).OnComplete(() =>
						{
								m_Background.raycastTarget = false;
						});
						await m_Content.DOAnchorPosY(-1920, 0.5f).OnComplete(() =>
						{
								gameObject.SetActive(false);

						}).AsyncWaitForCompletion();
						
				}
				protected Dictionary<string, object> data;

				virtual public void ApplyData(Dictionary<string, object> data)
				{
						this.data = data;
				}
		}
}