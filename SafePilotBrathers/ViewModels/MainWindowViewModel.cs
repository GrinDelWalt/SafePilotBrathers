using SafePilotBrathers.Models;
using SafePilotBrathers.ViewModels.Base;

namespace SafePilotBrathers.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _title;
        private Safe _safe;
        public string Title
        {
            get => _title;
            set
            {
                //    if (Equals(_title, value)) return;
                //    _title = value;
                //    OnPropertyChanget();
                Set(ref _title, value);
            }
        }
        public MainWindowViewModel()
        {
            _title = "Сейф братьев Пилотов";
            _safe = new Safe();
        }

        public void SafeDimensions()
        {

        }
    }
}
