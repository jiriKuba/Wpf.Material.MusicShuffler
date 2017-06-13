using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;
using Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces;
using Wpf.Material.MusicShuffler.Controls;

namespace Wpf.Material.MusicShuffler.Services
{
    public class DialogService : IDialogService
    {
        public IDialog CreateProgressDialog()
        {
            return new ProgressDialog();
        }

        public IDialog CreateMessageDialog(string text)
        {
            return new MessageDialog(text);
        }
    }
}