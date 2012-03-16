namespace HipChatConversations.Controllers
{
	public static class ExtensionMethods
	{
		public static bool IsBlank(this string input)
		{
			return string.IsNullOrEmpty(input);
		}
	}
}