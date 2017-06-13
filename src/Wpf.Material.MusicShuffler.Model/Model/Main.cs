using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Model
{
    public class Main : IModel
    {
        public bool IsFirstStepEnabled { get; set; }

        public bool IsSecondStepEnabled { get; set; }

        public bool IsThirdStepEnabled { get; set; }

        public bool IsLeftDrawerOpen { get; set; }

        public Main()
        {
            IsFirstStepEnabled = true;
        }
    }
}