using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Workshop.ToDo.Business;

namespace Xamarin.Workshop.ToDo.Views
{
    [AddINotifyPropertyChangedInterface]
    public class AddTodoItemPageModel : FreshBasePageModel
    {
        private readonly ITodoItemService _todoItemService;

        private string _name;

        public AddTodoItemPageModel(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;

            OkCommand = new Command(
                () =>
                {
                    _todoItemService.InsertTodoAsync(new TodoItem { Name = Name });
                    CoreMethods.PopPageModel();
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
                    
                    OkCommand.ChangeCanExecute();
                }
            }
        }
        
        public Command OkCommand { get; }
    }
}
