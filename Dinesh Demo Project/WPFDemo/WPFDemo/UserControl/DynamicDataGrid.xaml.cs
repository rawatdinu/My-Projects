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

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for DynamicDataGrid.xaml
    /// </summary>
    public partial class DynamicDataGrid : UserControl
    {
        public DynamicDataGrid()
        {
            InitializeComponent();
        }
        private const int SquareNo = 5;

        private void CreaterDesign(int cells)
        {
            RowDefinition rowdef;
            ColumnDefinition coldef;

            for (int i = 0; i < cells; i++)
            {
                rowdef = new RowDefinition();
                coldef = new ColumnDefinition();
                grdMain.RowDefinitions.Add(rowdef);
                grdMain.ColumnDefinitions.Add(coldef);
            }
            FillContent(cells);
        }
        private void FillContent(int cells)
        {
            Label temp;
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if ((i == cells - 1) && (j == cells - 1))//for last label
                    {
                        temp = new Label();
                        temp.Width = 60;
                        temp.Height = 60;


                        Grid.SetRow(temp, cells - 1);
                        Grid.SetColumn(temp, cells - 1);
                        grdMain.Children.Add(temp);


                        break;
                    }

                    int num = GetRandomUniqueNo();
                    temp = GetCellForGrid(num);
                    temp.Width = 60;
                    temp.Height = 60;
                    temp.FontSize = 30;

                    Grid.SetRow(temp, i);
                    Grid.SetColumn(temp, j);
                    grdMain.Children.Add(temp);
                }
            }

        }

        private Label GetCellForGrid(int num)
        {
            Label lbl = new Label();
            lbl.Content = new Number(num);
            return lbl;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillList();
            CreaterDesign(SquareNo);           
        }

#region Unique No
        private List<int> numberList = new List<int>();
        private int GetRandomUniqueNo()
        {
            int uniqueNo;
            int index;
            Random rnd = new Random();

            index = rnd.Next(0, numberList.Count);
            uniqueNo = numberList[index];
            RemoveFromList(uniqueNo);
            return uniqueNo;
        }

        private void FillList()
        {
            for (int i = 1; i < SquareNo * SquareNo; i++)
            {
                numberList.Add(i);
            }
        }
        private void RemoveFromList(int number)
        {
            numberList.Remove(number);
        }
#endregion
       
    }

    public class Number
    {
        private int _num;
        public int Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
            }

        }

        public Number(int num)
        {
            Num = num;
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }
}
