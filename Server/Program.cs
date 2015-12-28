using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Server
{
	class Program
	{
		static int Main(string[] args)
		{
			return (int)HostFactory.Run(x =>
			{
				x.SetServiceName("Server");
				x.SetDisplayName("Server");
				x.SetDescription("Server");

				x.UseAssemblyInfoForServiceInfo();
				x.RunAsLocalSystem();
				x.StartAutomatically();
				//x.UseNLog();
				x.Service<ServerService>();
				x.EnableServiceRecovery(r => r.RestartService(1));
			}
			);
		}
	}
}
