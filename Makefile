all::
	csc Main.cs /nologo
	mono Main.exe
	csc Adder.cs -t:library /nologo
	csc Main.cs /nologo -r:Adder.dll -d:USE_LIBRARY
	mono Main.exe

clean::
	rm -f Main.exe
	rm -f Adder.dll
