using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ICMSBulgaria.Utils
{
    public class FileHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}