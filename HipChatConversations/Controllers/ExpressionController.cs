using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HipChatConversations.Controllers
{
    public class ExpressionController : Controller
    {
		[HttpPost]
        public ActionResult Changed(string expression)
		{

			return new EmptyResult();
		}

    }
}
