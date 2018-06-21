using System.IO;
using Xamarin.Forms;
using Xamarin.Workshop.ToDo.Droid;
using Environment = System.Environment;

//[assembly: Dependency(typeof(FileHelper))]
namespace Xamarin.Workshop.ToDo.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}