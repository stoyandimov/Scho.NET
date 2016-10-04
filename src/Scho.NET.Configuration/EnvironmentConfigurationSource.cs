using Scho.NET.Configuration.Contracts;
using System;
using System.Collections;

namespace Scho.NET.Configuration
{
	/// <summary>
	/// Retrieves the unic environment variables, setup up like this
	/// [Environment]::SetEnvironmentVariable("UNIC_ENVIRONMENT", "production", "Machine")
	/// key = "environment"; value = "production"
	/// More: here https://technet.microsoft.com/en-us/library/ff730964.aspx
	/// </summary>
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