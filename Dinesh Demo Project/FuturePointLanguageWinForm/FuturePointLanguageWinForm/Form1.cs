using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FuturePointLanguageWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        const int GCL_REVERSECONVERSION = 0x0002;

        [DllImport("Imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);

        [DllImport("User32.dll")]
        public static extern IntPtr GetKeyboardLayout(int idThread);

        [DllImport("Imm32.dll")]
        public static extern int ImmGetConversionList(
            IntPtr hKL,
            IntPtr hIMC,
            string lpSrc,
            IntPtr lpDst,
            int dwBufLen,
            int uFlag
            );

        [DllImport("Imm32.dll")]
        public static extern bool ImmReleaseContext(IntPtr hWnd, IntPtr hIMC);

        [StructLayout(LayoutKind.Sequential)]
        public class CANDIDATELIST
        {
            public int dwSize;
            public int dwStyle;
            public int dwCount;
            public int dwSelection;
            public int dwPageStart;
            public int dwPageSize;
            public int dwOffset;
        }

        public string[] GetReverseConversion(string AText)
        {
            string[] strList = null;
            if (AText.Length > 0)
            {
                IntPtr hIMC = ImmGetContext(this.Handle);
                IntPtr hKL = GetKeyboardLayout(0);
                int dwSize = ImmGetConversionList(hKL, hIMC, AText, IntPtr.Zero, 0, GCL_REVERSECONVERSION);
                if (dwSize > 0)
                {
                    IntPtr BufList = Marshal.AllocHGlobal(dwSize);
                    try
                    {
                        ImmGetConversionList(hKL, hIMC, AText, BufList, dwSize, GCL_REVERSECONVERSION);
                        CANDIDATELIST list = new CANDIDATELIST();
                        Marshal.PtrToStructure(BufList, list);
                        byte[] buf = new byte[dwSize];
                        Marshal.Copy(BufList, buf, 0, dwSize);
                        Marshal.FreeHGlobal(BufList);
                        int os = list.dwOffset;
                        string str = System.Text.Encoding.Default.GetString(buf, os, buf.Length - os - 3);
                        char[] par = "\0".ToCharArray();
                        strList = str.Split(par);
                    }
                    finally
                    {
                        ImmReleaseContext(this.Handle, hIMC);
                    }
                }
            }
            return strList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            //listBox1.Items.AddRange(GetReverseConversion(textBox1.Text));
            LanguageSelector langSel = new LanguageSelector();
            LanguageSelector.Gujarati();

        }

        ///The example of use of the above code

      
    }
}
