using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class Form1 : Form
    {
        int N = 5;
        LifeGamecs life;
        public Form1()
        {
            InitializeComponent();
            CreateGrid(N);
            life = new LifeGamecs();
        }
        void CreateGrid(int n)
        {
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            int w = dataGridView1.Width > dataGridView1.Height ? dataGridView1.Height :
                dataGridView1.Width;
            for(int i=0;i<n;i++)
            {
                dataGridView1.Rows[i].Height = w / n;
                dataGridView1.Columns[i].Width = w / n;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            N = trackBar1.Value;
            CreateGrid(N);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CreateGrid(N);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            if (dataGridView1[col, row].Style.BackColor == Color.Black)
                dataGridView1[col, row].Style.BackColor = Color.White;
            else
                dataGridView1[col, row].Style.BackColor = Color.Black;
            dataGridView1.ClearSelection();//убрать выделение

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            life.GridToArea(dataGridView1, N);
            life.NextDay();
            life.AreaToGrid(dataGridView1);
        }
    }
}
