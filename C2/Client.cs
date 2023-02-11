
using System;
using System.Net; // provides IPAddress, IPEndPoint
using System.Net.Sockets; // provides Socket, SocketType
using System.Text; // provides Encoding

namespace Client {
  class Program {
    IPAddress ip;
    IPEndPoint address;
    Socket client;
    int BUFFER_SIZE;
    byte[] bytes;
    string message;

    static void Main(string[] args) {
      ip = IPAddress.Parse("127.0.0.1");
      address = new IPEndPoint(ip, 4444);
      client = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      BUFFER_SIZE = 2048;
      bytes = new byte[BUFFER_SIZE];
      client.Connect(server);
      Array.Clear(bytes, 0, bytes.Length); // clear the buffer, from first to last byte
      client.Receive(bytes);
      message = Encoding.ASCII.GetString(bytes).TrimEnd('\0');
      Console.WriteLine("{0}", message);
      client.Close();
    }
  }
}