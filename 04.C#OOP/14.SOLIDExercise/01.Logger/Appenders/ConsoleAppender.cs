using Logger.Enums;
using Logger.Layouts.Interfaces;

namespace Logger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        private ConsoleAppender()
        {
        }

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public int Count { get; private set; }
        public ReportLevel ReportLevel { get; internal set; }
    }
}
