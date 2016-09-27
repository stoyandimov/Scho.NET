using Scho.NET.Configuration.Contracts;

namespace Scho.NET.Configuration
{
	public class ConfigurationProvider : IConfigurationProvider
	{
		IConfiguration _config;
		public ConfigurationProvider(IConfiguration config)
		{
			_config = config;
		}

		public string Get(string name)
		{
			return _config.Get(name);
		}
	}
}
