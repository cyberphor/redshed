using System;
using System.DirectoryServices;

class Program {
  static void Main(string[] args) {
    try {
      DirectoryEntry AD = new DirectoryEntry("WinNT://" + Environment.MachineName + ", computer");
      DirectoryEntry NewUser = AD.Children.Add("cyberphor", "user");

      NewUser.Invoke("SetPassword", new object[] {"1234567890"});
      NewUser.Invoke("Put", new object[] {"Description", "Demo"});
      NewUser.CommitChanges();
      DirectoryEntry group;
      group = AD.Children.Find("Guests", "group");
      if (group != null) {
        group.Invoke("Add", new object[] {NewUser.Path.ToString()});
      }
      Console.WriteLine("[+] Created account.");
    } catch (Exception exception) {
      Console.WriteLine(exception.Message);
    }
  }
}