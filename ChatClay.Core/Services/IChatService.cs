using ChatClay.Core.Models;
using ChatClay.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatClay.Core.Services
{
	public interface IChatService
	{
		bool IsConnected { get; }
		string ConnectionToken { get; set; }
		Task InitAsync(string userId);
		Task DisconnectAsync();
		Task SendMessageAsync(ChatMessage message);
		Task JoinChannelAsync(UserConnectedMessage message);
		Task<List<Room>> GetRooms();
		Task LeaveChannelAsync(UserConnectedMessage message);
		Task<List<User>> GetUsersGroup(string group);
		Task<User> GetUser(string userId);
	}
}
