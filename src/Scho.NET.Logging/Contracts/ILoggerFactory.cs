namespace Scho.NET.Logging.Contracts
{
	public interface ILoggerFactory
	{
		ILogger CreateLogger<T>();
		ILogger CreateLogger(string name);
	}
}