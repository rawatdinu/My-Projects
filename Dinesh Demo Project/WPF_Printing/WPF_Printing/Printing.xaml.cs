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
using System.Windows.Shapes;
using System.Printing;
using System.Windows.Documents.DocumentStructures;
using System.Drawing.Printing;
using System.Drawing.Imaging;

using WPF_Printing;
using System.Data;

namespace WPF_Printing
{
    /// <summary>
    /// Interaction logic for Printing.xaml
    /// </summary>
    public partial class Printing : Window
    {
        public Printing()
        {
            InitializeComponent();
        }
        DBService DBService = new DBService();

        public FixedPage CurrentPage;
        public PageContent pgContent;


        public int PageCount = 0;

        public double tempPaperwidht = 0;

        public double PaperWidth;
        public double PaperHight;
        public double PageWidth;
        public double PageHeight;

        public double CenterGap;



        public string PrintType = "A4";



        public List<FixedPage> pgCollection = new List<FixedPage>();

        public double MarginTop;
        public double MarginBottom;
        public double MarginLeft;
        public double MarginRight;

        public double AdjtMarginTop;
        public double AdjtMarginBottom;
        public double AdjtMarginLeft;
        public double AdjtMarginRight;


        public double PrnWidth;
        public double PrnHeight;


        private void CreateNewPage()
        {
            
            CurrentPage = new FixedPage();
            CurrentPage.Name = "Page" + PageCount;
            CurrentPage.Width = PageWidth;
            CurrentPage.Height = PageHeight;

        }

        private void AddPageToCollection()
        {
            pgCollection.Add(CurrentPage);
            PageCount = pgCollection.Count;
        }
        
