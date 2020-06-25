using Acr.UserDialogs;
using ChatClay.Core.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatClay.ViewModels
{
	public class LoginViewModel : FreshBasePageModel
	{
		public string UserName { get; set; }
		public bool IsBusy { get; set; }
		public ICommand ConnectCommand => new Command(async () =>
		{
			if (!IsBusy)
			{
				IsBusy = true;
				dialogs.ShowLoading("Connecting");
				await ChatService.InitAsync(UserName);
				await CoreMethods.PushPageModel<RoomsViewModel>(UserName);
				dialogs.HideLoading();
				IsBusy = false;
			}
		});

		IChatService ChatService;
		IUserDialogs dialogs;
		public LoginViewModel(IChatService _chatService,IUserDialogs _userDialogs)
		{
			ChatService = _chatService;
			dialogs = _userDialogs;
		}
	}
}
