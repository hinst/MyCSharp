using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

using MyCSharp;

namespace MyNLog
{

	class NLogContainer
	{

		public class LoggerDictionary : Dictionary<object, Logger>
		{
		}

		protected static LoggerDictionary loggers;

		// auto-create property
		protected LoggerDictionary getLoggers()
		{
			if (loggers == null)
				loggers = new LoggerDictionary();
			return loggers;
		}

		protected LoggerDictionary Loggers
		{
			get
			{
				return getLoggers();
			}
		}

		public Logger Get(object x)
		{
			Logger result = null;
			if (Loggers.ContainsKey(x))
				result = Loggers[x];
			else
			{
				result = LogManager.GetLogger(x.GetFullClassName());
				Loggers.Add(x, result);
			}
			return result;
		}

	}

}
