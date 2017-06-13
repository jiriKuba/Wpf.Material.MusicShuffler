using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Material.MusicShuffler.BusinessLogic.Utilities;
using Wpf.Material.MusicShuffler.Views;

namespace Wpf.Material.MusicShuffler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get; private set; }
        public readonly string AppDirectory;

        public string ApplicationName { get; private set; }
        public string ApplicationNameWithVersion { get; private set; }
        public string VersionName { get; private set; }

        public App()
        {
            Instance = this;

            AppDirectory = GetAppDataPath();
            VersionName = GetVersionName();
            ApplicationName = "Music Shuffler";
            ApplicationNameWithVersion = $"{ApplicationName} {VersionName}";

            Startup += (sender, args) =>
            {
                AppStartup();
            };
        }

        public MainWindow GetMainWindow()
        {
            return ((MainWindow)Application.Current.MainWindow);
        }

        private void AppStartup()
        {
            RegisterServices();
        }

        private string GetAppDataPath()
        {
            var appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!appDirectory.EndsWith("\\"))
                appDirectory = appDirectory + "\\";

            return appDirectory;
        }

        private string GetVersionName()
        {
            var assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            return $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
        }

        private void RegisterServices()
        {
            var container = ContainerBuilderConfig.Configure();
            ViewModelLocator.RegisterServices(container);
        }
    }
}