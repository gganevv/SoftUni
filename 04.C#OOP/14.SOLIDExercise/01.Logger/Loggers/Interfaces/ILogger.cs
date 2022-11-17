namespace Logger.Loggers.Interfaces
{
    using System.Collections.Generic;

    using Appenders;
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> appenders { get; set; }
    }
}
