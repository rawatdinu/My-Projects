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
using WPF_Printing;
using System.Data;

namespace WPF_Printing
{
    /// <summary>
    /// Interaction logic for PageSetup.xaml
    /// </summary>
    public partial class PageSetup : Window
    {
        DBService DBService = new DBService();
        double Width;
        double Height;
        double CenterGap;

        double MarginTop;
        double MarginBottom;
        double MarginLeft;
        double MarginRight;

        double AdjTop;
        double AdjBottom;
        double AdjLeft;
        double AdjRight;

        string PaperType = "A4";




        public PageSetup()
        {
            InitializeComponent();
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String str = "SELECT Paper, Width, Height, CenterGap, Top, Bottom, Left, Right, AdjTop, AdjBottom, AdjLeft, AdjRight  FROM PageSetup where Paper='" + PaperType.Trim() + "'";

            try
            {
                DataTable dt = DBService.getDataTable(str);
                if (dt.Rows.Count > 0)
                {
                    Width = Convert.ToDouble(dt.Rows[0]["Width"]);
                    Height = Convert.ToDouble(dt.Rows[0]["Height"]);
                    CenterGap = Convert.ToDouble(dt.Rows[0]["CenterGap"]);

                    MarginTop = Convert.ToDouble(dt.Rows[0]["Top"]);
                    MarginBottom = Convert.ToDouble(dt.Rows[0]["Bottom"]);
                    MarginLeft = Convert.ToDouble(dt.Rows[0]["Left"]);
                    MarginRight = Convert.ToDouble(dt.Rows[0]["Right"]);

                    AdjTop = Convert.ToDouble(dt.Rows[0]["AdjTop"]);
                    AdjBottom = Convert.ToDouble(dt.Rows[0]["AdjBottom"]);
                    AdjLeft = Convert.ToDouble(dt.Rows[0]["AdjLeft"]);
                    AdjRight = Convert.ToDouble(dt.Rows[0]["AdjRight"]);
                  //  txtT.Text = "123";//  Convert.ToString(MarginTop);
                    mytext.Text = "kjkfd";
                    TextBox kds = new TextBox();
                    kds.Text = "kjkfd";
                    txtT = kds;
                    VarToTextBox();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void VarToTextBox()
        {
           
            try
            {
                txtWidth.Text = Convert.ToString(Width);
                txtHeight.Text = Convert.ToString(Height);
                txtCenterGap.Text = Convert.ToString(CenterGap);

                //txtTop.Text = "kjie"; //  Convert.ToString(MarginTop);
                //txtBottom.Text = Convert.ToString(MarginBottom);
                //txtLeft.Text = Convert.ToString(MarginLeft);
                //txtRight.Text = Convert.ToString(MarginRight);

                //txtAdjtTop.Text = Convert.ToString(AdjTop);
                //txtAdjtBottom.Text = Convert.ToString(AdjBottom);
                //txtAdjtLeft.Text = Convert.ToString(AdjLeft);
                //txtAdjtRight.Text = Convert.ToString(AdjRight);
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TextBoxToVar();
            PaperType = cmbType.Text.Trim();
            try
            {
                string str = "Update  PageSetup Set Width=" + Width + ", Height=" + Height + ", CenterGap=" + CenterGap + ", Top=" + MarginTop + ", Bottom=" + MarginBottom + ", Left=" + MarginLeft + ", Right=" + MarginRight + ", AdjTop=" + AdjTop + ", AdjBottom=" + AdjBottom + ", AdjLeft=" + AdjLeft + ", AdjRight=" + AdjRight + "  where Paper='" + PaperType + "'";

                int result = DBService.ExecuteSQL(str);
                if (result != 0)
                {
                    MessageBox.Show("Record saved successfully");
                }
                else
                {
                    MessageBox.Show("error");
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void TextBoxToVar()
        {
            try
            {
                Width = Convert.ToDouble(txtWidth.Text);
                Height = Convert.ToDouble(txtHeight.Text);
                CenterGap = Convert.ToDouble(txtCenterGap.Text);

                //MarginTop = Convert.ToDouble(txtTop.Text);
                //MarginBottom = Convert.ToDouble(txtBottom.Text);
                //MarginLeft = Convert.ToDouble(txtLeft.Text);
                //MarginRight = Convert.ToDouble(txtRight.Text);

                AdjTop = Convert.ToDouble(txtAdjtTop.Text);
                AdjBottom = Convert.ToDouble(txtAdjtBottom.Text);
                AdjLeft = Convert.ToDouble(txtAdjtLeft.Text);
                AdjRight = Convert.ToDouble(txtAdjtRight.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.SelectedIndex = 0;
            PaperType = cmbType.Text.Trim();
        }
    }
}
