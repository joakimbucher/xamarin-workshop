using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    public class AddTodoItemViewModel : ViewModelBase
    {
        private readonly ITodoItemService _todoItemService;

        private string _name;

        public AddTodoItemViewModel(INavigation navigation)
            :base(navigation)
        {
            _todoItemService = DependencyService.Get<ITodoItemService>(DependencyFetchTarget.GlobalInstance);

            OkCommand = new Command(
                () =>
                {
                    _todoItemService.AddTodo(new TodoItem { Name = Name });
                    Navigation.PopAsync();
                },
                () => string.IsNullOrWhiteSpace(Name) == false);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));

                    OkCommand.ChangeCanExecute();
                }
            }
        }
        
        public Command OkCommand { get; }
    }
}
