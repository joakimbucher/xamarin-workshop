using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
	public partial class MainPage : ContentPage
	{
	    private TodoListViewModel todoList;

	    public MainPage()
		{
			InitializeComponent();
		    
            todoList = new TodoListViewModel(Navigation);

		    BindingContext = todoList;
		}
	}
}
