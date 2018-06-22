using System;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Workshop.ToDo.Business;
using Xamarin.Workshop.ToDo.Views;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace Xamarin.Workshop.ToDo
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    RegisterServices();

		    InitMainPage();
		}
        
	    private static void RegisterServices()
	    {
	        FreshIOC.Container.Register<ITodoRepository, TodoRepository>().AsSingleton();
	        FreshIOC.Container.Register<ITodoItemService, TodoItemService>().AsSingleton();
	    }

	    private void InitMainPage()
	    {
	        var page = FreshPageModelResolver.ResolvePageModel<TodoListPageModel>();
	        var basicNavContainer = new FreshNavigationContainer(page);

	        MainPage = basicNavContainer;
	    }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
