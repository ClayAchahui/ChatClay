using System;
using System.Collections.Generic;
using System.Text;

namespace ChatClay.Core
{
	public static	class Config
	{
		public static string MainEndPoint = "https://chayclayfunction.azurewebsites.net";
		public static string NegotiateEndPoint = $"{MainEndPoint}/api/negotiate";
		public static string MessageEndPoint = $"{MainEndPoint}/api/Messages";
		public static string AddToGroupEndPoint = $"{MainEndPoint}/api/AddToGroup";
		public static string LeaveGroupEndPoint = $"{MainEndPoint}/api/RemoveFromGroup";
		public static string RoomsEndPoint= $"{MainEndPoint}/api/Users";
		public static string UserEndPoint = $"{MainEndPoint}/api/User";
	}
}
