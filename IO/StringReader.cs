namespace Spyz.Rubagel.IO;

using System.Threading.Tasks;

public class StringReader : ILineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public string Resource { get; private set; }

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public StringReader(string resource) {
		Resource = resource;
	}

	public void ForEachLine(LineConsumer lineConsumer) {
		ParseInfo parseInfo = new(null, 0, 0);
		lineConsumer(Resource, parseInfo);
	}

	public static implicit operator StringReader(string resource) {
		return new StringReader(resource);
	}
}
