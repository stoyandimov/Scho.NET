using Scho.NET.Configuration.Contracts;
using System;
using System.Collections;

namespace Scho.NET.Configuration
{
	public class EnvironmentConfigurationSource : IConfigurationSource
	{
		public void Populate(IConfiguration config, string prefix)
		{
			IDictionary vars = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
			foreach (DictionaryEntry v in vars)
			{
				string key = v.Key as string;
				if (!key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) continue;
				string value = v.Value as string;

				config.Set(key.Substring(prefix.Length), value);
			}
		}
	}
}