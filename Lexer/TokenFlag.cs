namespace Spyz.Rubagel.Lexer;

[System.Flags]
public enum TokenFlag {
	None = 0,
	Ignore = 1,
	Unary = 2,
	Binary = 4,
	Prefix = 8,
	Infix = 16,
	Postfix = 32
}
