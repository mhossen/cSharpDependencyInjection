using Autofac;
using log4net;
using System;

namespace ConsoleUI
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(nameof(Program));

        static void Main(string[] args)
        {
            log.Info("Blah");
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
