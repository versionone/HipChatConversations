using System.Collections.Generic;
using System.Text;
using HipChatConversations.Models;

namespace HipChatConversations.Controllers
{
	public class ExpressionFormatter
	{
		private readonly Configuration _config;
		private readonly AutoHyperlink _hyperlinker;

		public ExpressionFormatter(Configuration config)
		{
			_config = config;
			_hyperlinker = new AutoHyperlink();
		}

		public string Format(Expression expression)
		{
			var builder = new StringBuilder();
			builder.Append(_hyperlinker.Transform(expression.Content));

			builder.AppendFormat(" - <a href='{1}/conversations.v1/show?id={0}'>View Conversation</a>", expression.Id, _config.V1BaseUrl);

			if (expression.MentionedAssets != null)
			{
				builder.Append(" - ");
				expression.MentionedAssets.ForEach(
					e => builder.AppendFormat(e.Number.IsBlank() ? "{0}, " : "{0} ({1}), ", e.Name, e.Number));
				builder.Remove(builder.Length - 2, 2);
			}

			return builder.ToString();
		}
	}
}