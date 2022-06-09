namespace Spyz.Rubagel.Extensions;

using System;

public static class StringExtensions {

	public static T ToEnum<T>(this string value) where T : struct {
		return Enum.Parse<T>(value);
	}

	public static bool TryEnum<T>(this string value, out T result) where T : struct {
		return Enum.TryParse(value, out result);
	}

}
