using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace TestWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int[] _checkingOpeningLock;
        private int[,] _safeSize;
        private Image[,] _images;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }
        public void InitOldGrid(List<List<int>> safeSize)
        {
            Grid gridSafe = new Grid();
            for (int i = 0; i < safeSize.Count; i++)
            {
                gridSafe.RowDefinitions.Add(new RowDefinition());

            }
            for (int j = 0; j < safeSize[0].Count; j++)
            {
                gridSafe.ColumnDefinitions.Add(new ColumnDefinition());
            }
            gridSafe.ShowGridLines = true;
            this.Content = gridSafe;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int range = 0;
            if (!CheckingFormat(ref range))
            {
                return;
            }
            if (!CheckingRange(ref range))
            {
                return;
            }
            _safeSize = new int[range, range];
            _checkingOpeningLock = new int[range];
            CreatureFieldSafeSize();
        }
        private void CreatureFieldSafeSize()
        {
            Random rend = new Random();
            for (int i = 0; i < _safeSize.GetLength(0); i++)// высота
            {
                for (int j = 0; j < _safeSize.GetLength(1); j++) // ширина
                {
                    _safeSize[i, j] = rend.Next(0, 2);
                }
            }
            ClearLock();
            FillingResult();
            _images = new Image[_safeSize.GetLength(0), _safeSize.GetLength(1)];
            gridImage.Children.Clear();
            CreateCellsRow(gridImage);
        }
        private bool CheckingFormat(ref int range)
        {
            try
            {
                range = Convert.ToInt32(fieldSafeSize.Text);
                return true;
            }
            catch (Exception)
            {
                MessageWarning("Неверный формат");
                return false;
            }
        }
        private void MessageWarning(string text)
        {
            MessageBox.Show(text, "!!!", MessageBoxButton.OK);
        }
        private bool CheckingRange(ref int range)
        {
            if (range >= 4 & range <= 7)
            {
                return true;
            }
            MessageWarning("Неверный размер головоломи, допустимые размеры от 4 до 7 вкличительно");
            return false;
        }
        public void CreateCellsRow(Grid grid)//высота
        {
            grid.ShowGridLines = true;

            for (int i = 0; i < _images.GetLength(0); i++)
            {
                CreateGridColumn(i, grid);
            }
        }
        public void CreateGridColumn(int rowNumber, Grid grid)//ширина
        {
            int x = -650;
            int y = rowNumber * 130 - 320;


            for (int i = 0; i < _images.GetLength(1); i++)
            {
                // Creating Back and Forward Cell
                _images[rowNumber, i] = new Image();
                _images[rowNumber, i].Height = 60;
                _images[rowNumber, i].Width = 60;
                _images[rowNumber, i].Margin = new System.Windows.Thickness(x, y, 0, 0);

                GridImage(_images[rowNumber, i], _safeSize[rowNumber, i]);
                grid.Children.Add(_images[rowNumber, i]);
                x += 130;
            }

        }

        public void GridImage(Image image, int numberPage)
        {
            if (numberPage == 1)
            {
                image.Source = Resource1._1.ToBitmapSource();
                return;
            }
            image.Source = Resource1._0.ToBitmapSource();
        }


        private void gridImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(gridImage);
            int x = (int)position.X;
            int y = (int)position.Y;
            x -= 78;
            y -= 40;
            int xPosition = x / 64;
            int yPosition = y / 64;

            try
            {
                ImageReversal(xPosition, yPosition);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void ImageReversal(int x, int y)
        {
            ImageReversalColumn(x);
            ImageReversalLine(x, y);
        }
        private void ImageReversalLine(int x, int y)
        {
            for (int i = 0; i < _safeSize.GetLength(0); i++)//строка
            {
                if (i != x)
                {
                    if (_safeSize[y, i] == 1)
                    {
                        _images[y, i].Source = Resource1._0.ToBitmapSource();
                        _safeSize[y, i] = 0;
                    }
                    else
                    {
                        _images[y, i].Source = Resource1._1.ToBitmapSource();
                        _safeSize[y, i] = 1;
                    }
                }
            }
        }
        private void ImageReversalColumn(int x)
        {
            for (int i = 0; i < _safeSize.GetLength(1); i++)//столбец
            {
                if (_safeSize[i, x] == 1)
                {

                    _images[i, x].Source = Resource1._0.ToBitmapSource();
                    _safeSize[i, x] = 0;
                }
                else
                {
                    _images[i, x].Source = Resource1._1.ToBitmapSource();
                    _safeSize[i, x] = 1;
                }
            }
                FillingResult();
        }
        private void FillingResult()
        {
            for (int x = 0; x < _safeSize.GetLength(0); x++)
            {
                int result = 0;
                for (int i = 0; i < _safeSize.GetLength(1); i++)
                {
                    result += _safeSize[i, x];
                }
                if (result == _safeSize.GetLength(1))
                {
                    _checkingOpeningLock[x] = 1;
                }
            }
            ChekingLockSafe();
        }
        private void ChekingLockSafe()
        {
            int result = 0;
            foreach (var item in _checkingOpeningLock)
            {
                result += item;
            }
            if (_checkingOpeningLock.Length == result)
            {
                Thread.Sleep(100);
                MessageWarning("Победа");
                CreatureFieldSafeSize();
            }
        }
        private void ClearLock()
        {
            for (int i = 0; i < _checkingOpeningLock.Length; i++)
            {
                _checkingOpeningLock[i] = 0;
            }
        } 
        
    }
}
