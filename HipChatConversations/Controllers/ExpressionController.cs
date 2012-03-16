using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HipChatConversations.Models;

namespace HipChatConversations.Controllers
{
	public class ExpressionController : Controller
	{
		private Configuration _config;

		public Configuration Config
		{
			get { return _config = _config ?? new Configuration(); }
		}

		[HttpPost]
		public ActionResult Changed(Expression expression)
		{
			if (expression.IsNewlyCreated)
			{
				var client = new HipChat.HipChatClient(Config.HipChatApiToken, Config.HipChatRoomId);
				client.SendMessage(expression.Content, expression.AuthorName, Config.Notify, Config.BackgroundColor);
			}

			return new EmptyResult();
		}

		[HttpGet]
		public ActionResult Test()
		{
			return View();
		}
	}
}
