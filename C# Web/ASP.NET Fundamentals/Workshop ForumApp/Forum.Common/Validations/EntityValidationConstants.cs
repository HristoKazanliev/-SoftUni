namespace Forum.Common
{
	public static class EntityValidationConstants
	{
		public static class Post
		{
			//Title
			public const int TitleMinLength = 10;
			public const int TitleMaxLength = 50;

			//Content
			public const int ContentMinLength = 30;
			public const int ContentMaxLength = 1500;
		}
	}
}
