using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Xamarin.Workshop.ToDo
{
	public partial class TodoListPage : ContentPage
	{
	    public TodoListPage()
		{
			InitializeComponent();
		}

	    private void VisualElement_OnSizeChanged(object sender, EventArgs e)
	    {
	        if (App.Current.MainPage.Width > App.Current.MainPage.Height)
	        {
                // Horizontal (Landscape)
	            MessagingCenter.Instance.Send(this, Messages.DeviceOrientationChanged, DeviceOrientation.Landscape);
            }
	        else
	        {
                // Vertikal (Portrait)
	            MessagingCenter.Instance.Send(this, Messages.DeviceOrientationChanged, DeviceOrientation.Portrait);
            }
        }
    }
}
