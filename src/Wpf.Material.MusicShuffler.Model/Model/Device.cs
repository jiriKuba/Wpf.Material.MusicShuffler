using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Material.MusicShuffler.BusinessLogic.Model.Interfaces;

namespace Wpf.Material.MusicShuffler.BusinessLogic.Model
{
    public class Device : IModel
    {
        public string Path { get; set; }
    }
}