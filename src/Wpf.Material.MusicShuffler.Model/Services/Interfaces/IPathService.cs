using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces
{
    public interface IPathService
    {
        string SelectFile();

        IEnumerable<string> SelectFiles();

        string SelectFolder();

        IEnumerable<string> SelectFolders();

        IEnumerable<string> GetFilesFromFolder(string folder);
    }
}