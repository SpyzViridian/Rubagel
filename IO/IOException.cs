namespace Spyz.Rubagel.IO;

using System;
using System.Runtime.Serialization;

[Serializable]
public class IOException : Exception {

	// ------------------------------------------------------------------------
	// PROPERTIES
	// ------------------------------------------------------------------------



	// ------------------------------------------------------------------------
	// METHODS
	// ------------------------------------------------------------------------

	public IOException(string message) : base(message) { }

	protected IOException(SerializationInfo info, StreamingContext context)
		: base(info, context) { }

	public override void GetObjectData(SerializationInfo info, StreamingContext context) {
		base.GetObjectData(info, context);
	}
}
