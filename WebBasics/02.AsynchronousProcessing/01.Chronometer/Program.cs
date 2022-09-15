namespace _01.Chronometer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IChronometer chronometer = new Chronometer();


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "exit")
                {
                    break;
                }

                Task task = Task.Run(() =>
                {
                    switch (command.ToLower())
                    {
                        case "start":
                            chronometer.Start();
                            break;
                        case "lap":
                            Console.WriteLine(chronometer.Lap());
                            break;
                        case "stop":
                            chronometer.Stop();
                            break;
                        case "laps":
                            int counter = 0;

                            foreach (var lap in chronometer.Laps)
                            {
                                Console.WriteLine($"{counter++}. {lap}");
                            }
                            break;
                        case "time":
                            Console.WriteLine(chronometer.GetTime);
                            break;
                        case "reset":
                            chronometer.Reset();
                            break;

                    }
                });

                task.Wait();
            }
            
        }
    }
}


