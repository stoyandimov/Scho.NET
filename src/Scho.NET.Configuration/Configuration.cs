using Scho.NET.Configuration.Contracts;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Scho.NET.Configuration
{
	public class Configuration : IConfiguration
	{
		public string Prefix { get; private set; }

		NameValueCollection _settings;

		public Configuration(IEnumerable<IConfigurationSource> sources, string prefix = "")
		{
			_settings = new NameValueCollection();
			Prefix = "";
			LoadConfiguration(sources);
		}

		public string Get(string name)
		{
			return _settings.Get(name);
		}

		public void Set(string name, string value)
		{
			_settings.Set(name, value);
		}

		private void LoadConfiguration(IEnumerable<IConfigurationSource> sources)
		{
			foreach (IConfigurationSource source in sources)
			{
				source.Populate(this, Prefix);
			}
		}
	}
}