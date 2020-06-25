using Acr.UserDialogs;
using ChatClay.Core.Models;
using ChatClay.Core.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatClay.ViewModels
{
	public class RoomsViewModel:FreshBasePageModel
	{
		IChatService ChatService;
		IUserDialogs Dialogs;
		bool IsBusy = false;
		string UserName;
		public List<Room> Rooms { get; set; }
		public Room CurrentRoom { get; set; }
		public ICommand EnterRoomCommand { get; set; }
		public RoomsViewModel(IChatService _chatService, IUserDialogs _dialogs)
		{
			ChatService = _chatService;
			Dialogs = _dialogs;
		}
		public override void Init(object initData)
		{
			base.Init(initData);
			UserName = initData as string;
			EnterRoomCommand = new Command(async () =>
				{
					if (!IsBusy)
					{
						IsBusy = true;
						if (CurrentRoom!=null)
						{
							Tuple<string, string> data = new Tuple<string, string>(UserName, CurrentRoom.Name);
							await CoreMethods.PushPageModel<ChatViewModel>(data);
							CurrentRoom = null;
						}
						IsBusy = false;
					}
				});
		}
		protected async override void ViewIsAppearing(object sender, EventArgs e)
		{
			base.ViewIsAppearing(sender, e);
			Dialogs.ShowLoading("Loading");
			Rooms = await ChatService.GetRooms();
			Dialogs.HideLoading();
		}
	}
}
