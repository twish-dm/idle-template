using Newtonsoft.Json;
using System.Collections.Generic;

using UnityEngine;
namespace Engine.Model
{
		[System.Serializable]
		public class PlayerEntity : EntityBase
		{
				[field: SerializeField, JsonProperty("items")]
				public List<ItemEntity> Items { get; set; }

				private ItemEntity m_SoftMoney, m_HardMoney, m_Experience;
				public ItemEntity SoftMoney 
				{
						get
						{
								if (m_SoftMoney == null)
										m_SoftMoney = Items.GetEntity<ItemEntity>("soft");
								return m_SoftMoney;
						}
				}
				public ItemEntity HardMoney
				{
						get
						{
								if (m_HardMoney == null)
										m_HardMoney = Items.GetEntity<ItemEntity>("hard");
								return m_HardMoney;
						}
				}
				public ItemEntity Experience
				{
						get
						{
								if (m_Experience == null)
										m_Experience = Items.GetEntity<ItemEntity>("exp");
								return m_Experience;
						}
				}
		}
}