using ChatClay.Core.Helpers;
using ChatClay.Core.Services;
using ChatClay.Messages;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClay.Client
{
	class Program
	{
		static ChatService service;
		static string userName;
		static string room;

		static async Task Main(string[] args)
		{
			Console.WriteLine("User name: ");

			userName = Console.ReadLine();

			service = new ChatService();
			service.OnReceiveMessage += Service_OnReceiveMessage;


			await service.InitAsync(userName );

			Console.WriteLine("You are now connected");

			await JoinRoom();

			var keepGoing = true;
			do
			{
				var text = Console.ReadLine();
				if (text == "exit")
				{
					await service.DisconnectAsync();
					keepGoing = false;
				}
				else if (text == "leave")
				{
					var message = new UserConnectedMessage(userName, room);
					await service.LeaveChannelAsync(message);
					await JoinRoom();
				}
				else if (text == "private")
				{
					Console.WriteLine("Enter user name: ");
					var user = Console.ReadLine();

					Console.WriteLine("Enter private message: ");
					text = Console.ReadLine();

					var message = new SimpleTextMessage(userName)
					{
						Text = text,
						Recipient = user
					};
					await service.SendMessageAsync(message);
				}
				else if (text == "image")
				{
					var imagePath = @"C:\Users\cyahuira\Desktop\photo.png";
					var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
					var bytes = ImageHelper.ReadFully(imageStream);
					var base64Photo = Convert.ToBase64String(bytes);
					var message = new PhotoMessage(userName)
					{
						Base64Photo = base64Photo,
						FileEnding = imagePath.Split('.').Last(),
						GroupName = room
					};
					await service.SendMessageAsync(message);
				}
				else
				{
					var message = new SimpleTextMessage(userName)
					{
						Text = text,
						GroupName=room
					};
					await service.SendMessageAsync(message);
				}

			} while (keepGoing);
		}

		private async static Task JoinRoom()
		{
			var rooms = await service.GetRooms();
			foreach (var room in rooms)
			{
				Console.WriteLine(room.Name);

			}
			room = Console.ReadLine();
			var message = new UserConnectedMessage(userName, room);
			await service.JoinChannelAsync(message);
			var usersInRoom = await service.GetUsersGroup(room);
			Console.WriteLine($"There are currently {usersInRoom.Count} users in the room");
		}

		private static void Service_OnReceiveMessage(object sender, Core.EventHandlers.MessageEventArgs e)
		{
			if (e.Message.Sender==userName)
				return;
			if (e.Message.TypeInfo.Name == nameof(SimpleTextMessage))
			{
				var simpleText = e.Message as SimpleTextMessage;
				var message = $"{simpleText.Sender}:{simpleText.Text}";
				Console.WriteLine(message);
			}
			if (e.Message.TypeInfo.Name==nameof(UserConnectedMessage))
			{
				var userConnected = e.Message as UserConnectedMessage;
				string message = string.Empty;
				if (userConnected.IsEntering)
				{
					message = $"{userConnected.Sender} has connected";
				}
				else
				{
					message = $"{userConnected.Sender} has left";
				}
				Console.WriteLine(message);
			}
			else if (e.Message.TypeInfo.Name==nameof(PhotoUrlMessage))
			{
				var photoMessage = e.Message as PhotoUrlMessage;
				string message = $"{photoMessage.Sender} send {photoMessage.Url}";
				Console.WriteLine(message);
			}
		}
	}
}
