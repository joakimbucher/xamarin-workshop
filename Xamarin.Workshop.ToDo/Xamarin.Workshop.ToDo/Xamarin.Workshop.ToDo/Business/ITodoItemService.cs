using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Workshop.ToDo.Business
{
    public interface ITodoItemService
    {
        Task InsertTodoAsync(TodoItem todoItem);

        Task UpdateTodoAsync(TodoItem todoItem);

        Task RemoveTodoAsync(TodoItem todoItem);

        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
    }
}
