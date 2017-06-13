using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.Services
{
    public class FileMovingService : IFileMovingService
    {
        public void CopyFilesToDestination(IEnumerable<string> files, string destinationFolder)
        {
            var validFolder = GetValidDestinationFolder(destinationFolder);

            foreach (var file in files)
            {
                System.IO.File.Copy(file, validFolder + System.IO.Path.GetFileName(file), true);
            }
        }

        public void CopyFileToDestination(string sourceFile, string newFileName, string destinationFolder)
        {
            System.IO.File.Copy(sourceFile, destinationFolder + newFileName, true);
        }

        public string GetValidDestinationFolder(string destinationFolder)
        {
            if (!destinationFolder.EndsWith("\\"))
            {
                return destinationFolder + "\\";
            }

            return destinationFolder;
        }
    }
}