using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;
using Wpf.Material.MusicShuffler.BusinessLogic.Extensions;

namespace Wpf.Material.MusicShuffler.BusinessLogic.ViewModels
{
    public class MusicToDeviceViewModel : ViewModelBase
    {
        public RelayCommand AddMusicToDevice { get; private set; }

        private readonly IDialogService _dialogService;
        private readonly IFileMovingService _fileMovingService;
        private readonly IPathService _pathService;
        private readonly DeviceViewModel _deviceViewModel;
        private readonly SelectedMusicViewModel _selectedMusicViewModel;

        public MusicToDeviceViewModel(IDialogService dialogService, IFileMovingService fileMovingService, IPathService pathService,
            DeviceViewModel deviceViewModel, SelectedMusicViewModel selectedMusicViewModel)
        {
            _dialogService = dialogService;
            _fileMovingService = fileMovingService;
            _pathService = pathService;

            _deviceViewModel = deviceViewModel;
            _selectedMusicViewModel = selectedMusicViewModel;

            AddMusicToDevice = new RelayCommand(DoAddMusicToDevice);
        }

        private async void DoAddMusicToDevice()
        {
            var dialog = _dialogService.CreateProgressDialog();
            dialog.OpenDialog();

            //await Task.Delay(2000);

            await CopyMusicToDevice();

            dialog.CloseDialog();

            ShowFinishedDialog();
        }

        private void ShowFinishedDialog()
        {
            var finishedDialog = _dialogService.CreateMessageDialog("Done!");
            finishedDialog.OpenDialog();
        }

        private Task<bool> CopyMusicToDevice()
        {
            return Task.Run<bool>(() =>
            {
                var destination = _fileMovingService.GetValidDestinationFolder(_deviceViewModel.Path);

                var files = GetFilesFromSelection();

                var random = new Random();
                files.Shuffle(random);

                CopyFilesToDestination(files, destination);

                return true;
            });
        }

        private IList<string> GetFilesFromSelection()
        {
            var files = new List<string>();

            if (_selectedMusicViewModel.IsMusicFilesContainerVisible)
            {
                files.AddRange(_selectedMusicViewModel.MusicFiles);
            }

            if (_selectedMusicViewModel.IsMusicFoldersContainerVisible)
            {
                foreach (var folder in _selectedMusicViewModel.MusicFolders)
                {
                    files.AddRange(_pathService.GetFilesFromFolder(folder));
                }
            }

            return files;
        }

        private string GenerateNewFileName(string fileName, IList<string> files)
        {
            return $"{files.IndexOf(fileName).ToString().PadLeft(4, '0')} - {System.IO.Path.GetFileName(fileName)}";
        }

        private void CopyFilesToDestination(IList<string> files, string destination)
        {
            foreach (var file in files)
            {
                if (System.IO.Path.GetExtension(file) != Constants.Mp3FileExtension) //mp3 only so far
                {
                    continue;
                }

                var newFileName = GenerateNewFileName(file, files);
                _fileMovingService.CopyFileToDestination(file, newFileName, destination);
            }
        }
    }
}