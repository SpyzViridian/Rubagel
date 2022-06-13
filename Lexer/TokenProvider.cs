namespace Spyz.Rubagel.Lexer;

using System.Collections.Generic;

public class TokenProvider : ITokenProvider {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private readonly Queue<ParsedToken> _parsedTokensQueue;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenProvider() {
		_parsedTokensQueue = new();
	}

	public void Add(ParsedToken token) => _parsedTokensQueue.Enqueue(token);

	public ParsedToken Peek() => _parsedTokensQueue.Peek();

	public ParsedToken Dequeue() => _parsedTokensQueue.Dequeue();
}
