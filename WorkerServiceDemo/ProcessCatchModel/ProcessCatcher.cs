using System.Diagnostics;
using CodingTimeService.Calendar;

namespace CodingTimeService.ProcessCatchModel
{
    internal class ProcessCatcher
    {
        internal TimeSpan CatchOpenProcessTimeSpan(string processName)
        {
            var stopwatch = new Stopwatch();

            while (true)
            {
                var processList = Process.GetProcesses().ToList();
                var process = processList.Where(process => process.ProcessName.Contains(processName));

                if (process.Count() > 0)
                {
                    InsertRequest.startOfEvent = DateTime.Now;
                    stopwatch.Start();
                    while (true)
                    {
                        Thread.Sleep(TimeSpan.Parse("00:00:30"));
                        processList = Process.GetProcesses().ToList();
                        process = processList.Where(process => process.ProcessName.Contains(processName));

                        if (process.Count() == 0)
                        {
                            stopwatch.Stop();
                            return stopwatch.Elapsed;
                        }
                    }
                }
            }
        }
    }
}
