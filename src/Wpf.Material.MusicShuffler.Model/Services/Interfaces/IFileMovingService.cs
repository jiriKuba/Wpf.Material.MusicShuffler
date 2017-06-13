using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces
{
    public interface IFileMovingService
    {
        void CopyFilesToDestination(IEnumerable<string> files, string destinationFolder);

        void CopyFileToDestination(string sourceFile, string newFileName, string destinationFolder);

        string GetValidDestinationFolder(string destinationFolder);
    }
}