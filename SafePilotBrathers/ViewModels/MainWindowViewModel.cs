using SafePilotBrathers.Models;
using SafePilotBrathers.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafePilotBrathers.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private Safe _safe;

        public MainWindowViewModel()
        {
            _safe = new Safe();
        }

        public void SafeDimensions()
        {
            
        }
    }
}
