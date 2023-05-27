namespace _10.Chrono;

public interface IChronometer
{
    string GetTime { get; }

    List<string> Laps { get; }

    void Start();

    void Stop();

    string Lap();

    void Reset();
}
