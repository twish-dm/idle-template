using Newtonsoft.Json;
using UnityEngine;

namespace Engine.Model
{
		[System.Serializable]
		public class GameModel : ModelBase
		{

				[field: SerializeField]
				[JsonProperty("player_entity")]
				public PlayerEntity PlayerEntity { get; set; }
		}

}