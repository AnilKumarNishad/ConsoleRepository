using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEntity
{
  public  class FolderDetails :IDisposable
    {
        public string FolderName { get; set; }
        public string FolderSizeInBytes { get; set; }
        public long FolderSize { get; set; }

        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }
    }
}
