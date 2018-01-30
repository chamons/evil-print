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
