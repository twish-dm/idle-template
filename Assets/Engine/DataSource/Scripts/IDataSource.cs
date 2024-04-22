namespace Engine
{
		public interface IDataSource
		{
				string Name { get; }
				object Data { get; }
				Type GetSource<Type>();
		}
}