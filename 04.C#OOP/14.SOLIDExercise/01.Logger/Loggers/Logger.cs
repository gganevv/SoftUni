using Logger.Appenders;
using Logger.Loggers.Interfaces;
using System;
using System.Collections.Generic;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        public IReadOnlyCollection<IAppender> appenders { get; set; }
        public Logger(params IAppender[] appenders)
        {
            this.appenders = new List<IAppender>();
        }

        internal void Info(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void Warning(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void Error(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void Critical(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void Fatal(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
