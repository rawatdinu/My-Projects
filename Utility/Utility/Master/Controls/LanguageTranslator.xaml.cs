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
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace Utility
{
    /// <summary>
    /// Interaction logic for LanguageTranslator.xaml
    /// </summary>
    public partial class LanguageTranslator : UserControl
    {
        public LanguageTranslator()
        {
            InitializeComponent();
        }
        private const  String Space = " ";
        private const String NewLine = "\r\n";
                
        private void ButtomClick()
        {
            String sourcefontName = "";
            String destinationfontName = "";
            String SourceText = "";
            String DestinationText = "";

            Node tempNode = GetTranslationPath(sourcefontName, destinationfontName);
            int pathLenght = tempNode.Weight;
            String[] path = tempNode.Path.Split(new String[] { FontSeperator }, StringSplitOptions.None);


            if (pathLenght == Infinite)
            {
                MessageBox.Show("NO Mapping exitst");
                return;
            }

            else
            {
                if (true)//if read file rdo button
                {
                    String FilePath = "";

                    using (new WaitCursor())
                    {

                        if (!String.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
                        {
                            StreamReader sr = new StreamReader(FilePath);
                            String TransOut = "";
                            String strParagraph = "";
                            StringBuilder ParagraphBuilder = new StringBuilder();
                            while (!sr.EndOfStream)
                            {
                                ParagraphBuilder.Append(sr.ReadLine());
                                ParagraphBuilder.Append(NewLine);
                            }

                            strParagraph = ParagraphBuilder.ToString().Trim();
                            sr.Close();

                            for (int k = 0; k < path.Length; k++)
                            {
                                string source = path[k];
                                string destination = path[k + 1];
                                strParagraph = TranslattionOnSingle(source, destination, strParagraph);
                                k = k + 2;
                            }

                            string newfilepath = Path.GetFileNameWithoutExtension(FilePath);//new file name

                            SaveFileDialog svd = new SaveFileDialog()
                            {
                                DefaultExt = ".txt",
                                Filter = "Text File (*.txt)|*.txt",
                                Title = "Select file Name",
                                InitialDirectory = FilePath
                            };
                            TransOut = strParagraph.Trim();
                            if ((bool)svd.ShowDialog())
                            {
                                new FileStream(svd.FileName, FileMode.Create).Dispose();
                                StreamWriter sw = new StreamWriter(svd.FileName, false, Encoding.Unicode);
                                sw.Write(TransOut);
                                sw.Close();
                                sw.Dispose();
                            }
                        }

                    }
                }

                //else if (true)//is rdo btn for tabel is checked
                //{ 

                //}
                else//Translation through text
                {
                    String strParagraph = null;
                    String Retval = String.Empty;
                    using(new WaitCursor())
                    {
                        if (!String.IsNullOrEmpty(SourceText))
                        {
                            strParagraph = SourceText;
                            for (int k = 0; k < path.Length; k++)
                            {
                                string source = path[k];
                                string destination = path[k + 1];
                                strParagraph = TranslattionOnSingle(source, destination, strParagraph);
                                k = k + 2;
                            }
                            Retval = strParagraph;

                        }
                    }
                    DestinationText = Retval;
                
                }
            
            
            }

        }

        private String TranslattionOnSingle(String sourceFontName, String destinationFontName,String Paragraph)
        {
            DataTable dt= new DataTable();//datable comes from db; with col source_font_name and destination_font_name
            //KeyValuePair<String, String>[] dict = new KeyValuePair<string, string>[20];//le
            KeyValuePair<String, String>[] dict = dt.AsEnumerable().Select((Key => new KeyValuePair<String, String>(Key["source_font_name"].ToString(), Key["destination_font_name"].ToString()))).ToArray();


            if (dict.Length < 1)
            { 
            //reverse of above keyvalue pair
            }



            //for checkbox paragraph
            String Retval = "";
            String[] tempStr;

            if (true)//radio button check for paragraph 
            {
                Retval = "";
                
                string strParagraph = "";
                string tempWord = "";
                tempStr = Paragraph.Split(new String[] { Space }, StringSplitOptions.None);
                int count = tempStr.Length;

                for (int i = 0; i < count; i++)
                {
                    tempWord = tempStr[i];
                    if (!String.IsNullOrEmpty(tempWord))
                    {
                        //tempWord=TranslateText(sourceFontName,destinationFontName,tempWord)shifting of character and 
                        strParagraph += CallMapping(tempWord, dict);//Call algo for maaping replacment
                    }
                    else
                    {
                        strParagraph += Space;
                    }

                }
                strParagraph = strParagraph.Substring(0, (strParagraph.Length - Space.Length));
                return strParagraph;

            
            }                        
        }
        private string CallMapping(string s, KeyValuePair<String, String>[] mapping)
        {
            string result = "";
            TranslateRecursive(s,mapping,ref result);

            return result;
        
        }

        private bool TranslateRecursive(String s, KeyValuePair<String, String>[] mapping, ref String result)
        {
            result = "";//return mapped value
           return true;// use recussive for value
        }

        #region Hindi to Krutidev Using Database

        String[] FromChars;
        String[] ToChars;
        int MaxLen_FromChars = 0, MaxLen_ToChars = 0;

        String[] IndependentVowelList;
        String[] DependentVowelList1;
        String[] DependentVowelList2;
        int MaxLen_IndependentVowelList = 0, MaxLen_DependentVowelList1 = 0, MaxLen_DependentVowelList2 = 0;

        String[] ConsonantList1;
        String[] ConsonantList2;
        int MaxLen_ConsonantList1 = 0, MaxLen_ConsonantList2 = 0;

        String[] HalfCharLeft;
        String[] HalfCharRight;
        int MaxLen_HalfCharLeft = 0, MaxLen_HalfCharRight = 0;

        String[] SpecialSymbol;
        String[] Digit;
        int MaxLen_SpecialSymbol = 0, MaxLen_Digit = 0;

        String[] LeftSubChar;
        String[] RightSubChar;
        int MaxLen_LeftSubChar = 0, MaxLen_RightSubChar = 0;

        String[] LeftShiftChar;
        String[] LeftReplaceWith;
        int MaxLen_LeftShiftChar = 0, MaxLen_LeftReplaceWith = 0;

        String[] RightShiftChar;
        String[] RightReplaceWith;
        int MaxLen_RightShiftChar = 0, MaxLen_RightReplaceWith = 0;


      private const  String CharacterSeperator = ", ";//comma space
        private void InitialiseCharSet(String sourceFontName, string destinationFontName)
        {
            DataTable dt = new DataTable();
            if (dt.Rows.Count > 0)
            {
                String tempchar;

                if ((tempchar = dt.Rows[0]["FromChars"].ToString()) != null)
                {
                    FromChars = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["ToChars"].ToString()) != null)
                {
                    ToChars = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["IndependentVowelList"].ToString()) != null)
                {
                    IndependentVowelList = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["DependentVowelList1"].ToString()) != null)
                {
                    DependentVowelList1 = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["DependentVowelList2"].ToString()) != null)
                {
                    DependentVowelList2 = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["ConsonantList1"].ToString()) != null)
                {
                    ConsonantList1 = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["ConsonantList2"].ToString()) != null)
                {
                    ConsonantList2 = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["HalfCharLeft"].ToString()) != null)
                {
                    HalfCharLeft = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["HalfCharRight"].ToString()) != null)
                {
                    HalfCharRight = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["SpecialSymbol"].ToString()) != null)
                {
                    SpecialSymbol = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["Digit"].ToString()) != null)
                {
                    Digit = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }

                if ((tempchar = dt.Rows[0]["LeftSubChar"].ToString()) != null)
                {
                    LeftSubChar = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["RightSubChar"].ToString()) != null)
                {
                    RightSubChar = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }



                if ((tempchar = dt.Rows[0]["LeftShiftChar"].ToString()) != null)
                {
                    LeftShiftChar = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["LeftReplaceWith"].ToString()) != null)
                {
                    LeftReplaceWith = tempchar.Split(new String[] { "# #" }, StringSplitOptions.None);
                }


                if ((tempchar = dt.Rows[0]["RightShiftChar"].ToString()) != null)
                {
                    RightShiftChar = tempchar.Split(new String[] { CharacterSeperator }, StringSplitOptions.None);
                }
                if ((tempchar = dt.Rows[0]["RightReplaceWith"].ToString()) != null)
                {
                    RightReplaceWith = tempchar.Split(new String[] { "# #" }, StringSplitOptions.None);
                }

                //initialize max char length

                MaxLen_FromChars = GetMaxCharLength(FromChars);
                MaxLen_ToChars = GetMaxCharLength(ToChars);

                MaxLen_IndependentVowelList = GetMaxCharLength(IndependentVowelList);
                MaxLen_DependentVowelList1 = GetMaxCharLength(DependentVowelList1);
                MaxLen_DependentVowelList2 = GetMaxCharLength(DependentVowelList2);


                MaxLen_ConsonantList1 = GetMaxCharLength(ConsonantList1);
                MaxLen_ConsonantList2 = GetMaxCharLength(ConsonantList2);


                MaxLen_HalfCharLeft = GetMaxCharLength(HalfCharLeft);
                MaxLen_HalfCharRight = GetMaxCharLength(HalfCharRight);


                MaxLen_SpecialSymbol = GetMaxCharLength(SpecialSymbol);
                MaxLen_Digit = GetMaxCharLength(Digit);


                MaxLen_LeftSubChar = GetMaxCharLength(LeftSubChar);
                MaxLen_RightSubChar = GetMaxCharLength(RightSubChar);


                MaxLen_LeftShiftChar = GetMaxCharLength(LeftShiftChar);
                MaxLen_LeftReplaceWith = GetMaxCharLength(LeftReplaceWith);


                MaxLen_RightShiftChar = GetMaxCharLength(RightShiftChar);
                MaxLen_RightReplaceWith = GetMaxCharLength(RightReplaceWith);

            }
            else
            {
                FromChars = new String[] { };
                
                    ToChars = new String[] { };
                
                    IndependentVowelList = new String[] { };
                
                    DependentVowelList1 = new String[] { };
                
                    DependentVowelList2 =new String[] { };
                
                    ConsonantList1 = new String[] { };
                
                    ConsonantList2 = new String[] { };
                

                
                    HalfCharLeft = new String[] { };
                
                    HalfCharRight = new String[] { };

                    SpecialSymbol = new String[] { };

                    Digit = new String[] { };
                
                    LeftSubChar = new String[] { };
                
                    RightSubChar = new String[] { };
                



                
                    LeftShiftChar = new String[] { };
                
                    LeftReplaceWith =new String[] { };
                
                    RightShiftChar = new String[] { };

                    RightReplaceWith = new String[] { };

                    MaxLen_FromChars = 0;
                    MaxLen_ToChars = 0;

                    MaxLen_IndependentVowelList = 0;
                    MaxLen_DependentVowelList1 = 0;
                    MaxLen_DependentVowelList2 = 0;


                    MaxLen_ConsonantList1 = 0;
                    MaxLen_ConsonantList2 = 0;


                    MaxLen_HalfCharLeft = 0;
                    MaxLen_HalfCharRight = 0;


                    MaxLen_SpecialSymbol = 0;
                    MaxLen_Digit = 0;


                    MaxLen_LeftSubChar = 0;
                    MaxLen_RightSubChar = 0;


                    MaxLen_LeftShiftChar = 0;
                    MaxLen_LeftReplaceWith = 0;


                    MaxLen_RightShiftChar = 0;
                    MaxLen_RightReplaceWith = 0;
                            
            }

            
        
        }

        private byte GetMaxCharLength(string[] arr)
        {
            int len = 0;
            foreach (string str in arr)
            {
                if (len < str.Length)
                {
                    len = str.Length;
                }
            }
            return (byte)len;
        }

        private string GetReplaceWord(string str)
        {
            string retString = RemoveDuplicates(str);

            if (GetMaxCharLength(LeftShiftChar) > 0)
            {
                retString = ShiftCharacterBack(retString);
            }
            if (GetMaxCharLength(RightShiftChar) > 0)
            {
                retString = ShiftCharacterForward(retString);
            }
            return retString;       
        }

        private string RemoveDuplicates(string str)
        {
            string retString = str;
            int len = FromChars.Length;
            if (GetMaxCharLength(FromChars) > 0)
            {
                for (int i = 0;i<len ;i++ )
                {
                    retString = retString.Replace(FromChars[i], ToChars[i]);
                }
            }
            return retString;
        }

        private string ShiftCharacterBack(string str)
        {
            string retString = "";
            string first;
            string second =str;
            string lshiftchar = "";

            while (second != "")
            {
                first = "";
                lshiftchar = FindFirstOccuringString(second, LeftShiftChar);
                if (lshiftchar != "")
                {
                    string ch = lshiftchar;
                    int chlen = ch.Length;
                    int index = second.IndexOf(ch);
                    
                    first = second.Substring(0, index);

                    second = second.Substring(index + chlen, ((second.Length - chlen) - index));
                    first=MoveBack(first,

                }

            }


            return retString;
        }

        private string ShiftCharacterForward(string str)
        {
            string retString = str;
           
            return retString;
        }

        private string MoveBack(string first, string ch)
        {
            int index = 0;
            int len = first.Length;

            if (len == 0)
            {
                return GetRightSideReplacementChar(ch);
            }

            bool isfullcharpass = false;
            string strch = "";
            bool res;
            string nextchar = "";
            int nextcharlen = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                strch = first[i].ToString();
                index = 0;
                res = false;
                nextchar = "";
                nextcharlen = 0;

                //if full char encounter

                res = GetNextLeftFullChar(first, i, Math.Max((Math.Max(MaxLen_IndependentVowelList, MaxLen_ConsonantList1)), MaxLen_ConsonantList2), out nextchar);
                if (res)
                {
                    if (isfullcharpass)
                    {
                        index = i + 1;
                        break;
                    }
                    isfullcharpass = true;
                    nextcharlen = nextchar.Length;
                    i = (i - nextcharlen) + 1;  // decrement in index at for loop

                    continue;
                }

                // for matras
                res = GetNextLeftDependentVowel(first, i, Math.Max(MaxLen_DependentVowelList1, MaxLen_DependentVowelList2), out nextchar);
                if (res)
                {
                    if (isfullcharpass)
                    {
                        index = i + 1;
                        break;
                    }                   
                    nextcharlen = nextchar.Length;
                    i = (i - nextcharlen) + 1;  // decrement in index at for loop
                    continue;
                }

                // for HalfCharacter
                res = GetNextLeftHalfChar(first, i, Math.Max(MaxLen_HalfCharLeft, MaxLen_HalfCharRight), out nextchar);
                if (res)
                {
                    //if (isfullcharpass)
                    //{
                    //    index = i + 1;
                    //    break;
                    //}
                    nextcharlen = nextchar.Length;
                    i = (i - nextcharlen) + 1;  // decrement in index at for loop
                    continue;
                }

                // for symbols 
                res = GetNextLeftSpecialSymbol(first, i, Math.Max(MaxLen_SpecialSymbol, MaxLen_Digit), out nextchar);
                if (res)
                {
                    index = i + 1;
                    break;
                }

                // for SubCharacter/ HalfCharacter
                res = GetNextLeftSubChar(first, i, Math.Max(MaxLen_RightSubChar, MaxLen_LeftSubChar), out nextchar);
                if (res)
                {
                    if (i == len - 1)
                    {
                        nextcharlen = nextchar.Length;
                        i = (i - nextcharlen) + 1;          //decrement in index at for loop
                        continue;
                    }
                    if (isfullcharpass && LeftSubChar.Contains<string>(nextchar))
                    {
                        nextcharlen = nextchar.Length;
                        i = (i - nextcharlen) + 1;
                        continue;                    //decrement in index at for loop                    
                    }
                    index = i + 1;
                    break;                   
                }

                // if RightShift charcter encounter 
                res = IsLeftShiftMeetingRightShift(first, i, MaxLen_RightShiftChar, out nextchar);
                if (res)
                {                    
                        nextcharlen = nextchar.Length;
                        i = (i - nextcharlen) + 1;          //decrement in index at for loop
                        continue;                    
                }



            }

            return retString;
        }

        private string MoveForward(string str)
        {
            string retString = str;

            return retString;
        }

        private string FindFirstOccuringString(string str,string[] arr)//return "" for not occuring
        {

            string retstring = "";
            int index = str.Length - 1;
            int chindex = index;

            foreach (string ch in arr)
            {
                chindex = str.IndexOf(ch);
                if (chindex > -1)
                {
                    index = chindex;
                    retstring = ch;
                }
            }

            return retstring;
        }

        private string InsertLeftShiftCharacter(string str)
        {
            string retString = str;

            return retString;
        }

        private string InsertRightShiftCharacter(string str)
        {
            string retString = str;

            return retString;
        }

        private bool GetNextLeftFullChar(string first, int index, int maxCharLen, out string strCh)
        {
            bool isfullchar = false;
            strCh = "";
            int len = maxCharLen;
            if (index < maxCharLen)
            {
                len = index + 1;            
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index - i + 1, i);
                if (IndependentVowelList.Contains<string>(strCh) || ConsonantList1.Contains<string>(strCh) || ConsonantList2.Contains<string>(strCh))
                {
                    isfullchar = true;
                    break;
                }
                strCh = "";                        
            }
            
            return  isfullchar;        
        }

        private bool GetNextLeftSubChar(string first, int index, int maxCharLen, out string strCh)
        {
            bool issubchar = false;
            strCh = "";
            int len = maxCharLen;
            if (index < maxCharLen)
            {
                len = index + 1;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index - i + 1, i);
                if (RightSubChar.Contains<string>(strCh) || LeftSubChar.Contains<string>(strCh))
                {
                    issubchar = true;
                    break;
                }
                strCh = "";
            }

            return issubchar;  
        }

        private bool GetNextLeftDependentVowel(string first, int index, int maxCharLen, out string strCh)
        {
            bool isdependentvowel = false;
            strCh = "";
            int len = maxCharLen;
            if (index < maxCharLen)
            {
                len = index + 1;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index - i + 1, i);
                if (DependentVowelList1.Contains<string>(strCh) || DependentVowelList2.Contains<string>(strCh))
                {
                    isdependentvowel = true;
                    break;
                }
                strCh = "";
            }

            return isdependentvowel;
        }

        private bool GetNextLeftHalfChar(string first, int index, int maxCharLen, out string strCh)
        {
            bool ishalfchar = false;
            strCh = "";
            int len = maxCharLen;
            if (index < maxCharLen)
            {
                len = index + 1;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index - i + 1, i);
                if (HalfCharLeft.Contains<string>(strCh) || HalfCharRight.Contains<string>(strCh))
                {
                    ishalfchar = true;
                    break;
                }
                strCh = "";
            }

            return ishalfchar;
        }

        private bool GetNextLeftSpecialSymbol(string first, int index, int maxCharLen, out string strCh)
        {
            bool IsSymbol = false;
            strCh = "";
            int len = maxCharLen;
            if (index < maxCharLen)
            {
                len = index + 1;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index - i + 1, i);
                if (SpecialSymbol.Contains<string>(strCh) || Digit.Contains<string>(strCh))
                {
                    IsSymbol = true;
                    break;
                }
                strCh = "";
            }

            return IsSymbol;
        }

        //right
        private bool GetNextRightFullChar(string second, int index, int maxCharLen, out string strCh)
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index , i);
                if (IndependentVowelList.Contains<string>(strCh) || ConsonantList1.Contains<string>(strCh) || ConsonantList2.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }

            return IsChar;
        }

        private bool GetNextRightSubChar(string second, int index, int maxCharLen, out string strCh)
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index, i);
                if (RightShiftChar.Contains<string>(strCh) || LeftSubChar.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        private bool GetNextRightDependentVowel(string second, int index, int maxCharLen, out string strCh)
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index, i);
                if (DependentVowelList1.Contains<string>(strCh) || DependentVowelList2.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        private bool GetNextRightHalfChar(string second, int index, int maxCharLen, out string strCh)
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index, i);
                if (HalfCharLeft.Contains<string>(strCh) || HalfCharRight.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        private bool GetNextRightSpecialSymbol(string second, int index, int maxCharLen, out string strCh)
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index, i);
                if (SpecialSymbol.Contains<string>(strCh) || Digit.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        private string GetLeftSideReplacementChar(string ch)
        {
            string rightchar = "";
            string leftchar = "";
            int i = Array.IndexOf<string>(RightShiftChar, ch);
            if(i>=0)
            {
                string[] temp = RightReplaceWith[i].Split(new string[] { CharacterSeperator }, StringSplitOptions.None);
                leftchar = temp[0];
                rightchar = temp[1];
            }

            return leftchar;
        }

        private string GetRightSideReplacementChar(string ch)
        {
            string rightchar = "";
            string leftchar = "";
            int i = Array.IndexOf<string>(LeftShiftChar, ch);

            if (i >= 0)
            {
                string[] temp = LeftReplaceWith[i].Split(new string[] { CharacterSeperator }, StringSplitOptions.None);
                leftchar = temp[0];
                rightchar = temp[1];

            }
            return rightchar;
        }

        private bool IsLeftShiftMeetingRightShift(string first, int index, int maxCharLen, out string strCh)//skip the character
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;           
            if (index < maxCharLen)
            {
                len = index+1;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = first.Substring(index-i+1, i);
                if (RightShiftChar.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        private bool IsRightShiftMeetingShiftChar(string second, int index, int maxCharLen, out string strCh)//stop case RightShiftChar or LeftShif Char
        {
            bool IsChar = false;
            strCh = "";
            int len = maxCharLen;
            int diff = second.Length - index;
            if (diff < maxCharLen)
            {
                len = diff;
            }
            for (int i = len; i > 0; i--)
            {
                strCh = second.Substring(index, i);
                if (RightShiftChar.Contains<string>(strCh) || LeftShiftChar.Contains<string>(strCh))
                {
                    IsChar = true;
                    break;
                }
                strCh = "";
            }
            return IsChar;
        }

        #endregion

        #region GetTranslationPath

        private String[] FontList;
        private String[] MappingTable;
        private Node[,] NodeMatrix;

        public const String FontSeperator = "*#*";
        public const int Infinite = 100;

        private Node GetTranslationPath(string sourFont, string destinationFont)
        {
            Node retNode;
            SetFontList();
            SetMappingTable();
            int i = Array.IndexOf<String>(FontList, sourFont);
            int j = Array.IndexOf<String>(FontList, destinationFont);
            retNode = GetTranslationPath(i, j);
            return retNode;
        }
        private Node GetTranslationPath(int i, int j)
        {
            string path;
            SetInitialValue();
            ShortestPathFunction();
            return NodeMatrix[i,j];
            
        
        }
        public void SetInitialValue()
        {
            int Len = FontList.Length;
            NodeMatrix= new Node[Len,Len];
            int content;

            for (int i = 0; i < Len; i++)
            {
                for (int j = 0; j < Len; j++)
                {
                    content = -1;
                    string map1 = FontList[i] + FontSeperator + FontList[j];
                    string path = FontList[i] + FontSeperator + FontList[j];

                    if (FontList[i] == FontList[j])
                    {
                        content = 0;
                    }
                    else if(MappingTable.Contains(map1))
                    {
                        content = 1;
                    }
                    else
                    {
                        content = Infinite;
                    }

                    string index="["+FontList[i]+","+FontList[j]+"]";

                    Node tempNode = new Node(index, content, path);

                    NodeMatrix[i, j] = tempNode;

                }
            }


        
        }
        private void SetFontList()
        { 
            //Run querry for selected font maapint avalable in db
            DataTable dt = new DataTable();
            FontList = dt.AsEnumerable().Select(row => row.Field<String>("Column Name")).ToArray();
        }

        private void SetMappingTable()
        { 
            //Get all font list from DB sourcefont+ destination font
            DataTable dt = new DataTable();
            int len = dt.Rows.Count;
            if (len > 0)
            {
                MappingTable = new String[len];
                for (int i = 0; i < len; i++)
                {
                    MappingTable[i] = Convert.ToString(dt.Rows[i]["sourcefontname"]+FontSeperator+dt.Rows[i]["destination font name"]);
                    //this is list of fonts having direct mappint of weight=1
                }
            }
            
        }
        public void ShortestPathFunction()
        {
            int count = FontList.Length;
            for (int k = 0; k < count; k++)
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (NodeMatrix[i, j].Weight > (NodeMatrix[i, k].Weight + NodeMatrix[k, j].Weight))
                        {
                            NodeMatrix[i, j].Weight = NodeMatrix[i, k].Weight + NodeMatrix[k, j].Weight;
                            NodeMatrix[i, j].Path = NodeMatrix[i, k].Path +FontSeperator+ NodeMatrix[k, j].Path;
                        }
                    }
                }
            
            }
        }

        public void WriteMatrix()
        {
            string strMatrix = "";
            int count = FontList.Length;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                   strMatrix+= NodeMatrix[i,j].Weight+"["+NodeMatrix[i,j].Path+"]";
                   strMatrix += "\t";
                }
                strMatrix += "\n";
            }

            MessageBox.Show(strMatrix);
        
        }
        private Node[,] GetNodeMatrix()
        {
            Node[,] tempMatrix;
            SetFontList();
            SetMappingTable();
            SetInitialValue();
            ShortestPathFunction();
            tempMatrix = NodeMatrix;
            return tempMatrix;
        
        }

        private String[] GetDestinationFontList(String sourceFont)
        {
            Node[,] nodeMatrix = GetNodeMatrix();
            String[] destinationfont = new String[] { };
            if (String.IsNullOrEmpty(sourceFont))
            {
                return destinationfont;
            }
            int sourceIndex = Array.IndexOf<String>(FontList, sourceFont);
            int len = FontList.Length;
            StringBuilder BuilderDestination = new StringBuilder();

            Node tempNode;
            for (int j = 0; j < len; j++)
            {
                tempNode = nodeMatrix[sourceIndex, j];
                if (tempNode.Weight < Infinite)
                {
                    BuilderDestination.Append(FontList[j]);
                    BuilderDestination.Append(FontSeperator);
                }
            }
            String strdestinationfont = BuilderDestination.ToString();
            strdestinationfont = strdestinationfont.Substring(0, (strdestinationfont.Length - FontSeperator.Length));
            destinationfont = strdestinationfont.Split(new String[]{FontSeperator},StringSplitOptions.RemoveEmptyEntries);
            return destinationfont;

        }

       class Node
        {
            public String FontName="";
            public int Weight=1;
            public String Path="";

            public Node(string fontname,int weight,string path)
            {
               FontName=fontname;
                Weight= weight;
                Path=path;
            }

            public override string ToString()
            {
                return FontName;
            }       
        }
        #endregion
    }


}
