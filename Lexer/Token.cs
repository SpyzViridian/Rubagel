﻿namespace Spyz.Rubagel.Lexer;

public enum Token {
	Whitespace,
	LineComment,
	CommentOpen,
	CommentClose,

	Escape,
	String,

	RuleIdentifier,
	Variable,
	Function,

	Char,
	Hex,
	Integer,
	Float,
	Boolean,

	CharType,
	IntType,
	FloatType,
	BoolType,
	StringType,

	Arrow,
	Comma,
	Semicolon,
	VerticalBar,
	LeftSquare,
	RightSquare,
	LeftKey,
	RightKey,
	LeftParen,
	RightParen,
	Hashtag,
	At,
	Dollar,

	And,
	Or,
	Not,
	Xor,

	AddAssign,
	SubAssign,
	PowerAssign,
	MultAssign,
	DivAssign,
	ModuloAssign,

	Add,
	Sub,
	Power,
	Mult,
	Div,
	Modulo,
	Equals,
	NotEquals,
	GEquals,
	LEquals,
	Less,
	Greater,
	Assign,

	BitwiseAnd,
	BitwiseOr,
	BitwiseNot,
	BitwiseXor,

	If,
	Local,
	Global,
	Context,
	Shared,
	When,
	Return,
	Define,

	Error,
	EOF,
	EOL
}