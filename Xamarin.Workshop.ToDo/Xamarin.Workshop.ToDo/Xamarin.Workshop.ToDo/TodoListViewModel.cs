using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Workshop.ToDo
{
    public class TodoListViewModel
    {
        public List<TodoItem> Todos { get; } = new List<TodoItem>();
    }
}
