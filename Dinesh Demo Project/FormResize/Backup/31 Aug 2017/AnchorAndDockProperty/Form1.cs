using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnchorAndDockProperty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DesignGrid(dataGridView1);
        }

        private void DesignGrid(DataGridView dgv)
        {
            dgv.ColumnCount = 5;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv.Font, FontStyle.Bold);

            dgv.Name = "songsDataGridView";
            dgv.Location = new Point(8, 8);
            dgv.Size = new Size(500, 250);
            dgv.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;

            dgv.Columns[0].Name = "Release Date";
            dgv.Columns[1].Name = "Track";
            dgv.Columns[2].Name = "Title";
            dgv.Columns[3].Name = "Artist";
            dgv.Columns[4].Name = "Album";
            dgv.Columns[4].DefaultCellStyle.Font =
                new Font(dgv.DefaultCellStyle.Font, FontStyle.Italic);

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;
        
        }
    }
}
