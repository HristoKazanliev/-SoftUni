using Microsoft.AspNetCore.Mvc;
using SimpleChatASP.NET.Models.Message;

namespace SimpleChatASP.Controllers
{
	public class ChatController : Controller
	{
		//A collection of messages, which has the message sender as key and the message text as value
		private static List<KeyValuePair<string, string>> s_messages = new List<KeyValuePair<string, string>>();

		public IActionResult Show()
		{
			if (s_messages.Count < 1)
			{
				return View(new ChatViewModel());
			}

			var chatModel = new ChatViewModel()
			{
				Messages = s_messages
					.Select(m => new MessageViewModel()
					{
						Sender = m.Key,
						MessageText = m.Value
					})
					.ToList()
			};

			return View(chatModel);
		}

		[HttpPost]
		public IActionResult Send(ChatViewModel chatViewModel) 
		{
			var newMessage = chatViewModel.CurrentMessage;
			s_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

			return RedirectToAction("Show");
		}
	}
}
