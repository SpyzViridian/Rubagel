namespace Spyz.Rubagel.IO;

using System;

public class ConsoleReader : RubagelBase, ILineReader {

	private const string EXIT = "exit";
	private const string INPUT_CHARACTERS = ">";

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public string Resource => null;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public void ForEachLine(LineConsumer lineConsumer) {
		while(true) {
			Output.Print(INPUT_CHARACTERS, OutputColor.Cyan);
			string line = Console.ReadLine();
			if (line.Trim() == EXIT) break;
			try {
				lineConsumer(line, new(null, 0, 0));
			} catch (Exception e) {
				Output.PrintLine(e.Message, OutputColor.Red);
			}
			
		}
	}
}
