using System.Collections.Generic;

namespace HipChatConversations.Models
{
	public class Expression
	{
		public string Id { get; set; }
		public string AuthorId { get; set; }
		public string AuthorName { get; set; }
		public string Content { get; set; }
		public IEnumerable<MentionedAsset> MentionedAssets { get; set; }
		public bool IsNewlyCreated { get; set; }
	}
}