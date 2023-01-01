using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace GuessTheNumberOnline {
    class Program {
        static void Main(string[] args) {
            char input;

            input = Console.ReadKey().KeyChar;

            /*if (input == 's') {
                StartServer2();
            } else {
                StartClient2();
            }*/
        }

        /*static async void StartServer2() {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 42023);

            using (Socket listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)) {
                listener.Bind(ipEndPoint);
                listener.Listen(100);

                Socket handler = await listener.AcceptAsync();

                while (true) {
                    // Receive message
                    var buffer = new byte[1_024];
                    var received = await handler.ReceiveAsync(buffer, SocketFlags.None);
                    var response = Encoding.UTF8.GetString(buffer, 0, received);

                    string eom = "<|EOM|>";

                    if (response.IndexOf(eom) > -1) { // is end of message
                        Console.WriteLine($"Socket server received message: \"{response.Replace(eom, "")}\"");

                        string ackMessage = "<|ACK}>";
                        byte[] echoBytes = Encoding.UTF8.GetBytes(ackMessage);

                        await handler.SendAsync(echoBytes, 0);
                        Console.WriteLine($"Socket server sent acknowledgment: \"{ackMessage}\"");

                        break;
                    }

                    // Sample output:
                    //   Socket server received message: "Hi friends!"
                    //   Socket server sent acknowledgment: "<|ACK|>"

                    // https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/sockets/socket-services
                }
            }
        }*/

        /*static async void StartClient2(IPAddress serverAddress, ushort portNumber) {
            IPEndPoint ipEndPoint = new IPEndPoint(serverAddress, portNumber);

            using (Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)) {

                await client.ConnectAsync(ipEndPoint);

                while (true) {
                    // Send message.
                    string message = "Hi friends!<|EOM|>";
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);

                    _ = await client.SendAsync(messageBytes, SocketFlags.None);
                    Console.WriteLine($"Socket client sent message: \"{message}\"");

                    // Receive ACK.
                    byte[] buffer = new byte[1024];
                    var received = await client.ReceiveAsync(buffer, SocketFlags.None);
                    string response = Encoding.UTF8.GetString(buffer, 0, received);

                    if (response == "<|ACK|>") {
                        Console.WriteLine($"Socket client received acknowledgment: \"{response}\"");
                        break;
                    }

                    // Sample output:
                    //   Socket client sent message: "Hi friends!<|EOM|>"
                    //   Socket client received ackowledgment: "<|ACK|>"

                    // https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/sockets/socket-services
                }
            }
        }*/



        /*static void StartServer() {
            Console.WriteLine("Server starting...");
            // Console.WriteLine("Your IP address is: " + ShowExternalIPAddress());

            //IPAddress localhost = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 42000);
            Console.WriteLine($"Server listening on {tcpListener.LocalEndpoint.ToString()}");
            tcpListener.Start();

            Socket tcpClient = tcpListener.AcceptSocket();
            int bytesRead = 0;
            StringBuilder messageBuilder = new StringBuilder();
            using (NetworkStream ns = new NetworkStream(tcpClient)) {
                int messageChunkSize = 10;
                do {
                    byte[] chunks = new byte[messageChunkSize];
                    bytesRead = ns.Read(chunks, 0, chunks.Length);
                    messageBuilder.Append(Encoding.UTF8.GetString(chunks));
                }
                while (bytesRead != 0);
            }

            Console.WriteLine(messageBuilder.ToString());

            Console.WriteLine("Main done...");
            Console.ReadKey();
        }

        static void StartClient() {
            string serverAddress;

            Console.WriteLine("Client starting...");
            Console.WriteLine("Your IP address is: " + ShowExternalIPAddress());
            // Console.WriteLine("Server address:");
            // serverAddress = Console.ReadLine();
            serverAddress = ShowExternalIPAddress();

            if (!IPAddress.TryParse(serverAddress, out _)) {
                Console.WriteLine("Invalid IP format. Exiting program...");
                return;
            }

            TcpClient tcpClient = new TcpClient("127.0.0.1", 42000);
            using (NetworkStream ns = tcpClient.GetStream()) {
                using (BufferedStream bs = new BufferedStream(ns)) {
                    byte[] messageBytesToSend = Encoding.UTF8.GetBytes("The client sent 'Hello world!' using TCP.");
                    bs.Write(messageBytesToSend, 0, messageBytesToSend.Length);
                }
            }

            Console.WriteLine("Main done...");
            Console.ReadKey();
        }

        static string ShowExternalIPAddress(string serviceURL = "https://ipinfo.io/ip") {
            return new WebClient().DownloadString(serviceURL);
        }*/
    }
}
