using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListView
{
    public partial class Form1 : Form
    {
        private ImageList _smallImageList;
        private ImageList _mediumImageList;
        private ImageList _largeImageList;

        public Form1()
        {
            InitializeComponent();
            FillImageList();            
            FillCombo();
            DesignListView();
        }

        private void DesignListView()
        {
            listView1.Columns.Add("Name", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Age", 60);
            listView1.Columns.Add("Address", 120);
            listView1.Columns.Add("Email", 100);
            listView1.Columns.Add("Phone", 80);

            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            

            listView1.SmallImageList = _smallImageList;
            listView1.LargeImageList = _smallImageList;
            //listView1.StateImageList = _mediumImageList;

                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(textBox1.Text);            
            lvi.SubItems.Add(textBox2.Text);
            lvi.SubItems.Add(textBox3.Text);
            lvi.SubItems.Add(textBox4.Text);
            lvi.SubItems.Add(textBox5.Text);
            
            
            lvi.ImageKey = textBox6.Text;

            listView1.Items.Add(lvi);
            
        }

        private void FillCombo()
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.BackColor = Color.White;
            var value = Enum.GetValues(typeof(View));
            foreach (var item in value)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                listView1.View = (View)comboBox1.SelectedIndex;

            }
        }

        private void FillImageList()
        {
            _smallImageList = new ImageList();
            _smallImageList.ImageSize = new Size(16,16);
            _smallImageList.Images.Add("1",Image.FromFile(@"D:\download\Download\Temp\small\small1.jpg"));
            _smallImageList.Images.Add("2", Image.FromFile(@"D:\download\Download\Temp\small\small2.jpg"));
            _smallImageList.Images.Add("3", Image.FromFile(@"D:\download\Download\Temp\small\small3.jpg"));
            _smallImageList.Images.Add("4", Image.FromFile(@"D:\download\Download\Temp\small\small4.jpg"));
            

            _mediumImageList = new ImageList();
            _mediumImageList.ImageSize = new Size(32, 32);
            _mediumImageList.Images.Add("1",Image.FromFile(@"D:\download\Download\Temp\medium\medium1.jpg"));
            _mediumImageList.Images.Add("2", Image.FromFile(@"D:\download\Download\Temp\medium\medium2.jpg"));
            _mediumImageList.Images.Add("3", Image.FromFile(@"D:\download\Download\Temp\medium\medium3.jpg"));
            _mediumImageList.Images.Add("4", Image.FromFile(@"D:\download\Download\Temp\medium\medium4.jpg"));


            _largeImageList = new ImageList();
            _largeImageList.ImageSize = new Size(64, 64);
            _largeImageList.Images.Add("1",Image.FromFile(@"D:\download\Download\Temp\large\large1.jpg"));
            _largeImageList.Images.Add("2", Image.FromFile(@"D:\download\Download\Temp\large\large2.jpg"));
            _largeImageList.Images.Add("3", Image.FromFile(@"D:\download\Download\Temp\large\large3.jpg"));
            _largeImageList.Images.Add("4", Image.FromFile(@"D:\download\Download\Temp\large\large4.jpg"));
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                string str = "";
                foreach( ListViewItem item in  listView1.SelectedItems)
                {

                    str += item.SubItems[0].Text + "   " + item.SubItems[1].Text + "   " + item.SubItems[2].Text +"\n";
                }

                MessageBox.Show(str);
            }
        }
    }
}
