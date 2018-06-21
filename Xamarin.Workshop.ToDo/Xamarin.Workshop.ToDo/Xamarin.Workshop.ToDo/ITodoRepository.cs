using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Workshop.ToDo
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetItemsAsync();

        Task<TodoItem> GetItemAsync(int id);

        Task<int> SaveItemAsync(TodoItem todoItem);
        
        Task<int> DeleteItemAsync(TodoItem item);
    }
}
