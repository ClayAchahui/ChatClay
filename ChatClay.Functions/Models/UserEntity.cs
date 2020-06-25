using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClay.Functions.Models
{
	public class UserEntity:TableEntity
	{
		public string UserId { get; set; }
		public string Room { get; set; }
		public string Color { get; set; }
		public string Avatar { get; set; }
	}
}
