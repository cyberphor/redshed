# Red Shed
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
**Step 1.** Write your source code. 
```cs
// HelloWorld.cs
using System;

namespace HelloWorld {
  class Program {
    static void Main() {
      Console.WriteLine("Hello world!");
    }
  }
}
```

**Step 3.** Compile, execute, and profit! 
```pwsh
C:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe HelloWorld.cs
```
```pwsh
.\HelloWorld.exe
```
```pwsh
Hello world!
```

**Note.** If you're using `System.Management.Automation.dll` you'll need to include the `/reference` parameter with `csc.exe`. 
```pwsh
C:\windows\Microsoft.NET\Framework\v4.0.30319\csc.exe `
/reference:'C:\Windows\assembly\GAC_MSIL\System.Management.Automation\1.0.0.0__31bf3856ad364e35\System.Management.Automation.dll' `
HelloWorld.cs
```

## Copyright
This project is licensed under the terms of the [MIT license](/LICENSE).