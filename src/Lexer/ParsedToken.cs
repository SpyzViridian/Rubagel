namespace Spyz.Rubagel.Lexer;

public struct ParsedToken {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public TokenData Data { get; set; }
	public string[] Groups { get; set; }
	public ParseInfo ParseInfo { get; set; }

	public string Value => Groups?[0];
	public Token Type => Data.Token;
	public int Precedence => Data.Precedence;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public ParsedToken(TokenData data, string[] groups, ParseInfo parseInfo) {
		Data = data;
		Groups = groups;
		ParseInfo = parseInfo;
	}

	public bool HasFlag(TokenFlag flag) => Data.HasFlag(flag);

	public override string ToString() {
		return $"{Type} : {Value}";
	}
}
