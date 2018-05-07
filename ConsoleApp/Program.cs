using ConsoleAppFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FolderFactory folderFactory = new FolderFactory();
            var fileList = folderFactory.GetFolderDetails();  

        }
    }
}
