
using Newtonsoft.Json;

using UnityEngine;
using UnityEngine.Events;

namespace Engine.Model
{
		[System.Serializable]
		public class ItemEntity : EntityBase
		{
				[SerializeField]
				private int m_Count;
				[JsonProperty("count")]
				public int Count
				{
						get
						{
								return m_Count;
						}
						set
						{
								m_Count = value;
								OnCountChange?.Invoke(m_Count);
								Debug.Log("Changed: " + m_Count);
						}
				}

				public event UnityAction<int> OnCountChange;
		}
}