using SafePilotBrathers.Interfaces;
using SafePilotBrathers.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SafePilotBrathers.Services
{
    internal class PicturesController
    {
        public void Rotate(IRedraw obj, Image objImage)
        {
            obj.Rotate();
            obj.SetImage(objImage);
        }

        public void SetInCell(IRedraw obj, Image objImage)
        {
            obj.SetImage(objImage);
        }

        public void SetDefaultImageCell(Image imageCell)
        {
            ResConfig config = new ResConfig();
            string imgDirectory = "Resources//MapObjects//cell_noneObject.png";

            imageCell.Source = new BitmapImage(new Uri(config.AppDirectory + imgDirectory));
        }

        public void SetImagePreview(Image imageCell)
        {
            MainWindow mainWindow = new MainWindow();
            imageCell = mainWindow.image_PreplanningObjectView;
        }
    }
}
