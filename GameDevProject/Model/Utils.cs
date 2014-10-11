using System;

namespace GameDevClone
{
	public static class Utils
	{
		public static string GetRandomString(string[] array, Random random = null)
		{
			if (random == null)
			{
				var rand = new Random();
				return array[rand.Next(0, array.Length)];
			}
			return array[random.Next(0, array.Length)];
		}

		public static T GetRandomEnum<T>(Random random = null)
		{
			var values = (T[])Enum.GetValues(typeof(T));
			return random != null ? values[random.Next(0, values.Length)] : values[new Random().Next(0, values.Length)];
		}
	}
}
