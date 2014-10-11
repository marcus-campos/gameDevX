namespace GameDevClone
{
	public static class EmployeeInfo
	{
		public const string writingLocalized = "Kirjoitus";

		public enum Skill
		{
			Art,
			Designing,
			Nothing,
			Programming,
			SoundEngineering,
			Writing
		}

		public static string[] FirstNames = new[]
		{
			"Bobby",
			"Gabe",
			"Markus",
			"Will",
			"Shigeru",
			"Peter",
			"John",
			"Chris"              		
		};

		public static string[] LastNames = new[]
		{
			"Kotick",
			"Newell",
			"Persson",
			"Wright",
			"Miyamoto",
			"Molyneux",
			"Romero",
			"Carmack",
			"Sawyer"              		
		};
	}
}