using Akka.Actor;
using Akka.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Actor
{
	public class MainActor : UntypedActor
	{
		protected IActorRef WorkerBroadcaster;
		public const string WorkerBroadcastName = "broadcaster";
		public MainActor()
		{
        }

		protected override void PreStart()
		{
			WorkerBroadcaster = Context.ActorOf(
						Props.Create(() => new WorkerActor(Self))
							.WithRouter(FromConfig.Instance), WorkerBroadcastName);
		}
		protected override void OnReceive(object message)
		{
			var msg = message as string;
			if(!string.IsNullOrEmpty(msg))
			{
				Console.WriteLine("Server got: " + msg);
			}

			if(msg  == "ping")
			{
				WorkerBroadcaster.Tell("ping");
			}
		}
	}
}
