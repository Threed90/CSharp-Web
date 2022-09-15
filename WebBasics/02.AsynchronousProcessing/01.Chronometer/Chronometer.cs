using System.Diagnostics;

namespace _01.Chronometer
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch watch;
        private readonly List<string> laps;
        public Chronometer()
        {
            watch = new Stopwatch();
            this.laps = new List<string>();
        }
        public string GetTime
        {
            get
            {
                var time = watch.Elapsed;

                return $"{time.Minutes:d2}:{time.Seconds:d2}:{time.Milliseconds:d4}";
            }
        } 

        public IReadOnlyCollection<string> Laps => this.laps.AsReadOnly();

        public string Lap()
        {
            string lap = this.GetTime;
            this.laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.laps.Clear();
            watch.Reset();
        }

        public void Start()
        {
            
            watch.Start();
        }

        public void Stop()
        {
            watch.Stop();
        }
    }
}
