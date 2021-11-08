using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace AsciiRogue
{
    public class NetworkHandler
    {

        Game game;

        public NetworkHandler(Game game) {
            this.game = game;
        }

        public static void listen(object config) {
            // ref:  https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API/Writing_WebSocket_server

            // Listen on port 8080 for websocket stuff

            // When a player connects, spawn him a new character that is the `a` character 
            // at the spawn location.

            // Enter a while loop listening for messages about moving, and when those are called, 
            // move the remote player's character

            string ip = "127.0.0.1";
            int port = 8088;
            var server = new TcpListener(IPAddress.Parse(ip), port);

            server.Start();

            Console.WriteLine("Server has started on {0}:{1}, Waiting for a connection...", ip, port);

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("A client connected.");

            NetworkStream stream = client.GetStream();

            while (true) {
                while (!stream.DataAvailable);
                while (client.Available < 3);

                // TODO:  
                // Print all messages read from the stream to the console.
                // Then write the code for the client to connect and have it write a message
                // every arrow key.


            }

        }

        public void listen() {

            Thread networkThread = new Thread(NetworkHandler.listen);
            networkThread.Start("127.0.0.1:8088");

        }
    }
}