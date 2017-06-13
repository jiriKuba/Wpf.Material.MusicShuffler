using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.Controls
{
    /// <summary>
    /// Interaction logic for ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : UserControl, IDialog
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public async void OpenDialog()
        {
            await DialogHost.Show(this);
        }

        public void CloseDialog()
        {
            DialogHost.CloseDialogCommand.Execute(null, this);
        }
    }
}