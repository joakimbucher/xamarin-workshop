﻿using System.IO;
using Windows.Storage;
using Xamarin.Workshop.ToDo.Business;

namespace Xamarin.Workshop.ToDo.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
