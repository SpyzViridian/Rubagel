namespace Spyz.Rubagel.Lexer;

using System.Collections;
using System.Collections.Generic;

public class TokenDataset : IEnumerable<TokenData> {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private readonly TokenData[] _tokensData;
	private readonly IList<TokenData> _orderedTokens;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenDataset() {
		int size = System.Enum.GetValues(typeof(Token)).Length;
		_tokensData = new TokenData[size];

		_orderedTokens = new List<TokenData>();
	}

	public TokenData this[Token token] {
		get => _tokensData[(int)token];
		set => _tokensData[(int)token] = value;
	}

	public void Add(TokenData tokenData) {
		_orderedTokens.Add(tokenData);
		this[tokenData.Token] = tokenData;
	}

	public IEnumerator<TokenData> GetEnumerator() {
		foreach (TokenData tokenData in _orderedTokens) {
			yield return tokenData;
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
