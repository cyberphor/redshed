
using System; // provides Console
using System.Collections.ObjectModel; // provides Collection<T> 
using System.IO; // provides StringWriter
using System.Management.Automation; // provides PowerShell and PSObject

namespace RedShed {
  class Program {
    static void Main(string[] args) {
      string cmd = string.Join(" ", args);
      string output = "";
      PowerShell ps = PowerShell.Create();
      ps.AddCommand(cmd);
      StringWriter sw = new StringWriter();
      Collection<PSObject> psobjects = ps.Invoke();
      foreach(PSObject p in psobjects) {
        sw.WriteLine(p.ToString());
      }
      output = sw.ToString();
      Console.WriteLine(output);
    }
  }
}