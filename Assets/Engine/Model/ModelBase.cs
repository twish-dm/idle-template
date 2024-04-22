using Newtonsoft.Json;

namespace Engine.Model
{
		public class ModelBase : EntityBase
		{
				
				static public Type Deserialize<Type>(string json) where Type : ModelBase
				{
						return JsonConvert.DeserializeObject<Type>(json);
						try
						{
								
						}
						catch
						{
								throw new System.Exception($"cant deserialzie object {typeof(ModelBase).ToString()} ['{json}']");
						}
				}
				public string Serialize()
				{
						return JsonConvert.SerializeObject(this);
				}
		}

}