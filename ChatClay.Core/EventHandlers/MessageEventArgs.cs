using ChatClay.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClay.Core.EventHandlers
{
	public class MessageEventArgs
	{
		public ChatMessage Message { get; set; }
		public MessageEventArgs(ChatMessage message)
		{
			Message = message;
		}
	}
}
