using CodingTimeService.Calendar;
using CodingTimeService.ProcessCatchModel;

namespace CodingTimeService
{
    public class Worker : BackgroundService
    {
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
        }

        [Obsolete]
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var minTime = "00:10:00"; // 10 minutes
            ProcessCatcher processCatcher = new();

            while (true)
            {
                InsertRequest.startOfEvent = DateTime.Now;
                var elapsedTime = processCatcher.CatchOpenProcessTimeSpan("devenv");

                if (elapsedTime >= TimeSpan.Parse(minTime))
                {
                    InsertRequest.ExecuteRequest(elapsedTime);
                }
            }
        }
    }
}
