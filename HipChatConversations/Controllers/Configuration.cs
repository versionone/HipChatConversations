using System.Configuration;
using HipChat;

namespace HipChatConversations.Controllers
{
	public class Configuration
	{
		public string HipChatApiToken { get; private set; }
		public int HipChatRoomId { get; private set; }
		public HipChatClient.BackgroundColor BackgroundColor { get; private set; }
		public bool Notify { get; private set; }
	
		public Configuration()
		{
			HipChatApiToken = "XXX";
			HipChatRoomId = 0;
			BackgroundColor = HipChatClient.BackgroundColor.red;
			Notify = false;

			ReadFromConfig();
		}


		private void ReadFromConfig()
		{
			var token = ConfigurationManager.AppSettings["HipChatApiToken"];
			if (!token.IsBlank()) HipChatApiToken = token;

			var room = ConfigurationManager.AppSettings["HipChatRoomId"];
			if (!room.IsBlank())
			{
				int roomId;
				if (int.TryParse(room, out roomId))
				{
					HipChatRoomId = roomId;
				}
			}

			var color = ConfigurationManager.AppSettings["BackgroundColor"];
			if (!color.IsBlank()) BackgroundColor = ConvertToHipChatColor(color);
		}

		private HipChatClient.BackgroundColor ConvertToHipChatColor(string color)
		{
			switch (color.ToLower())
			{
				case "red":
					return HipChatClient.BackgroundColor.red;
				case "green":
					return HipChatClient.BackgroundColor.green;
				case "yellow":
					return HipChatClient.BackgroundColor.yellow;
				case "purple":
					return HipChatClient.BackgroundColor.purple;
				case "random":
				default:
					return HipChatClient.BackgroundColor.random;
			}
		}

	
	}
}