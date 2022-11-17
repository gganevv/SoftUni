using Logger.Enums;

namespace Logger.Layouts.Interfaces
{
    public interface ILayout
    {
        string Messege { get; }
        string DateTime { get; }
        ReportLevel ReportLevel { get; }

    }
}
