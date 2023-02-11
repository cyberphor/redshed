
using System; // provides Array, Console
using System.Net; // provides IPAddress, IPEndPoint
using System.Net.Sockets; // provides Socket, SocketType
using System.Text; // provides Encoding

namespace RedShed {
  class Client {
    public Socket socket;
    public int BUFFER_SIZE;
    
    public Client() {
      socket = new Socket(IPAddress.Any.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
      BUFFER_SIZE = 2048; 
    }

    static void Main() {
      Client client = new Client();
      IPAddress address = IPAddress.Parse("127.0.0.1");
      int port = 4444;
      IPEndPoint endpoint = new IPEndPoint(address, port);
      client.socket.Connect(endpoint);
      byte[] bytes = new byte[client.BUFFER_SIZE];
      Array.Clear(bytes, 0, bytes.Length); // clear the buffer, from first to last byte
      client.socket.Receive(bytes);
      string message = Encoding.ASCII.GetString(bytes).TrimEnd('\0');
      Console.WriteLine("{0}", message);
      client.socket.Close();
    }
  }
}