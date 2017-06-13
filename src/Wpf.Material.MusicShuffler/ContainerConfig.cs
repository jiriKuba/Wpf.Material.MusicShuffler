using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;
using Wpf.Material.MusicShuffler.Services;

namespace Wpf.Material.MusicShuffler
{
    public static class ContainerBuilderConfig
    {
        public static ContainerBuilder Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SettingService>().As<ISettingService>();
            builder.RegisterType<StorageService>().As<IStorageService>();
            builder.RegisterType<PathService>().As<IPathService>();
            builder.RegisterType<FileMovingService>().As<IFileMovingService>();
            builder.RegisterType<DialogService>().As<IDialogService>();

            return builder;
        }
    }
}