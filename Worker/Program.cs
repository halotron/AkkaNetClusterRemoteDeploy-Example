using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace AkkaTestCluster
{
	class Program
	{
		static int Main(string[] args)
		{
			return (int)HostFactory.Run(x =>
			{
				x.SetServiceName("Worker");
				x.SetDisplayName("Worker");
				x.SetDescription("Worker");

				x.UseAssemblyInfoForServiceInfo();
				x.RunAsLocalSystem();
				x.StartAutomatically();
				//x.UseNLog();
				x.Service<WorkerService>();
				x.EnableServiceRecovery(r => r.RestartService(1));
			}
			);
		}
	}
}
