namespace Spyz.Rubagel.IO;

using System.IO;
using System.Linq;
using System.Reflection;

public class ResourceReader : LineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------


	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public ResourceReader(string resource) : base(resource) { }

	protected override Stream GetStream() {
		var assembly = Assembly.GetExecutingAssembly();
		string resource = assembly.GetManifestResourceNames()
			.Single(str => str.EndsWith(_resource));
		Stream stream = assembly.GetManifestResourceStream(resource);
		
		if(stream is null) {
			throw new IOException($"Unable to open resource '{_resource}'.");
		}

		return stream;
	}
}
