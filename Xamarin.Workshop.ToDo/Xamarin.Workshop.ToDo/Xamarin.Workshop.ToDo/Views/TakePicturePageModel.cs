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
    public class TakePicturePageModel : FreshBasePageModel
    {
        private readonly ITodoItemService _todoItemService;
        
        public TakePicturePageModel(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
           
        }

        public string Name { get; set; }
    }
}
