namespace Spyz.Rubagel.IO;

using System;
using System.IO;
using System.Threading.Tasks;

public abstract class LineReader : ILineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	protected string _resource;

	public string Resource => _resource;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	protected LineReader(string resource) {
		_resource = resource;
	}

	protected abstract Stream GetStream();
	protected virtual bool CanContinue(string line) => line is not null;

	public virtual void ForEachLine(LineConsumer lineConsumer) {

		ParseInfo info = new(Resource, 1, 0);
		Stream stream = GetStream();
		StreamReader reader = new(stream);
		string line;

		while (true) {
			line = reader.ReadLine();
			if (!CanContinue(line)) break;
			lineConsumer(line, info);
			info.Line++;
		}

		stream.Dispose();
	}
}
