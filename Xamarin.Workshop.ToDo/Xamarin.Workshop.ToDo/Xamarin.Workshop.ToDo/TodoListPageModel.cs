﻿using System;
using System.Collections.ObjectModel;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    [AddINotifyPropertyChangedInterface]
    public class TodoListPageModel : FreshBasePageModel
    {
        private readonly ITodoItemService _todoItemService;

        private TodoItem _selectedTodo;

        public ObservableCollection<TodoItem> Todos { get; } = new ObservableCollection<TodoItem>();

        public TodoListPageModel(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
            Todos = new ObservableCollection<TodoItem>();

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
                    CoreMethods.PushPageModel<AddTodoItemPageModel>();
                });

            DeleteTodoCommand = new Command<TodoItem>(
                async (todo) => 
                 {
                    if (await CoreMethods.DisplayAlert(
                            "Delete todo", 
                            $"Do you really want to delete todo '{todo.Name}'?",
                            "Yes", "No") == false)
                    {
                        return;
                    }

                    await _todoItemService.RemoveTodoAsync(todo);
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
                    
                    DeleteTodoCommand.ChangeCanExecute();
                }
            }
        }

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
                    Todos.Add(todo);
                }
            });
        }
    }
}
