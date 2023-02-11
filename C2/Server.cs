
using System.Net; // provides IPAddress, IPEndPoint
using System.Net.Sockets; // provides Socket, SocketType
using System.Text; // provides Encoding

namespace RedShed {
  class Server {
    public IPAddress address;
    public int port;
    public IPEndPoint endpoint;
    public Socket listener;

    public Server() {
      address = IPAddress.Parse("0.0.0.0");
      port = 4444;
      endpoint = new IPEndPoint(address, port);
      listener = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    }

    static void Main() {
      Server server = new Server();
      server.listener.Bind(server.endpoint);
      server.listener.Listen(5);
      Socket client = server.listener.Accept();
      string message = "OK";
      client.Send(Encoding.ASCII.GetBytes(message));
      client.Close();
      server.listener.Close();
    }
  }
}