using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using InputLanguageSelector;
namespace LanguageFuturePoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] LanguageList = new string[] { "English","Hindi", "Gujarati","Bengali"};
        public MainWindow()
        {
            InitializeComponent();

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("hi-IN"));
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("gu-IN"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombo();



        }
        private void FillCombo()
        {
            cmbLanguageName.ItemsSource = null;
            cmbLanguageName.Items.Clear();
            cmbLanguageName.ItemsSource = LanguageList;
            cmbLanguageName.SelectedIndex = 0;

            DemoCulture tempDemo;
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                string culName = lang.Culture.Name;
                string culEngName = lang.Culture.EnglishName;
                tempDemo = new DemoCulture(culName, culEngName);

                //cmbLanguageName.Items.Add(tempDemo);

                //cmbLanguageName.SelectedIndex = 0;

                Console.WriteLine(lang.Culture.EnglishName);
                Console.WriteLine(lang.Culture.Name);
                Console.WriteLine(lang.Culture.DisplayName);
                Console.WriteLine(lang.LayoutName);

                Console.WriteLine(lang.Culture.KeyboardLayoutId);
                Console.WriteLine(lang.Culture.LCID);
                Console.WriteLine(lang.Culture.ThreeLetterISOLanguageName);
                Console.WriteLine(lang.Culture.ThreeLetterWindowsLanguageName);
                //Console.WriteLine("*******************************************");
            }
        
        
        }

        private void cmbLanguageName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (cmbLanguageName.SelectedIndex != -1)
            //{

            //    DemoCulture temDemo = (DemoCulture)cmbLanguageName.SelectedItem;
            //    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo(temDemo.CultureName));
            
            //}
            /*************Using Input Lauguage Selecter*****************/
            string languageName="";
            if (cmbLanguageName.SelectedIndex != -1)
            {
                languageName = cmbLanguageName.SelectedValue.ToString();
                LanguageSelector.SetKeyBoardLanguage(languageName);

            }
            txtParagraph.Focus();
           
        }

        private void btnSetInputLang_Click(object sender, RoutedEventArgs e)
        {
            //System.Globalization.CultureInfo TypeOfLanguage = new System.Globalization.CultureInfo("hi-IN");
            //InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);
            Thread.CurrentThread.CurrentUICulture.ClearCachedData();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN"); 

            System.Globalization.CultureInfo TypeOfLanguage = CultureOfCurrentLayout();
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(TypeOfLanguage);

        }

        private void btnShowKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");
        }

        [DllImport("user32.dll")]
        private static extern bool GetKeyboardLayoutName(StringBuilder pwszKLID);
        private const int KL_NAMELENGTH = 9;

        private CultureInfo CultureOfCurrentLayout()
        {
            StringBuilder sb = new StringBuilder(KL_NAMELENGTH);

            if (GetKeyboardLayoutName(sb))
            {
                int klid = int.Parse(sb.ToString().Substring(KL_NAMELENGTH - 1),
                   NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture);

                // strip all but the bottom half of the number
                klid &= 0xffff;

                return new CultureInfo(klid, false);
            }

            return (null);
        }

        private void btnCloseKeyBoard_Click(object sender, RoutedEventArgs e)
        {
            //Process[] prs = Process.GetProcesses();


            //foreach (Process pr in prs)
            //{
            //    if (pr.ProcessName == "osk")
            //    {

            //        pr.Kill();

            //    }

            foreach (Process proc in Process.GetProcessesByName("osk"))
            {
                proc.Kill();
            }

            //}
            //if (System.Diagnostics.Process.GetProcessesByName("osk") != null)
            //{
            //    System.Windows.MessageBox.Show("Process is Running.........");

            //}
            //else
            //{
            //    System.Windows.MessageBox.Show("Process Not is Running");
            //}
        }

      

       

    }
    public class DemoCulture
    {
       public string CultureName = "";
       public string EnglishName = "";
        public DemoCulture(string cultureName, string englishName)
        {
            CultureName = cultureName;
            EnglishName = englishName;
        }

        public override string ToString()
        {
            return EnglishName;
        }
    
    }
}

