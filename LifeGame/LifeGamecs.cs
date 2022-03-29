using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace LifeGame
{
    class LifeGamecs
    {
        public int[,] Area { get; set; }
        public int N { get; set; }

        /* public LifeGamecs(int n)
         {
             N = n;
             Area = new int[n, n];
         }*/
        public void GridToArea(DataGridView grid, int n)//из формы будем отправлять таблицу
        {//смотря на цвет, ставим 0 или 1
            N = n;
            Area = new int[n, n];

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    if (grid[col, row].Style.BackColor == Color.Black)
                        Area[row, col] = 1;
                    else
                        Area[row, col] = 0;
                }
            }
        }
        public void AreaToGrid(DataGridView grid)
        {//ставим цвет в зависимости от цифры
            for (int col = 0; col < N; col++)
            {
                for (int row = 0; row < N; row++)
                {
                    if (Area[row, col] == 1)
                        grid[col, row].Style.BackColor = Color.Black;
                    else
                        grid[col, row].Style.BackColor = Color.White;
                }
            }
        }
        public void NextDay()
        {
            int[,] buffer = new int[N, N];
            int count;
            for (int col = 0; col < N; col++)
            {
                
                for (int row = 0; row < N; row++)
                {
                    count = 0;
                    if (row < N - 1) count += Area[col, row + 1];
                    if (row >0) count += Area[col, row - 1];

                    if (col < N - 1 && row < N - 1) count += Area[col + 1, row + 1];
                    if (col < N - 1 && row > 0) count += Area[col + 1, row - 1];
                    if (col < N - 1) count += Area[col + 1, row];

                    if (col >0 && row < N-1) count += Area[col - 1, row + 1];
                    if (col >0 && row >0) count += Area[col - 1, row - 1];
                    if (col >0) count += Area[col - 1, row];

                    if (Area[col, row] == 0 && count == 3)
                        buffer[col,row] = 1;//мертвая и 3 соседа - воскресает

                    else if (Area[col, row] == 1 && (count == 2 || count == 3))
                        buffer[col, row] = 1;//живая и 2 или 3 соседа живет

                    else
                        buffer[col, row] = 0;//во всех остальных мертва

                }
            }
            Area = buffer;//следующий шаг клетки
        }
    }
}
