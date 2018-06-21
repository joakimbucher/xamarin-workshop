using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoRepository _todoRepository;
        
        public TodoItemService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task AddTodoAsync(TodoItem todoItem)
        {
            await _todoRepository.SaveItemAsync(todoItem);

            MessagingCenter.Instance.Send<ITodoItemService, TodoItem>(this, Messages.TodoItemsAdded, todoItem);
        }

        public async Task RemoveTodoAsync(TodoItem todoItem)
        {
            await _todoRepository.DeleteItemAsync(todoItem);

            MessagingCenter.Instance.Send<ITodoItemService, TodoItem>(this, Messages.TodoItemsRemoved, todoItem);
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _todoRepository.GetItemsAsync();
        }
    }
}
