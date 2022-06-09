namespace Spyz.Rubagel;

using System.Text;

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
		string fileStr = string.IsNullOrEmpty(File) ? null : $"{File}";
		string lineStr = Line == 0 ? null : $"line {Line}";
		string columnStr = Column == 0 ? null : $"column {Column+1}";

		string[] strs = new string[] {fileStr, lineStr, columnStr};

		StringBuilder strBuilder = new();
		for(int i = 0; i < strs.Length; i++) {
			if (strs[i] is not null) strBuilder.Append(strs[i]);
			if (strBuilder.Length > 0 && i < strs.Length - 1) strBuilder.Append(", ");
		}

		return strBuilder.ToString();
	}
}
