namespace Spyz.Rubagel.IO;

using System;
using System.IO;

public class FileReader : LineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public FileReader(string fileName) : base(fileName) { }

	protected override Stream GetStream() {
		try {
			return new FileStream(_resource, FileMode.Open, FileAccess.Read);
		} catch (FileNotFoundException) {
			throw new IOException($"Unable to find file \"{_resource}\".");
		} catch (Exception ex) {
			throw new IOException(ex.Message);
		}
	}

}
