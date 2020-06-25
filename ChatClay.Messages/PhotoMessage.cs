using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClay.Messages
{
  public class PhotoMessage:ChatMessage
	{
		public string Base64Photo { get; set; }
		public string FileEnding { get; set; }
		public PhotoMessage(){}
		public PhotoMessage(string sender):base(sender)
		{
			
		}
	}
}
