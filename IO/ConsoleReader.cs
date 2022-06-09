namespace Spyz.Rubagel.IO;

using System;
using System.IO;

public class ConsoleReader : ILineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public string ResourceName => null;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public void ForEachLine(Action<string> action) {
		string line;
		while(true) {
			line = Console.ReadLine();
			if (string.IsNullOrEmpty(line)) break;
			action(line);
		}
	}
}
