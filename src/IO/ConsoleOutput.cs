namespace Spyz.Rubagel.IO;

using System;

public class ConsoleOutput : BaseOutput {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------



	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public override void Print(object value) {
		Console.Write(value);
	}

	public override void Print(object value, OutputColor color) {
		Console.Write(Colorize(value, color));
	}

	public override void PrintLine(object value) {
		Console.WriteLine(value);
	}

	public override void PrintLine(object value, OutputColor color) {
		Console.WriteLine(Colorize(value, color));
	}
}
