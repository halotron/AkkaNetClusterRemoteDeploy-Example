# AkkaNetClusterRemoteDeploy-Example
Minimal example of Akka.NET cluster with remote deploy and communication through a broadcast pool router.
When the server starts it starts to listen on the 4053 port and creates an actor called mainActor. The mainActor creates the router from configuration.
Also the server starts a timer that continouisly sends the string "ping" to mainActor.
When the mainActor receives the string it broadcasts "ping" to all workers, through the router.
The workers meanwhile gets a worker actor remote deployed to them, as specified in the hocon configuration of the server.
The worker actor has a reference to mainActor.
When the worker actor receives a message it will reply to mainActor with "pong".
