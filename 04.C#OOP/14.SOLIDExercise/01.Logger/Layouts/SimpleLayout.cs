using Logger.Enums;
using Logger.Layouts.Interfaces;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {

        }

        public string Messege { get; private set; }

        public string DateTime { get; private set; }

        public ReportLevel ReportLevel { get; private set; }
    }
}
