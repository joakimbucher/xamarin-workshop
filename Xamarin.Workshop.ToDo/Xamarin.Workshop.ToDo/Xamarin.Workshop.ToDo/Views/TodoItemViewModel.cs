using System.Threading.Tasks;
using Xamarin.Workshop.ToDo.Business;

namespace Xamarin.Workshop.ToDo.Views
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class TodoItemViewModel
    {
        private readonly ITodoItemService _todoItemService;
        
        public TodoItemViewModel(ITodoItemService todoItemService, TodoItem todo)
        {
            _todoItemService = todoItemService;
            TodoItem = todo;
        }

        public TodoItem TodoItem { get; }
        
        public string Name
        {
            get
            {
                return TodoItem.Name;
            }
            set
            {
                if (TodoItem.Name != value)
                {
                    TodoItem.Name = value;

                    UpdateTodoAsync();
                }
            }
        }

        public bool IsDone
        {
            get
            {
                return TodoItem.IsDone;
            }
            set
            {
                if (TodoItem.IsDone != value)
                {
                    TodoItem.IsDone = value;

                    UpdateTodoAsync();
                }
            }
        }

        private async Task UpdateTodoAsync()
        {
            await _todoItemService.UpdateTodoAsync(TodoItem);
        }
    }
}
