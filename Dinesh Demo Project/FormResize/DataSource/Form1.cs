using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            airplaneBindingSource.Add(new Airplane("Boeing", 1200));
            airplaneBindingSource.Add(new Airplane("F-16", 1200));
            airplaneBindingSource.Add(new Airplane("Rafter", 1200));
            airplaneBindingSource.Add(new Airplane("Sukhoi", 1200));
            airplaneBindingSource.Add(new Airplane("MIG-32", 1200));
            airplaneBindingSource.Add(new Airplane("Rafale", 1200));

            FillGrid2();
        }

        BindingSource bs = new BindingSource();
        private void FillGrid2()
        {
            bs.DataSource = typeof(Airplane);
            bs.Add(new Airplane("Boeing", 1500));
            bs.Add(new Airplane("Air India", 500));
            bs.Add(new Airplane("King Fisher", 800));
            bs.Add(new Airplane("Quatar Airways", 1900));
            bs.Add(new Airplane("Luftasana", 2000));
            bs.Add(new Airplane("British Airways", 1500));
            bs.Add(new Airplane("Quatar Airways", 1900));
            bs.Add(new Airplane("Luftasana", 2000));
            bs.Add(new Airplane("British Airways", 1500));

            dgvGrid2.DataSource = bs;

            txtModel2.DataBindings.Add("Text", bs, "Model");
        
        
        }
    }
}
