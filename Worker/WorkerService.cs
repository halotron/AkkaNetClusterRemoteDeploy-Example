using Akka.Actor;
using System;
using Topshelf;

namespace AkkaTestCluster
{
	internal class WorkerService : ServiceControl
	{
		protected ActorSystem ClusterSystem { get; set; }

		public bool Start(HostControl hostControl)
		{
			ClusterSystem = ActorSystem.Create("testsystem");
            return true;
		}

		public bool Stop(HostControl hostControl)
		{
			return true;
		}
	}
}