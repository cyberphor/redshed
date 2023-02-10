
using System;
using System.Net;
using System.Net.Sockets;

namespace Server {
  class Program {
    Socket server = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    IPEndPoint address = new IPEndPoint(IPAddress.Any, 4444);
    string message = "OK";
    
    static void Main(string[] args) {
      server.Bind(address);
      server.Listen(5);

      Socket client = server.Accept();
      client.send(Encoding.ASCII.GetBytes(message));
      
      client.close();
      server.close();
    }
  }
}