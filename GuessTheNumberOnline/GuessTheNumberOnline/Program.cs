using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberOnline {
    class Program {
        static void Main(string[] args) {
            char input;

            input = Console.ReadKey().KeyChar;

            if (input == 's') {
                StartServer();
            } else {
                StartClient();
            }
        }

        static void StartServer() {
            Console.WriteLine("Server starting...");

            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localhost, 42000);
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
            Console.WriteLine("Client starting...");
            TcpClient tcpClient = new TcpClient("localHost", 42000);
            using (NetworkStream ns = tcpClient.GetStream()) {
                using (BufferedStream bs = new BufferedStream(ns)) {
                    byte[] messageBytesToSend = Encoding.UTF8.GetBytes("The client sent 'Hello world!' using TCP.");
                    bs.Write(messageBytesToSend, 0, messageBytesToSend.Length);
                }
            }

            Console.WriteLine("Main done...");
            Console.ReadKey();
        }
    }
}
