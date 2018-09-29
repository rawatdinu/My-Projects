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
using System.Windows.Forms;
namespace LanguageFuturePoint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
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

            DemoCulture tempDemo;
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                string culName= lang.Culture.Name;
                string culEngName= lang.Culture.EnglishName;
                tempDemo = new DemoCulture(culName, culEngName);

                cmbLanguageName.Items.Add(tempDemo);

                cmbLanguageName.SelectedIndex = 0;

                //Console.WriteLine(lang.Culture.EnglishName);
                //Console.WriteLine(lang.Culture.Name);
                //Console.WriteLine(lang.Culture.DisplayName);
                //Console.WriteLine(lang.LayoutName);

                //Console.WriteLine(lang.Culture.KeyboardLayoutId);
                //Console.WriteLine(lang.Culture.LCID);
                //Console.WriteLine(lang.Culture.ThreeLetterISOLanguageName);
                //Console.WriteLine(lang.Culture.ThreeLetterWindowsLanguageName);
                //Console.WriteLine("*******************************************");
            }
        
        
        }

        private void cmbLanguageName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLanguageName.SelectedIndex != -1)
            {

                DemoCulture temDemo = (DemoCulture)cmbLanguageName.SelectedItem;
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo(temDemo.CultureName));
            
            }
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

