# redshed
Red Team tools written in C#. I'm developing these tools for fun and to learn more about Red Teaming, C#, and the .NET Framework.

## Tools
- [x] Create a new user
- [ ] Print members of the local admins group
- [ ] Add a user to the local admins group
- [ ] Spawn a reverse shell
- [ ] Rename multiple files
- [ ] Read memory
- [ ] Invoke a program multiple times
- [ ] Rotate the desktop
- [ ] Raise the volume
- [ ] Play a song
- [ ] Lock the screen

## How to Compile a C# Source File into an Executable Program
**Step 1.** Using PowerShell, create an alias for the C# compiler (`csc.exe`). 
```pwsh
Set-Alias -Name "SendTo-CSharpCompiler" -Value "C:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
```

**Step 2.** Write your source code. 
```cs
// HelloWorld.cs
using System;

namespace HelloWorld {
  class Program {
    static void Main(string[] args) {
      Console.WriteLine("Hello world!");
    }
  }
}
```

**Step 3.** Compile, execute, and profit! 
```pwsh
SendTo-CSharpCompiler HelloWorld.cs
```
```pwsh
.\HelloWorld.exe
```
```pwsh
Hello world!
```

## Copyright
This project is licensed under the terms of the [MIT license](/LICENSE).