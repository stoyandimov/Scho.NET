namespace Scho.NET.Configuration.Contracts
{
	public interface IConfigurationProvider
	{
		string Get(string name);
	}
}
