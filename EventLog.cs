using System;
using System.Text;

class Program {
  static void Main(string[] args) {
    StringBuilder sb = new StringBuilder();
    System.Diagnostics.EventLog log = new System.Diagnostics.EventLog("Security");
    foreach (System.Diagnostics.EventLogEntry entry in log.Entries) {
      // https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.eventlogentry
      if (entry.InstanceId == 4625) {
        Console.WriteLine(entry.Message);
      }
    }
  }
}