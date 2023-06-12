using System.ComponentModel.DataAnnotations;

namespace SimpleChatASP.NET.Models.Message
{
	public class MessageViewModel
	{
		[Required]
		public string Sender { get; set; } = null!;

		[Required]
		[MaxLength(255)]
		public string MessageText { get; set; } = null!;
	}
}
