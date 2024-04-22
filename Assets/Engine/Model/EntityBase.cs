using Newtonsoft.Json;

using UnityEngine;

namespace Engine.Model
{
		[System.Serializable]
		public class EntityBase
		{

				[field: SerializeField]
				[JsonProperty("name")]
				virtual public string Name { get; set; } = "entity_name";
		}
}