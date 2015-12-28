using Akka.Actor;
using Common.Actor;
using System;
using System.Timers;
using Topshelf;

namespace Server
{
	internal class ServerService : ServiceControl
	{
		protected ActorSystem ClusterSystem { get; set; }
		protected IActorRef MainActor { get; set; }
		protected Timer MyTimer;

		public bool Start(HostControl hostControl)
		{
			ClusterSystem = ActorSystem.Create("testsystem");
			MainActor = ClusterSystem.ActorOf(Props.Create(() => new MainActor()), "mainActor");

			MyTimer = new Timer(2000);
			MyTimer.Elapsed += MyTimer_Elapsed;
			MyTimer.Start();


			return true;
		}

		private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			MainActor.Tell("ping");

		}

		public bool Stop(HostControl hostControl)
		{
			ClusterSystem.Shutdown();
            return true;
		}
	}
}