        private void SetPaper()
        {
            String str = "SELECT Paper, Width, Height, CenterGap, Top, Bottom, Left, Right, AdjTop, AdjBottom, AdjLeft, AdjRight  FROM PageSetup where Paper='" + PrintType.Trim() + "'";

            try
            {
                DataTable dt = DBService.getDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    PageWidth = Convert.ToDouble(dt.Rows[0]["Width"]);
                    PageHeight = Convert.ToDouble(dt.Rows[0]["Height"]);
                    CenterGap = Convert.ToDouble(dt.Rows[0]["CenterGap"]);

                    MarginTop = Convert.ToDouble(dt.Rows[0]["Top"]);
                    MarginBottom = Convert.ToDouble(dt.Rows[0]["Bottom"]);
                    MarginLeft = Convert.ToDouble(dt.Rows[0]["Left"]);
                    MarginRight = Convert.ToDouble(dt.Rows[0]["Right"]);

                    #region AdjustMargin

                    AdjtMarginTop = Convert.ToDouble(dt.Rows[0]["AdjTop"]);
                    AdjtMarginBottom = Convert.ToDouble(dt.Rows[0]["AdjBottom"]);
                    AdjtMarginLeft = Convert.ToDouble(dt.Rows[0]["AdjLeft"]);
                    AdjtMarginRight = Convert.ToDouble(dt.Rows[0]["AdjRight"]);

                    #endregion

                    PrnWidth = PageWidth - (MarginLeft + MarginRight);
                    PrnHeight = PageHeight - (MarginTop + MarginBottom);
                   
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public void CreatePageCollection()
        {
            pgCollection = new List<FixedPage>();
            PageCount = 0;
            SetPaper();
            Disp_Reading(PrnWidth, PrnHeight);        
        }

      public  String predictionText = "";
        FontFamily fontFamily = new FontFamily("Arial");

        private void Disp_Reading(double width, double height)  //template height and width
        {

            try
            {

                double h1 = height;

                double Head_font_size = 26;
                double Head_font_Height = Math.Ceiling(Head_font_size * fontFamily.LineSpacing);
                double Head_Height = 0;

                double subHead_font_size = 22;
                double subHead_font_Height = Math.Ceiling(subHead_font_size * fontFamily.LineSpacing);
                double subHead_Height = 0;

                double text_font_size = 16;
                double text_font_Height = Math.Ceiling(text_font_size * fontFamily.LineSpacing);


                String ss = predictionText;

                //for Header

                StackPanel stkHeader = new StackPanel();
                stkHeader.Width = width;
                stkHeader.Height = height;
                stkHeader.Margin = new Thickness(MarginLeft, MarginTop, 0, 0);

                //Header

                StackPanel stkPnl = new StackPanel();
                double x = 0, y = 0, top = height - h1, bottom = 0;

                stkPnl.HorizontalAlignment = HorizontalAlignment.Center;
                stkPnl.Width = width;                
                stkPnl.Margin = new Thickness(x, top, y, bottom);
                TextBlock tx = new TextBlock();

                tx.FontSize = Head_font_size;
                tx.FontFamily = fontFamily;
                tx.FontWeight = FontWeights.Bold;
                tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                tx.TextAlignment = TextAlignment.Center;
                tx.Text = "Heading";

                //Head_Height = tx.LineHeight;
                Head_Height = tx.FontFamily.LineSpacing + Head_font_Height;

                stkPnl.Children.Add(tx);
                stkHeader.Children.Add(stkPnl);

                h1 = h1 - Head_Height;

                //SubHeading

                stkPnl = new StackPanel();
                x = 0; y = 0; top = height - h1; bottom = 0;


                stkPnl.HorizontalAlignment = HorizontalAlignment.Center;
                stkPnl.Width = width;               
                stkPnl.Margin = new Thickness(x, top, y, bottom);
                tx = new TextBlock();

                tx.FontSize = subHead_font_size;
                tx.FontFamily = fontFamily;
                tx.FontWeight = FontWeights.Bold;
                tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                tx.TextAlignment = TextAlignment.Center;
                tx.Text = "Sub-Heading";

                //subHead_Height = tx.LineHeight;
                subHead_Height = tx.FontFamily.LineSpacing + subHead_font_Height;

                stkPnl.Children.Add(tx);
                stkHeader.Children.Add(stkPnl);

                h1 = h1 - subHead_Height;

                //Create new page for content
                CreateNewPage();

                //Text

                while (ss != "")
                {
                    if (h1 < 20)
                    {
                        //add content to page
                        CurrentPage.Children.Add(stkHeader);
                        AddPageToCollection();
                        /*************************/
                        //Create new page for content
                        CreateNewPage();
                        h1 = height;
                        stkHeader = new StackPanel();
                        stkHeader.Width = width;
                        stkHeader.Height = height;
                        stkHeader.Margin = new Thickness(MarginLeft, MarginTop, 0, 0);


                    }

                    stkPnl = new StackPanel();
                    x = 0; y = 0; top = height - h1; bottom = 0;
                    stkPnl.Margin = new Thickness(x, top, y, bottom);

                    String strText="";
                    double temCntrHeight = GetControlHeightForText(ss, text_font_size, fontFamily, width, h1, out strText);

                    tx = new TextBlock();

                    tx.FontSize = text_font_size;
                    tx.FontFamily = fontFamily;
                    tx.Width = width;
                    tx.Height = temCntrHeight;
                    tx.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tx.TextAlignment = TextAlignment.Justify;
                    tx.TextWrapping = TextWrapping.Wrap;
                    tx.Padding = new Thickness(3, 0, 2, 0);
                    tx.Text = strText;
                    stkPnl.Children.Add(tx);
                    stkHeader.Children.Add(stkPnl);

                   
                    ss = ss.Substring(strText.Length);
                    h1 = h1 - temCntrHeight;

                }

                //add content to page
                CurrentPage.Children.Add(stkHeader);
                AddPageToCollection();
                /*************************/

                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        //TextBoxt=TextBlock

        private double GetControlHeightForText(String ss, double fntsize,FontFamily fntFamily, double width, double h1,  out String  strOut) //h1 is available height 
        {
            double CntrHight = h1;

            txtBox.Clear();
            txtBox.FontSize = fntsize;
            txtBox.FontFamily = fntFamily;
            txtBox.Width = width;
            double extheight = txtBox.ExtentHeight;
            txtBox.Height = h1;
            txtBox.MinHeight = 0;
            txtBox.Padding = new Thickness(0, 0, 0, 0);
            txtBox.BorderThickness = new Thickness(0, 0, 0, 0);
            txtBox.TextWrapping = TextWrapping.Wrap;
            txtBox.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            txtBox.HorizontalAlignment = HorizontalAlignment.Stretch;
            txtBox.TextAlignment = TextAlignment.Justify;
            txtBox.AppendText(ss);

            grdMain.UpdateLayout();



            if ((txtBox.ExtentHeight + 10) < h1)     //content less than available height
            {
                strOut = ss;
                CntrHight = txtBox.ExtentHeight + 10;
            }
            else  ////content more than available height                    
            {

                int count = txtBox.GetLastVisibleLineIndex();
                int length = 0;

                for (int i = 0; i <= count; i++)
                {
                    length += txtBox.GetLineLength(i);
                }

                strOut = ss.Substring(0, length);
                CntrHight = h1;

            }

            return CntrHight;

            
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double hi = txtBox.Height;
            double extentHeight = txtBox.ExtentHeight;

            int i = txtBox.GetLastVisibleLineIndex();

            double fontSize = txtBox.FontSize;
            double fontHeight = Math.Ceiling(fontSize * txtBox.FontFamily.LineSpacing);
            double LineH = txtBox.FontFamily.LineSpacing + fontHeight;
            double maxHeight = txtBox.MaxHeight;
            double calcMaxH = (i - 1) * LineH;


            MessageBox.Show("Extent Height=" + Convert.ToString(extentHeight));
            MessageBox.Show("Last Visible Line Index=" + Convert.ToString(i));
        }

    }
}
