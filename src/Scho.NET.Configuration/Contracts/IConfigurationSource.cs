namespace Scho.NET.Configuration.Contracts
{
	public interface IConfigurationSource
	{
		void Populate(IConfiguration config, string prefix);
	}
}
