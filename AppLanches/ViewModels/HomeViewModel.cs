using System.Collections.Generic;
using AppLanches.Models;

namespace AppLanches.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Lanche> LanchesPreferidos { get; set; }
    }
}