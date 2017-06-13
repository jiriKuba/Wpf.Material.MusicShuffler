using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.ViewModels
{
    public class SelectedMusicViewModel : ViewModelBase
    {
        public ObservableCollection<string> MusicFiles { get; private set; }

        public ObservableCollection<string> MusicFolders { get; private set; }

        public bool IsMusicFilesContainerVisible
        {
            get { return MusicFiles.Count > 0; }
        }

        public bool IsMusicFoldersContainerVisible
        {
            get { return MusicFolders.Count > 0; }
        }

        private int _selectedMusicFileIndex;

        public int SelectedMusicFileIndex
        {
            get { return _selectedMusicFileIndex; }
            set
            {
                DeselectMusicFile();
                RaisePropertyChanged(() => SelectedMusicFileIndex);
                DeleteMusicFileByIndex(value);
            }
        }

        private int _selectedMusicFolderIndex;

        public int SelectedMusicFolderIndex
        {
            get { return _selectedMusicFolderIndex; }
            set
            {
                DeselectMusicFolder();
                RaisePropertyChanged(() => SelectedMusicFolderIndex);
                DeleteMusicFolderByIndex(value);
            }
        }

        public RelayCommand SelectMusicFiles { get; private set; }
        public RelayCommand SelectMusicFolders { get; private set; }

        private readonly IPathService _pathService;

        public SelectedMusicViewModel(IPathService pathService)
        {
            _pathService = pathService;

            DeselectMusicFolder();
            DeselectMusicFile();

            MusicFiles = new ObservableCollection<string>();
            MusicFolders = new ObservableCollection<string>();

            MusicFiles.CollectionChanged += Collection_CollectionChanged;
            MusicFolders.CollectionChanged += Collection_CollectionChanged;

            SelectMusicFiles = new RelayCommand(DoSelectMusicFiles);
            SelectMusicFolders = new RelayCommand(DoSelectMusicFolders);
        }

        private void DoSelectMusicFiles()
        {
            var files = _pathService.SelectFiles();
            if (files.Any())
            {
                foreach (var file in files)
                {
                    MusicFiles.Add(file);
                }
            }
        }

        private void DoSelectMusicFolders()
        {
            var folders = _pathService.SelectFolders();
            if (folders.Any())
            {
                foreach (var folder in folders)
                {
                    MusicFolders.Add(folder);
                }
            }
        }

        private void DeselectMusicFolder()
        {
            _selectedMusicFolderIndex = -1;
        }

        private void DeselectMusicFile()
        {
            _selectedMusicFileIndex = -1;
        }

        private void DeleteMusicFolderByIndex(int index)
        {
            MusicFolders.RemoveAt(index);
        }

        private void DeleteMusicFileByIndex(int index)
        {
            MusicFiles.RemoveAt(index);
        }

        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(() => IsMusicFilesContainerVisible);
            RaisePropertyChanged(() => IsMusicFoldersContainerVisible);
        }
    }
}