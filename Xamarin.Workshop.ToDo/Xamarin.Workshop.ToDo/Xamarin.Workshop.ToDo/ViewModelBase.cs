using System.ComponentModel;
using Xamarin.Forms;

namespace Xamarin.Workshop.ToDo
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase(INavigation navigation)
        {
            Navigation = navigation;
        }

        protected INavigation Navigation { get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
