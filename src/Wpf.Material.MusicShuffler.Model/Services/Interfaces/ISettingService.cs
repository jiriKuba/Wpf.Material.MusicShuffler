using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces
{
    public interface ISettingService
    {
        /// <summary>
        /// Load setting from file or create default
        /// </summary>
        Setting GetSetting();

        /// <summary>
        /// Save settings
        /// </summary>
        void SaveSetting(Setting setting);
    }
}