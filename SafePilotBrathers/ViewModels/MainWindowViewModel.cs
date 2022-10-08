using SafePilotBrathers.Infrastructure.Commands;
using SafePilotBrathers.Models;
using SafePilotBrathers.ViewModels.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;

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
        public int SizeSafe
        {
            get => _safe.Size;
            
            set
            {
                if (value > 2 & value < 8)
                {
                    _safe.Size = value;
                    OnPropertyChanget();
                }
                else
                {
                    MessageBox.Show("Размер сейфа не может быть меньше 3 и больше 7", "Внимание",MessageBoxButton.OK);
                }
            }  
        }

        public ICommand SettingSizeSafeCommand { get; }
        private bool CanSettingSizeSafeCommandExecute(object p) => true;

        private void OnSettingSizeSafeCommandExecute(object p)
        {
            
        }
        public MainWindowViewModel()
        {
            SettingSizeSafeCommand = new LambdaCommand(OnSettingSizeSafeCommandExecute, CanSettingSizeSafeCommandExecute);
            _title = "Сейф братьев Пилотов";
            _safe = new Safe();
            _safe.Size = 4;
        }

        public void SafeDimensions()
        {

        }
    }
}
