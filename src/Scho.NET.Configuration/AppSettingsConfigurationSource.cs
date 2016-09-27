using Scho.NET.Configuration.Contracts;
using System;
using System.Configuration;

namespace Scho.NET.Configuration
{
	public class AppSettingsConfigurationSource : IConfigurationSource
	{
		public void Populate(IConfiguration config, string prefix)
		{
			foreach (string setting in ConfigurationManager.AppSettings.AllKeys)
			{
				if (!setting.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) continue;
				config.Set(setting.Substring(prefix.Length), ConfigurationManager.AppSettings[setting]);
			}
		}
	}
}