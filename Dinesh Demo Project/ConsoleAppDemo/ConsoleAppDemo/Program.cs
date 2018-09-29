using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ConsoleAppDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                Console.WriteLine(lang.Culture.EnglishName);
                Console.WriteLine(lang.Culture.Name);
                Console.WriteLine(lang.Culture.DisplayName);
                Console.WriteLine(lang.LayoutName);

                Console.WriteLine(lang.Culture.KeyboardLayoutId);
                Console.WriteLine(lang.Culture.LCID);
                Console.WriteLine(lang.Culture.ThreeLetterISOLanguageName);
                Console.WriteLine(lang.Culture.ThreeLetterWindowsLanguageName);
                Console.WriteLine("*******************************************");
            }

            //foreach (CultureInfo culInfo in CultureInfo.GetCultures(CultureTypes.FrameworkCultures))
            //{
            //    Console.WriteLine( "English Name" + culInfo.EnglishName);
            //    Console.WriteLine("Name "+culInfo.Name);
            //    //Console.WriteLine(lang.Culture.KeyboardLayoutId);
            //    //Console.WriteLine(lang.Culture.LCID);
            //    //Console.WriteLine(lang.Culture.ThreeLetterISOLanguageName);
            //    //Console.WriteLine(lang.Culture.ThreeLetterWindowsLanguageName);
            //    Console.WriteLine("*******************************************");
            //}

            Console.ReadKey();
           
        }
    }
}
