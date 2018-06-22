using System.IO;
using Xamarin.Workshop.ToDo.Business;
using Environment = System.Environment;

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