using System.Collections.Generic;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    public class TodoItemService : ITodoItemService
    {
        private List<TodoItem> _todos = new List<TodoItem>();

        public TodoItemService()
        {
            for (int i = 1; i <= 5; i++)
            {
                _todos.Add(new TodoItem { Name = $"Task {i}", IsDone = i % 2 == 0 });
            }
        }

        public void AddTodo(TodoItem todoItem)
        {
            _todos.Add(todoItem);

            MessagingCenter.Instance.Send<ITodoItemService, TodoItem>(this, Messages.TodoItemsAdded, todoItem);
        }

        public void RemoveTodo(TodoItem todoItem)
        {
            _todos.Remove(todoItem);

            MessagingCenter.Instance.Send<ITodoItemService, TodoItem>(this, Messages.TodoItemsRemoved, todoItem);
        }

        public IEnumerable<TodoItem> GetAllTodos()
        {
            return _todos;
        }
    }
}
