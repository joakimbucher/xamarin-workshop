//using System;
//using System.IO;
//using Xamarin.Forms;
//using Xamarin.Workshop.ToDo.iOS;
//using Xamarin.Workshop.ToDo;

//[assembly: Dependency(typeof(FileHelper))]
//namespace Xamarin.Workshop.ToDo.iOS
//{
//    public class FileHelper : IFileHelper
//    {
//        public string GetLocalFilePath(string filename)
//        {
//            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
//            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

//            if (!Directory.Exists(libFolder))
//            {
//                Directory.CreateDirectory(libFolder);
//            }

//            return Path.Combine(libFolder, filename);
//        }
//    }
//}