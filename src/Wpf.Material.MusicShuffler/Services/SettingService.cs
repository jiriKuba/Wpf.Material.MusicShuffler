using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.Services
{
    public class SettingService : ISettingService
    {
        private readonly IStorageService _storageService;

        public SettingService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public Setting GetSetting()
        {
            var model = _storageService.LoadModel<Setting>();
            return model == null ? new Setting() : model;
        }

        public void SaveSetting(Setting setting)
        {
            _storageService.SaveModel(setting);
        }
    }
}