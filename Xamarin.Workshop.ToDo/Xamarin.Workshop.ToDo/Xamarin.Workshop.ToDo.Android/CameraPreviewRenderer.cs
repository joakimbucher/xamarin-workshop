using System;
using Android.Content;
using Android.Hardware;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Workshop.ToDo.Droid;

[assembly: ExportRenderer(typeof(Xamarin.Workshop.ToDo.Views.CameraPreview), typeof(CameraPreviewRenderer))]
namespace Xamarin.Workshop.ToDo.Droid
{
    public class CameraPreviewRenderer : ViewRenderer<ToDo.Views.CameraPreview, Droid.CameraPreview>
    {
        CameraPreview cameraPreview;

        public CameraPreviewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ToDo.Views.CameraPreview> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                cameraPreview = new CameraPreview(Context);
                SetNativeControl(cameraPreview);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe
                cameraPreview.Click -= OnCameraPreviewClicked;
            }

            if (e.NewElement != null)
            {
                Control.Preview = Camera.Open((int) e.NewElement.Camera);

                // Subscribe
                cameraPreview.Click += OnCameraPreviewClicked;
            }
        }

        void OnCameraPreviewClicked(object sender, EventArgs e)
        {
            if (cameraPreview.IsPreviewing)
            {
                cameraPreview.Preview.StopPreview();
                cameraPreview.IsPreviewing = false;
            }
            else
            {
                cameraPreview.Preview.StartPreview();
                cameraPreview.IsPreviewing = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Control.Preview.Release();
            }

            base.Dispose(disposing);
        }
    }
}