# evil-print
Quick example showing an evil use of .NET's symbol resolution. 

When two different symbols of the same name are conflicting, if one is less nested it is preferred silently. This can be abused for awesomeness or as shown here other purposes. 

The code in Main.cs appears to use the System WriteLine method:

```
$ cat Main.cs 
using System;

namespace MyProject
{
	public static class EntryPoint
	{
		public static void Main ()
		{
			// These first two will be redirected
			Console.WriteLine ("First");
#if USE_LIBRARY
			Console.WriteLine (Math.Adder.Add (2, 2));
#endif
			// But this one will not
			System.Console.WriteLine ("Last");
		}
	}
}
```

But as the example shows, when you reference a library, that resolution can change unexpectingly.

```
$ make
csc Main.cs /nologo
mono Main.exe
First
Last
csc Adder.cs -t:library /nologo
csc Main.cs /nologo -r:Adder.dll -d:USE_LIBRARY
mono Main.exe
EVIL
First
EVIL
4
Last
```
