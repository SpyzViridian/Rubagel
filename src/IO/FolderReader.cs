namespace Spyz.Rubagel.IO;

using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

internal class FolderReader : LineReader {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private readonly bool _subdirectories;
	private readonly string _extension;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public FolderReader(string resource, string extension, bool subdirectories = true) : base(resource) {
		_subdirectories = subdirectories;
		_extension = extension;
	}

	protected override Stream GetStream() => null;

	public override void ForEachLine(LineConsumer lineConsumer) {
		SearchOption option = _subdirectories ? 
			SearchOption.AllDirectories
			: SearchOption.TopDirectoryOnly;

		string[] files = Directory.GetFiles(_resource, $"*.{_extension}", option);

		foreach (string file in files) {
			FileReader reader = new(file);
			reader.ForEachLine(lineConsumer);
		}
	}
}
