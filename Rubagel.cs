namespace Spyz.Rubagel;

using IO;
using System;

public class Rubagel : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private const string EXIT = "exit";
	private const string EXTENSION = "rgl";

	private readonly Interpreter _interpreter;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public Rubagel() {
		_interpreter = new Interpreter();
	}

	public void Test() {
		// Read .rgl files first
		string directory = Environment.CurrentDirectory;
#if NET6_0 && DEBUG
		directory = System.IO.Directory.GetParent(directory).Parent.Parent.FullName;
#endif

		FolderReader folderReader = new(directory, EXTENSION);
		try {
			_interpreter.Evaluate(folderReader);
		} catch (Exception e) {
			Output.PrintLine(e.Message, OutputColor.Red);
		}

		while (true) {
			Output.Print(">", OutputColor.Cyan);
			string line = Console.ReadLine();
			if (line == EXIT) break;

			EvaluateLine(line);
		}
	}

	private void EvaluateLine(string line) {
		try {
			_interpreter.Evaluate((StringReader)line);
		} catch (Exception e) {
			Output.PrintLine(e.Message, OutputColor.Red);
		}
		
	}

}
