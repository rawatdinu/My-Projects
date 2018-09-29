using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicButtons
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void AddCategory()
        {
            int categorycount = 5;
            for (int i = 0; i < categorycount; i++)
            {
                Button bt = new Button();
                bt.Name = "Category"+" "+ Convert.ToString(i);
                bt.Size = new System.Drawing.Size(75, 75);                
                bt.Text = "Text" + " " + Convert.ToString(i);
                bt.Click += new System.EventHandler(CategoryButton_Click);
               
                this.flowLayoutPanel1.Controls.Add(bt);
                
            
            }
        
        
        }

        private void AddFoodItem(string categoryCode)
        {
            int count = Convert.ToInt32(textBox1.Text);
            this.flowLayoutPanel2.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                Button bt = new Button();
                bt.Name = "FoodCode" + " " + Convert.ToString(i);
                bt.Size = new System.Drawing.Size(75, 75);
                bt.Text = "FoodName" + " " + categoryCode + Convert.ToString(i);                
                this.flowLayoutPanel2.Controls.Add(bt);

            }


        }
        private void CategoryButton_Click(object sender, EventArgs e)
        {
            

            string categoryCode = ((Button)sender).Name;
            AddFoodItem(categoryCode);

            //MessageBox.Show(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class FoodItem
    {
        public string FoodName { get; set; }
        public string Code { get; set; }
        public double Pirce { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return FoodName + "[" + Convert.ToString(Pirce) + "]";
            
           // return base.ToString();
        }

    }

    public class Category
    {
        public string CategoryName { get; set; }
        public string Code { get; set; }
        
        public override string ToString()
        {
            return CategoryName + "[" + Convert.ToString(Code) + "]";
            
        }

    }
}
