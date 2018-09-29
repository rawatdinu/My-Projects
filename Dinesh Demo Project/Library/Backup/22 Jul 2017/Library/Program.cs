﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 frm1 = new Form1();
            if (frm1.ShowDialog() == DialogResult.OK)
            {
                Application.EnableVisualStyles();
                Application.Run(new MDIForm());

            }
            else
            {
                Application.Exit();
            }
        }
    }
}
