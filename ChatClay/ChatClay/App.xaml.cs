using Acr.UserDialogs;
using ChatClay.Core.Services;
using ChatClay.ViewModels;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatClay
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			ConfigureContainer();
			var loginPage = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
			var navPage = new FreshNavigationContainer(loginPage);
			MainPage = navPage;
		}

		private void ConfigureContainer()
		{
			FreshIOC.Container.Register<IChatService, ChatService>();
			FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
