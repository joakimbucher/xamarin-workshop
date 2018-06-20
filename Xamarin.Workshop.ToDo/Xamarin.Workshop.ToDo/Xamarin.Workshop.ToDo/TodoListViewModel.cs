using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    public class TodoListViewModel : ViewModelBase
    {
        private readonly ITodoItemService _todoItemService;

        private TodoItem _selectedTodo;

        public ObservableCollection<TodoItem> Todos { get; } = new ObservableCollection<TodoItem>();

        public TodoListViewModel(INavigation navigation)
            : base(navigation)
        {
            _todoItemService = Xamarin.Forms.DependencyService.Get<ITodoItemService>(DependencyFetchTarget.GlobalInstance);
            Todos = new ObservableCollection<TodoItem>(_todoItemService.GetAllTodos());

            // Todo: Unsubscribe events in case the view models view would be removed from the navigation stack
            MessagingCenter.Instance.Subscribe<ITodoItemService, TodoItem>(
                this,
                Messages.TodoItemsAdded,
                (sender, todo) =>
                {
                    Todos.Add(todo);
                });

            MessagingCenter.Instance.Subscribe<ITodoItemService, TodoItem>(
                this,
                Messages.TodoItemsRemoved,
                (sender, todo) =>
                {
                    Todos.Remove(todo);
                });

            AddTodoCommand = new Command(
                () =>
                {
                    Navigation.PushAsync(new AddTodoItemPage());
                });

            DeleteTodoCommand = new Command<TodoItem>(
                (todo) =>
                {
                    _todoItemService.RemoveTodo(todo);
                    SelectedTodo = null;
                    DeleteTodoCommand.ChangeCanExecute();
                },
                (todo) => SelectedTodo != null);
        }

        public TodoItem SelectedTodo
        {
            get
            {
                return _selectedTodo;
            }
            set
            {
                if (_selectedTodo != value)
                {
                    _selectedTodo = value;
                    OnPropertyChanged(nameof(SelectedTodo));

                    DeleteTodoCommand.ChangeCanExecute();
                }
            }
        }

        public Command AddTodoCommand { get; }

        public Command DeleteTodoCommand { get; }
    }
}
