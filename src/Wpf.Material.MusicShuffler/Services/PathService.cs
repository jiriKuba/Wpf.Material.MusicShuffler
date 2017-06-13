using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.Services
{
    public class PathService : IPathService
    {
        public IEnumerable<string> GetFilesFromFolder(string folder)
        {
            return System.IO.Directory.EnumerateFiles(folder);
        }

        public string SelectFile()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = false;
                CommonFileDialogResult result = dialog.ShowDialog();
                return result == CommonFileDialogResult.Ok ? dialog.FileName : string.Empty;
            }
        }

        public IEnumerable<string> SelectFiles()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = false;
                dialog.Multiselect = true;

                CommonFileDialogResult result = dialog.ShowDialog();
                return result == CommonFileDialogResult.Ok ? dialog.FileNames : Array.Empty<string>();
            }
        }

        public string SelectFolder()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                return result == CommonFileDialogResult.Ok ? dialog.FileName : string.Empty;
            }
        }

        public IEnumerable<string> SelectFolders()
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;
                dialog.Multiselect = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                return result == CommonFileDialogResult.Ok ? dialog.FileNames : Array.Empty<string>();
            }
        }
    }
}