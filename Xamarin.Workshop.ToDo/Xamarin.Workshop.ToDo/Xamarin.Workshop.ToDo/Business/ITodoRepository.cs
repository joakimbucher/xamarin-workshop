using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Workshop.ToDo.Business
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetItemsAsync();

        Task<TodoItem> GetItemAsync(int id);

        Task<int> UpdateAsync(TodoItem todoItem);

        Task<int> InsertAsync(TodoItem todoItem);

        Task<int> DeleteItemAsync(TodoItem item);
    }
}
