namespace Spyz.Rubagel;

using System;
using System.Runtime.Serialization;

[Serializable]
public class ParsingException : Exception {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------



	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public ParsingException(string message, ParseInfo parseInfo)
		: base($"{parseInfo}: {message}") { }

	protected ParsingException(SerializationInfo info, StreamingContext context)
		: base(info, context) { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		base.GetObjectData(info, context);
	}
}
