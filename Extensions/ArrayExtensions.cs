namespace Spyz.Rubagel.Extensions;

public static class ArrayExtensions {

	public static bool TryIndex<T>(this T[] array, int index, out T value) {
		value = default;
		if (!array.IsValidIndex(index)) return false;
		value = array[index];
		return true;
	}

	public static bool IsValidIndex<T>(this T[] array, int index) {
		return array != null && index >= 0 && index < array.Length;
	}

}
