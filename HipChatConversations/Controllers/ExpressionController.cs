using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HipChat;

namespace HipChatConversations.Controllers
{

	public class Expression
	{
		public string AuthorName { get; set; }
		public string Content { get; set; }
		public bool IsNewlyCreated { get; set; }
	}

    public class ExpressionController : Controller
    {
        public ActionResult Changed(Expression expression)
		{
			if (expression.IsNewlyCreated)
			{
				var token = "XXX";
				var room = 0;
				var client = new HipChat.HipChatClient(token, room);
				client.SendMessage(expression.Content, expression.AuthorName, HipChatClient.BackgroundColor.red);
			}

			return new EmptyResult();
		}

    }
}
