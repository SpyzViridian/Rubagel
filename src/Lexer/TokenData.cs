namespace Spyz.Rubagel.Lexer;

using System.Text.RegularExpressions;

public struct TokenData {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	public Token Token { get; set; }
	public string Pattern { get; set; }
	public TokenFlag Flags { get; set; }
	public int Precedence { get; set; }

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenData(Token token, string pattern) {
		Token = token;
		Pattern = pattern;
		Flags = TokenFlag.None;
		Precedence = 0;
	}

	public Regex CreateRegex() {
		return new Regex(Pattern);
	}

	public bool HasFlag(TokenFlag flag) {
		return Flags.HasFlag(flag);
	}

	public override string ToString() {
		return $"{Token} : {Pattern}";
	}
}
