namespace Spyz.Rubagel.IO;

using System;
using System.IO;

public abstract class LineReader : ILineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	protected string _resource;

	public string ResourceName => _resource;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	protected LineReader(string resource) {
		_resource = resource;
	}

	protected abstract Stream GetStream();
	protected virtual bool CanContinue(string line) => line is not null;

	public virtual void ForEachLine(Action<string> action) {

		Stream stream = GetStream();
		StreamReader reader = new(stream);
		string line;

		while (true) {
			line = reader.ReadLine();
			if (!CanContinue(line)) break;
			action(line);
		}

		stream.Dispose();
	}
}
