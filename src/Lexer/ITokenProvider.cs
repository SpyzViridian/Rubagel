namespace Spyz.Rubagel.Lexer;

public interface ITokenProvider {
	public ParsedToken Peek();
	public ParsedToken Dequeue();
}
