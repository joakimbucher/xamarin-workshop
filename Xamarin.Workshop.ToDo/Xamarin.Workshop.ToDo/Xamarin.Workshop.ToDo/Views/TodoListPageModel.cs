using System;
using System.Collections.ObjectModel;
using System.Linq;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Workshop.ToDo.Business;

namespace Xamarin.Workshop.ToDo.Views
{
    [AddINotifyPropertyChangedInterface]
    public class TodoListPageModel : FreshBasePageModel
    {
        private readonly ITodoItemService _todoItemService;

        private TodoItemViewModel _selectedTodo;

        public ObservableCollection<TodoItemViewModel> Todos { get; }

        public TodoListPageModel(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
            Todos = new ObservableCollection<TodoItemViewModel>();

            // Todo: Unsubscribe events in case the view models view would be removed from the navigation stack
            MessagingCenter.Instance.Subscribe<ITodoItemService, TodoItem>(
                this,
                Messages.TodoItemsAdded,
                (sender, todo) =>
                {
                    Todos.Add(new TodoItemViewModel(_todoItemService, todo));
                });

            MessagingCenter.Instance.Subscribe<ITodoItemService, TodoItem>(
                this,
                Messages.TodoItemsRemoved,
                (sender, todo) =>
                {
                    var vm = Todos.SingleOrDefault(t => t.TodoItem.Id == todo.Id);

                    if (vm != null)
                    {
                        Todos.Remove(vm);
                    }
                });

            AddTodoCommand = new Command(
                () =>
                {
                    CoreMethods.PushPageModel<AddTodoItemPageModel>();
                });

            DeleteTodoCommand = new Command<TodoItemViewModel>(
                async (todo) =>
                 {
                     if (await CoreMethods.DisplayAlert(
                             "Delete todo",
                             $"Do you really want to delete todo '{todo.Name}'?",
                             "Yes", "No") == false)
                     {
                         return;
                     }

                     await _todoItemService.RemoveTodoAsync(todo.TodoItem);
                     SelectedTodo = null;
                     DeleteTodoCommand.ChangeCanExecute();
                 },
                (todo) => SelectedTodo != null);
        }

        public TodoItemViewModel SelectedTodo
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

                    DeleteTodoCommand.ChangeCanExecute();
                }
            }
        }

        public StackOrientation LayoutOrientation { get; set; }

        public Command AddTodoCommand { get; }

        public Command DeleteTodoCommand { get; }

        public override void Init(object initData)
        {
            base.Init(initData);
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                var todos = await _todoItemService.GetAllTodosAsync();

                foreach (var todo in todos)
                {
                    Todos.Add(new TodoItemViewModel(_todoItemService, todo));
                }
            });
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            MessagingCenter.Instance.Subscribe<TodoListPage, DeviceOrientation>(
                this,
                Messages.DeviceOrientationChanged,
                (s, orientation) => UpdateLayoutOrientation(orientation));
        }

        protected override void ViewIsDisappearing(object sender, EventArgs e)
        {
            base.ViewIsDisappearing(sender, e);

            MessagingCenter.Instance.Unsubscribe<TodoListPage, DeviceOrientation>(
                this,
                Messages.DeviceOrientationChanged);
        }

        private void UpdateLayoutOrientation(DeviceOrientation orientation)
        {
            if (orientation == DeviceOrientation.Landscape 
                || orientation == DeviceOrientation.LandscapeLeft 
                || orientation == DeviceOrientation.LandscapeRight)
            {
                LayoutOrientation = StackOrientation.Horizontal;
            }
            else
            {
                LayoutOrientation = StackOrientation.Vertical;
            }
        }
    }
}
