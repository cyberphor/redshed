
using System;
using System.Net; // provides IPAddress, IPEndPoint
using System.Net.Sockets; // provides Socket, SocketType
using System.Text; // provides Encoding

namespace C2 {
  class Server {
    IPAddress ip;
    IPEndPoint address;
    Socket server;
    Socket client;
    string message;

    static void Main(string[] args) {
      ip = IPAddress.Parse("0.0.0.");
      address = new IPEndPoint(ip, 4444);
      server = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      server.Bind(address);
      server.Listen(5);
      message = "OK";
      client = server.Accept();
      client.Send(Encoding.ASCII.GetBytes(message));
      client.Close();
      server.Close();
    }
  }
}