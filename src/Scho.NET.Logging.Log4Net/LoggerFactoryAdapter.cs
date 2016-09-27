using log4net;
using log4net.Config;
using Scho.NET.Logging.Contracts;

namespace Scho.NET.Logging.Log4Net
{
	public class LoggerFactoryAdapter : ILoggerFactory
	{

		public ILogger CreateLogger(string name)
		{
			if (!LogManager.GetRepository().Configured)
				XmlConfigurator.Configure();

			ILog log = LogManager.GetLogger(name);
			ILogger logger = new LoggerAdapter(log);
			return logger;
		}

		public ILogger CreateLogger<T>()
		{
			return CreateLogger(typeof(T).FullName);
		}
	}
}