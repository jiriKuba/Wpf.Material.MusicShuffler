using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;

namespace Wpf.Material.MusicShuffler.BusinessLogic.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public bool IsFirstStepEnabled
        {
            get { return _mainModel.IsFirstStepEnabled; }
            set
            {
                _mainModel.IsFirstStepEnabled = value;
                RaisePropertyChanged(() => IsFirstStepEnabled);
            }
        }

        public bool IsSecondStepEnabled
        {
            get { return _mainModel.IsSecondStepEnabled; }
            set
            {
                _mainModel.IsSecondStepEnabled = value;
                RaisePropertyChanged(() => IsSecondStepEnabled);
            }
        }

        public bool IsThirdStepEnabled
        {
            get { return _mainModel.IsThirdStepEnabled; }
            set
            {
                _mainModel.IsThirdStepEnabled = value;
                RaisePropertyChanged(() => IsThirdStepEnabled);
            }
        }

        public bool IsLeftDrawerOpen
        {
            get { return _mainModel.IsLeftDrawerOpen; }
            set
            {
                _mainModel.IsLeftDrawerOpen = value;
                RaisePropertyChanged(() => IsLeftDrawerOpen);
            }
        }

        private readonly Main _mainModel;
        private readonly DeviceViewModel _deviceViewModel;
        private readonly SelectedMusicViewModel _selectedMusic;

        public MainViewModel(DeviceViewModel deviceViewModel, SelectedMusicViewModel selectedMusic)
        {
            _mainModel = new Main();
            _deviceViewModel = deviceViewModel;
            _selectedMusic = selectedMusic;

            _selectedMusic.PropertyChanged += _selectedMusic_PropertyChanged;
            _deviceViewModel.PropertyChanged += _deviceViewModel_PropertyChanged;
        }

        private void _selectedMusic_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsThirdStepEnabled = IsSecondStepEnabled && (_selectedMusic.IsMusicFilesContainerVisible || _selectedMusic.IsMusicFoldersContainerVisible);
        }

        private void _deviceViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_deviceViewModel.Path))
            {
                IsSecondStepEnabled = !string.IsNullOrEmpty(_deviceViewModel.Path);
            }
        }
    }
}