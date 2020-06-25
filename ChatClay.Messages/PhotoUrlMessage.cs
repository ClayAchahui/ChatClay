using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClay.Messages
{
	public class PhotoUrlMessage:ChatMessage
	{
		public string Url { get; set; }
		public PhotoUrlMessage(){}
		public PhotoUrlMessage(string sender):base(sender)
		{

		}
	}
}
