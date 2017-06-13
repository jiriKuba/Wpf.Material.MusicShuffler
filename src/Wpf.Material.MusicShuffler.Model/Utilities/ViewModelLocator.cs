using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Services;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;
using Wpf.Material.MusicShuffler.BusinessLogic.ViewModels;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Utilities
{
    public class ViewModelLocator
    {
        // you only need this if you'd like to use design-time data which is only supported on XAML-based platforms
        public ViewModelLocator()
        {
            //if (!ServiceLocator.IsLocationProviderSet)
            //{
            //    RegisterServices(registerFakes: true);
            //}
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public SettingViewModel Setting => ServiceLocator.Current.GetInstance<SettingViewModel>();

        public DeviceViewModel Device => ServiceLocator.Current.GetInstance<DeviceViewModel>();

        public SelectedMusicViewModel SelectedMusic => ServiceLocator.Current.GetInstance<SelectedMusicViewModel>();

        public MusicToDeviceViewModel MusicToDevice => ServiceLocator.Current.GetInstance<MusicToDeviceViewModel>();

        public static void RegisterServices(ContainerBuilder registrations = null)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().SingleInstance();
            builder.RegisterType<SettingViewModel>().SingleInstance();
            builder.RegisterType<DeviceViewModel>().SingleInstance();
            builder.RegisterType<SelectedMusicViewModel>().SingleInstance();
            builder.RegisterType<MusicToDeviceViewModel>().SingleInstance();

            var container = builder.Build();
            registrations?.Update(container);

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}