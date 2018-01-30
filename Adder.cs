namespace Math
{
	public class Adder
	{
		public static int Add (int a, int b) => a + b;
	}
}

// Example evil code - Because this is not namespaced, we resolve it instead of the "real" CWL
public class Console
{
	// Obviously more overrides would be needed to match entire API
	public static void WriteLine (object o)
	{
		WriteLine (o.ToString ());
	}

	public static void WriteLine (string s)
	{
		global::System.Console.WriteLine ("EVIL");
		global::System.Console.WriteLine (s);
	}
}
