using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.ViewModels
{
    public class DeviceViewModel : ViewModelBase
    {
        public RelayCommand SelectDevice { get; private set; }
        public RelayCommand DeselectDevice { get; private set; }

        public string Path
        {
            get { return _deviceModel.Path; }
            set
            {
                _deviceModel.Path = value;
                RaisePropertyChanged(() => Path);
                RaisePropertyChanged(() => IsDevicePathBoxVisible);
            }
        }

        public bool IsDevicePathBoxVisible
        {
            get { return !string.IsNullOrEmpty(Path); }
        }

        private readonly Device _deviceModel;
        private readonly IPathService _pathService;

        public DeviceViewModel(IPathService pathService)
        {
            _deviceModel = new Device();
            _pathService = pathService;
            SelectDevice = new RelayCommand(DoSelectDevice);
            DeselectDevice = new RelayCommand(DoDeselectDevice);
        }

        private void DoSelectDevice()
        {
            Path = _pathService.SelectFolder();
        }

        private void DoDeselectDevice()
        {
            Path = string.Empty;
        }
    }
}