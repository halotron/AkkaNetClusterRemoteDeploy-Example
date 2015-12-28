using System;
using Akka.Actor;

namespace Common.Actor
{
	internal class WorkerActor : UntypedActor
	{
		private IActorRef self;

		public WorkerActor(IActorRef self)
		{
			Console.WriteLine("starting a worker actor");
			this.self = self;
		}

		protected override void OnReceive(object message)
		{
			var msg = message as string;
			if(msg == "ping")
			{
				self.Tell("pong");
			}
		}
	}
}