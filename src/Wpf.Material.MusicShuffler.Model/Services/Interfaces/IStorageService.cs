using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces
{
    public interface IStorageService
    {
        void SaveModel<T>(T model) where T : IModel;

        T LoadModel<T>() where T : IModel;
    }
}