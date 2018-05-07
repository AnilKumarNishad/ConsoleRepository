using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleAppFactory
{
    public class FolderFactory
    {
        public ICollection<ConsoleAppEntity.FolderDetails> GetFolderDetails()
        {
            
            string DriveName = Path.GetPathRoot(Environment.SystemDirectory);
            string TextWriterFilePath = DriveName + $"Temp";
            List<ConsoleAppEntity.FolderDetails> folderDetailList = new List<ConsoleAppEntity.FolderDetails>();

            DirectoryInfo d = new DirectoryInfo(DriveName);
            DirectoryInfo[] dis = d.GetDirectories();
            Console.WriteLine("Please wait while we calculating folder size...");
            foreach (var item in dis)
            {
                using (ConsoleAppEntity.FolderDetails folderDetails = new ConsoleAppEntity.FolderDetails())
                {
                    var fileSize = DirSize(item);
                    folderDetails.FolderName = item.FullName;
                    folderDetails.FolderSize = fileSize;
                    folderDetails.FolderSizeInBytes = fileSize + " bytes";
                    folderDetailList.Add(folderDetails);
                }
            }
            TextFileWriterFactory textFileWriter = new TextFileWriterFactory();
            textFileWriter.CreateFile(TextWriterFilePath, "TempTextFile.txt");
           var details= folderDetailList.OrderByDescending(C => C.FolderSize);
            foreach (var item in details)
            {
                textFileWriter.WriteText(TextWriterFilePath+ "\\TempTextFile.txt", "File Name:" + item.FolderName +" ,File Size:"+item. FolderSizeInBytes);

            }
            return details.ToList();
        }
        private long DirSize(DirectoryInfo d)
        {
            long size = 0;
            try
            {

            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            }
            catch (Exception)
            {

                return size;
            }
           
            return size;
        }
        
        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception)
            {
                
            }

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
            return files;
        }


    }
}
