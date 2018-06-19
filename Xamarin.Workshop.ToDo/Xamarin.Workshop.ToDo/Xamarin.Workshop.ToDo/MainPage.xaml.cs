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
	    public MainPage()
		{
			InitializeComponent();

            var todoList = new TodoListViewModel();

		    for (int i = 1; i <= 20; i++)
		    {
		        todoList.Todos.Add(new TodoItem { Name = $"Task {i}", IsDone = i % 2 == 0});
            }

		    BindingContext = todoList;
		}
	}
}
