
using System;
using System.Net;
using System.Net.Sockets;

namespace Client {
  class Program {
    IPAddress ip = IPAddress.Parse("127.0.0.1");
    IPEndPoint server = new IPEndPoint(ip, 4444);
    
    Socket client = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    int BUFFER_SIZE = 2048;
    byte[] bytes = new byte[BUFFER_SIZE];

    static void Main(string[] args) {
      client.Connect(server);
      Array.Clear(bytes, 0, bytes.Length); // clear the buffer, from the first to last byte
      client.Receive(bytes);
      message = Encoding.ASCII.GetString(bytes).TrimEnd('\0');
      Console.WriteLine("{0}", message);
      client.Close();
    }
  }
}