using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Services.Interfaces
{
    public interface IDialogService
    {
        IDialog CreateProgressDialog();

        IDialog CreateMessageDialog(string text);
    }
}