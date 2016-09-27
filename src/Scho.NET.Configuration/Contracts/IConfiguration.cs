namespace Scho.NET.Configuration.Contracts
{
	public interface IConfiguration
	{
		string Get(string name);
		void Set(string name, string value);
	}
}