using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Threading.Tasks;

namespace TestArea
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();

            await scheduler.Start();


            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(a => a
                .WithIntervalInSeconds(10)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            await Task.Delay(TimeSpan.FromSeconds(60));

            await scheduler.Shutdown();
            Console.WriteLine("Kapatmak için bir tusa basın.");
            Console.ReadKey();

        }
    }
}
