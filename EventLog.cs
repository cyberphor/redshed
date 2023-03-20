using System;
using System.Text;

class Program {
  static void Main(string[] args) {
    StringBuilder sb = new StringBuilder();
    System.Diagnostics.EventLog log = new System.Diagnostics.EventLog("Application");
    foreach (System.Diagnostics.EventLogEntry entry in log.Entries) {
      Console.WriteLine(entry.Source);
      Console.WriteLine(entry.EntryType);
      Console.WriteLine(entry.Message);
    }
  }
}