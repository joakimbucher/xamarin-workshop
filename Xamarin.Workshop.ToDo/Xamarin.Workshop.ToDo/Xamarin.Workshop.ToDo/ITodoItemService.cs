using System.Collections.Generic;

namespace Xamarin.Workshop.ToDo
{
    interface ITodoItemService
    {
        void AddTodo(TodoItem todoItem);

        void RemoveTodo(TodoItem todoItem);

        IEnumerable<TodoItem> GetAllTodos();
    }
}
