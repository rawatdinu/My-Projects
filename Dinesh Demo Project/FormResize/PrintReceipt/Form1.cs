using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintReceipt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void PrintReceipt()
        {
            PrintDialog printDialouge = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            printDialouge.Document = printDocument;

            printDocument.PrintPage += printDocument_PrintPage;

            DialogResult result = printDialouge.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

        
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Verdana", 12);
            float fontHeight = font.Height;
            int startX = 10;
            int startY = 10;
            int offset = 40;
            int padding = 20;

            //Line 1
            graphic.DrawString("Weldocme to Delight Foods", new Font("Verdana", 18), new SolidBrush(Color.Black), startX, startY);

            //line 2
            string productDes = "Burger".PadRight(padding,'*');
            string productTotal = String.Format("{0:n}", 120);
            string productLine = productDes + productTotal;
            graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)font.Height + 5;

            //Line3

            productDes = "Pasta and Noodles".PadRight(padding,'*');
            productTotal = String.Format("{0:n}", 130);
            productLine = productDes + productTotal;
            graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)font.Height + 5;

            //line 3
            productDes = "Tea".PadRight(padding, '*');
            productTotal = String.Format("{0:n}", 140);
            productLine = productDes + productTotal;
            graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)font.Height + 5;

            //--------------------

            offset = offset + (int)font.Height + 20;

            productDes = "Total Payment".PadRight(padding,'*');
            productTotal = String.Format("{0:n}", 390);
            productLine = productDes + productTotal;
            graphic.DrawString( productLine, font, new SolidBrush(Color.Black), startX, startY + offset);




        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            PrintReceipt();
        }
    }

   
}
