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
	private readonly TokenDataset _tokenDataset;
	private IList<ParsedToken> _tokens;

	private ParseInfo _currentParseInfo;
	private bool _ignoring = false;

	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public TokenParser(ILineReader lineReader, TokenDataset tokensData) {
		_reader = lineReader;
		_tokenDataset = tokensData;
	}

	public IList<ParsedToken> Parse() {
		_ignoring = false;
		_tokens = new List<ParsedToken>();
		_reader.ForEachLine(ParseLine);

		// If we're still ignoring, it's an error
		if (_ignoring) {
			throw new ParsingException($"Comments should have a closing sequence after opening them.",
					_currentParseInfo);
		}

		// Add EOF token
		TokenData eofData = new(Token.EOF, null);
		_tokens.Add(new(eofData, null, _currentParseInfo));
		
		return _tokens;
	}

	private void ParseLine(string line, ParseInfo parseInfo) {
		while (parseInfo.Column < line.Length) {

			if(_ignoring) {
				if (FindToken(line, Token.CommentClose, ref parseInfo)) {
					_ignoring = false;
				} else break; // Whole line is ignored because the comment didn't close
			} else {
				ParsedToken parsedToken = GetNextToken(line, ref parseInfo);

				if (parsedToken.Type == Token.Error) {
					throw new ParsingException($"Unknown character '{line[parseInfo.Column]}'",
						parseInfo);
				} else if (parsedToken.Type == Token.CommentOpen) {
					_ignoring = true;
				} else if (!parsedToken.HasFlag(TokenFlag.Ignore)) {
					_tokens.Add(parsedToken);
				}
			}
			
		}

		parseInfo.Column = line.Length;
		_currentParseInfo = parseInfo;
	}

	private bool FindToken(string line, Token token, ref ParseInfo parseInfo) {
		TokenData tokenData = _tokenDataset[token];

		// Get cached regex
		Regex regex = GetRegex(tokenData);
		Match match = regex.Match(line, parseInfo.Column);

		if (match.Success) {
			parseInfo.Column = match.Index + match.Length;
			return true;
		}

		return false;
	}

	private ParsedToken GetNextToken(string line, ref ParseInfo parseInfo) {
		foreach(TokenData tokenData in _tokenDataset) {
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
