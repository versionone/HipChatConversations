using System.Text.RegularExpressions;
using System.Web;

namespace HipChatConversations.Support
{
	public class AutoHyperlink 
	{
		private const string PATTERN =
			@"(?i)\b((?:(https?|ftp)://|www\d{0,3}[.]|[a-z0-9.\-]+[.][a-z]{2,4}/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’]))";

		public string Transform(string text)
		{
			return Regex.Replace(text, PATTERN, Replacer);
		}

		private static string Replacer(Match m)
		{
			var url = m.Value;
			return string.Format("<a href=\"{0}\">{1}</a>", HttpUtility.UrlEncode(url), url.Replace("&", "%26"));
		}

	}
}