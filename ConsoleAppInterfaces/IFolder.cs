using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppInterfaces
{
    public interface IFolder
    {
        IList<ConsoleAppEntity.FolderDetails> GetFolderDetails(string FolderPath);
    }
}
