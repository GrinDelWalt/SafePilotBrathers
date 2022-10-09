using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SafePilotBrathers.Services
{
    internal class GenerationSafeLock
    {
        private void CreateCellsColumn(int rowNumber, Grid grid)
        {
            int x = -650;
            int y = rowNumber * 130 - 520;

            PicturesController picController = new PicturesController();

            for (int i = 0; i < m_cellsImages.GetLength(1); i++)
            {
                // Creating Back and Forward Cell
                m_cellsImages[rowNumber, i] = new Image();
                m_cellsImages[rowNumber, i].Height = 60;
                m_cellsImages[rowNumber, i].Width = 60;
                m_cellsImages[rowNumber, i].Margin = new System.Windows.Thickness(x, y, 0, 0);

                picController.SetDefaultImageCell(m_cellsImages[rowNumber, i]);

                grid.Children.Add(m_cellsImages[rowNumber, i]);

                x += 130;
            }
        }
    }
}
