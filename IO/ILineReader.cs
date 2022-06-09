namespace Spyz.Rubagel.IO;

using System;

public interface ILineReader : ILineProvider {
	public string ResourceName { get; }
}
