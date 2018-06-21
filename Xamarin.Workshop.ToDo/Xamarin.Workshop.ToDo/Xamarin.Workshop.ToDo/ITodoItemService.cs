using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Workshop.ToDo
{
    public interface ITodoItemService
    {
        Task AddTodoAsync(TodoItem todoItem);

        Task RemoveTodoAsync(TodoItem todoItem);

        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
    }
}
