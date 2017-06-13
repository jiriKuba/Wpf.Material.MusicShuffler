using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        public double WindowWidth
        {
            get { return _settingModel.WindowWidth; }
            set
            {
                _settingModel.WindowWidth = value;
                RaisePropertyChanged(() => WindowWidth);
                SaveSettingChanges();
            }
        }

        public double WindowHeight
        {
            get { return _settingModel.WindowHeight; }
            set
            {
                _settingModel.WindowHeight = value;
                RaisePropertyChanged(() => WindowHeight);
                SaveSettingChanges();
            }
        }

        public bool IsAlwaysOnTop
        {
            get { return _settingModel.IsAlwaysOnTop; }
            set
            {
                _settingModel.IsAlwaysOnTop = value;
                RaisePropertyChanged(() => IsAlwaysOnTop);
                SaveSettingChanges();
            }
        }

        private readonly Setting _settingModel;

        private readonly ISettingService _settingService;

        public SettingViewModel(ISettingService settingService)
        {
            _settingService = settingService;
            _settingModel = _settingService.GetSetting();
        }

        private void SaveSettingChanges()
        {
            _settingService.SaveSetting(_settingModel);
        }
    }
}