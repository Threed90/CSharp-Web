namespace _01.Chronometer
{
    public interface IChronometer
    {
        string GetTime { get; }

        IReadOnlyCollection<string> Laps { get; }

        void Start();
        void Stop();
        void Reset();
        string Lap();
    }
}
