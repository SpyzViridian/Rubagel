namespace Spyz.Rubagel.IO;

using System;
using System.IO;
using System.Threading.Tasks;

internal class FolderReader : LineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private readonly bool _subdirectories;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public FolderReader(string resource, bool subdirectories = true) : base(resource) {
		_subdirectories = subdirectories;
	}

	protected override Stream GetStream() => null;

	public override void ForEachLine(LineConsumer lineConsumer) {
		SearchOption option = _subdirectories ? 
			SearchOption.AllDirectories
			: SearchOption.TopDirectoryOnly;

		string[] files = Directory.GetFiles(_resource, "*.*", option);

		foreach (string file in files) {
			FileReader reader = new(file);
			reader.ForEachLine(lineConsumer);
		}
	}
}
