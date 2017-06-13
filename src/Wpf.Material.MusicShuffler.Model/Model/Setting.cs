using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Model
{
    public class Setting : IModel
    {
        public double WindowWidth { get; set; }

        public double WindowHeight { get; set; }

        public bool IsAlwaysOnTop { get; set; }

        public Setting()
        {
            WindowWidth = 500;
            WindowHeight = 400;
            IsAlwaysOnTop = false;
        }
    }
}