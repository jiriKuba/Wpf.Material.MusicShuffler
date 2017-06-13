using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;

namespace Wpf.Material.MusicShuffler.Services
{
    public class StorageService : IStorageService
    {
        public T LoadModel<T>() where T : IModel
        {
            var fileName = GetFileNameByType<T>();
            if (!System.IO.File.Exists(fileName))
            {
                return default(T);
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(fileName));
        }

        public void SaveModel<T>(T model) where T : IModel
        {
            var fileName = GetFileNameByType<T>();

            var ser = Newtonsoft.Json.JsonConvert.SerializeObject(model);

            System.IO.File.WriteAllText(fileName, Newtonsoft.Json.JsonConvert.SerializeObject(model));
        }

        private string GetFileNameByType<T>() where T : IModel
        {
            return App.Instance.AppDirectory + typeof(T).Name + ".json";
        }
    }
}