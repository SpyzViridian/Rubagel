namespace Spyz.Rubagel;

using IO;
using Spyz.Rubagel.Lexer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Rubagel : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private const string EXIT = "exit";

	private readonly Interpreter _interpreter;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public Rubagel() {
		_interpreter = new Interpreter();
	}

	public void Test() {
		while(true) {
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
