using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Text;

namespace FuturePointLanguageWinForm
{
    class LanguageSelector
    {
        const uint KLF_ACTIVATE = 1; //activate the layout
        const int KL_NAMELENGTH = 9; // length of the keyboard buffer
        const string LANG_EN_US = "00000409";
        const string LANG_HE_IL = "0000040d";

        const string LangHindi = "00000439";
        const string LangGujarati = "00000447";

        [DllImport("user32.dll")]
        private static extern long LoadKeyboardLayout(string pwszKLID, // input locale identifier
              uint Flags);         // input locale identifier options

        [DllImport("user32.dll")]
        private static extern long GetKeyboardLayoutName(
              System.Text.StringBuilder pwszKLID  //[out] string that receives the name of the locale identifier
              );


        public static string getName()
        {

            System.Text.StringBuilder name = new System.Text.StringBuilder(KL_NAMELENGTH);

            GetKeyboardLayoutName(name);

            return name.ToString();

        }


        public static void Hebrew()
        {

            //load and activate the layout for the current thread<o:p></o:p>

            LoadKeyboardLayout(LANG_HE_IL, KLF_ACTIVATE);

        }



        public static void English()
        {

            //load and activate the layout for the current thread<o:p></o:p>

            LoadKeyboardLayout(LANG_EN_US, KLF_ACTIVATE);

        }

        public static void Hindi()
        {
            LoadKeyboardLayout(LangHindi, KLF_ACTIVATE);
        }

        public static void Gujarati()
        {
            LoadKeyboardLayout(LangGujarati, KLF_ACTIVATE);
        }

        ////////////////////

      

    }
}
