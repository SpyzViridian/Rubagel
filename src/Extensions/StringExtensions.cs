namespace Spyz.Rubagel.Extensions;

using System;

public static class StringExtensions {

	public static T ToEnum<T>(this string value) where T : struct, Enum {
		return Enum.Parse<T>(value);
	}

	public static bool TryEnum<T>(this string value, out T result) where T : struct, Enum {
		return Enum.TryParse(value, out result);
	}

}
