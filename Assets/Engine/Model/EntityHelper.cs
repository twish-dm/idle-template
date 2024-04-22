using System.Collections.Generic;
using System.Linq;
namespace Engine.Model
{
		static public class EntityHelper
		{
				static public EntityType GetEntity<EntityType>(this List<EntityType> current, string name) where EntityType : EntityBase
				{
						return current.FirstOrDefault(entitiy => name.Equals(entitiy.Name));
				}
		}
}