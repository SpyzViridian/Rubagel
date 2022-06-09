namespace Spyz.Rubagel.Lexer;

using Spyz.Rubagel.IO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class TokenParser : RubagelBase {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------

	private static Regex[] _cachedRegex;

	private readonly ILineReader _reader;
	private readonly IList<TokenData> _tokensData;
	private IList<ParsedToken> _tokens;

	private ParseInfo _currentParseInfo;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenParser(ILineReader lineReader, IList<TokenData> tokensData) {
		_reader = lineReader;
		_tokensData = tokensData;
	}

	public IList<ParsedToken> Parse() {
		_tokens = new List<ParsedToken>();
		_reader.ForEachLine(ParseLine);

		// Add EOF token
		TokenData eofData = new(Token.EOF, null);
		_tokens.Add(new(eofData, null, _currentParseInfo));
		
		return _tokens;
	}

	private void ParseLine(string line, ParseInfo parseInfo) {
		bool ignoring = false;

		while (parseInfo.Column < line.Length) {
			ParsedToken parsedToken = GetNextToken(line, ref parseInfo);

			if (parsedToken.Type == Token.CommentClose) {
				if (ignoring) ignoring = false;
				else throw new ParsingException($"Comments should have an opening sequence before closing them.",
					parseInfo);
			}

			if(!ignoring) {
				if (parsedToken.Type == Token.Error) {
					throw new ParsingException($"Unknown character '{line[parseInfo.Column]}'",
						parseInfo);
				} else if (parsedToken.Type == Token.CommentOpen) {
					ignoring = true;
				} else if (!parsedToken.HasFlag(TokenFlag.Ignore)) {
					_tokens.Add(parsedToken);
				}
			}
		}

		// If we're still ignoring, it's an error
		if(ignoring) {
			parseInfo.Column = line.Length - 1;
			throw new ParsingException($"Comments should have an closing sequence after opening them.",
					parseInfo);
		}

		_currentParseInfo = parseInfo;
	}

	private ParsedToken GetNextToken(string line, ref ParseInfo parseInfo) {
		foreach(TokenData tokenData in _tokensData) {
			// Get cached regex
			Regex regex = GetRegex(tokenData);
			Match match = regex.Match(line, parseInfo.Column);
			if (match.Success && match.Index == parseInfo.Column) {
				string[] groups = ToStringArray(match.Groups);
				ParsedToken parsedToken = new(tokenData, groups, parseInfo);

				// Move column forward
				parseInfo.Column += match.Length;
				return parsedToken;
			}
		}

		// Return error token
		TokenData errorToken = new(Token.Error, null);
		return new ParsedToken(errorToken, null, parseInfo);
	}

	private static string[] ToStringArray(GroupCollection groupCollection) {
		string[] array = new string[groupCollection.Count];
		for (int i = 0; i < groupCollection.Count; i++) {
			array[i] = groupCollection[i].Value;
		}
		return array;
	}

	private static Regex GetRegex(TokenData tokenData) {
		int index = (int)tokenData.Token;

		if(_cachedRegex is null) {
			int amount = Enum.GetValues<Token>().Length;
			_cachedRegex = new Regex[amount];

			return _cachedRegex[index] = tokenData.CreateRegex();
		}

		if(_cachedRegex[index] is null) {
			return _cachedRegex[index] = tokenData.CreateRegex();
		}

		return _cachedRegex[index];
	}
}
