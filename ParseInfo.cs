namespace Spyz.Rubagel;

public struct ParseInfo {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public string File { get; set; }
	public int Line { get; set; }
	public int Column { get; set; }

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public ParseInfo(string file, int line, int column) {
		File = file;
		Line = line;
		Column = column;
	}

	public override string ToString() {
		string fileStr = string.IsNullOrEmpty(File) ? string.Empty : $"{File}, ";
		string column = ", Column " + (Column == 0 ? string.Empty : Column.ToString());
		return $"{fileStr}Line {Line}{column}";
	}
}
