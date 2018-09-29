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
using System.Data;
using System.Windows.Controls.Primitives;


namespace DataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(string));
            table.Columns.Add("IsActive", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;

        }
        private DataTable GetDataTable2()
        {
            DataTable table = new DataTable();
            table.Columns.Add("IsSelect", typeof(bool));
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(string));
            table.Columns.Add("IsActive", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(true, 25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(false, 50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(true, 10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(false, 21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(false, 100, "Dilantin", "Melanie", DateTime.Now);
            return table;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            GetDataTable();



        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = GetDataTable();
            dg.ItemsSource = dt.DefaultView;
        }



        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }
        //There is a simple method for getting the current (selected) row of the DataGrid:

        public static DataGridRow GetSelectedRow(ref System.Windows.Controls.DataGrid grid)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
        }
        //We can also get a row by its indices:

        public static DataGridRow GetRow(ref System.Windows.Controls.DataGrid grid, int index)
        {
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            if (row == null)
            {
                // May be virtualized, bring into view and try again.
                grid.UpdateLayout();
                grid.ScrollIntoView(grid.Items[index]);
                row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            }
            return row;
        }
        //Now we can get a cell of a DataGrid by an existing row:

        public static DataGridCell GetCell(ref System.Windows.Controls.DataGrid grid, DataGridRow row, int column)
        {
            if (row != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);

                if (presenter == null)
                {
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(row);
                }

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                return cell;
            }
            return null;
        }
        //Or we can simply select a row by its indices:

        public static DataGridCell GetCell(ref System.Windows.Controls.DataGrid grid, int row, int column)
        {
            DataGridRow rowContainer = GetRow(ref grid, row);
            return GetCell(ref grid, rowContainer, column);
        }

        private void btnCell_Click(object sender, RoutedEventArgs e)
        {
            dg.UpdateLayout();
            DataGridCell obj = GetCell(ref dg, 0, 0);

            CheckBox chk = (CheckBox)obj.Content;//((System.Windows.Controls.ContentControl)(obj)).Content

            if (chk.IsChecked == true)
            {
                MessageBox.Show("True");
            }
            else
            {
                MessageBox.Show("false");
            }


        }

        private void buttion1_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = GetDataTable2();
            dg2.ItemsSource = dt.DefaultView;
        }

        private void buttion2_Click(object sender, RoutedEventArgs e)
        {
            dg2.UpdateLayout();

            DataGridRow row = (DataGridRow)dg2.ItemContainerGenerator.ContainerFromIndex(0);
            CheckBox checkBox = FindChild<CheckBox>(row, "chkSelectItem");
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    MessageBox.Show("true");
                }
                else
                {
                    MessageBox.Show("false");
                }
            }


            //DataGridCell obj = GetCell(ref dg2, 0, 0);

            //CheckBox chk = (CheckBox)obj.Content;//((System.Windows.Controls.ContentControl)(obj)).Content

            //if (chk.IsChecked == true)
            //{
            //    MessageBox.Show("True");
            //}
            //else
            //{
            //    MessageBox.Show("false");
            //}
        }






        //The functions above are extension methods. Their use is simple:

        //var selectedRow = grid.GetSelectedRow();
        //var columnCell = grid.GetCell(selectedRow, 0);

        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent is valid.  
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child 
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree 
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child.  
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search 
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name 
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found. 
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }





        public List<Product> GetProductList()
        {
            List<Product> list = new List<Product>();
            list.Add(new Product() { IsSelect = false, ProdName = "Product 1", Price = 100 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 2", Price = 200 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 3", Price = 300 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 4", Price = 400 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 5", Price = 500 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 6", Price = 600 });
            list.Add(new Product() { IsSelect = false, ProdName = "Product 7", Price = 700 });
            return list;


        }

        private void cmd1_Click(object sender, RoutedEventArgs e)
        {
            List<Product> list = new List<Product>();
            list = GetProductList();
            BindBindGrid3(list);

        }

        private void cmd2_Click(object sender, RoutedEventArgs e)
        {
            dg3.UpdateLayout();

            DataGridRow row = (DataGridRow)dg3.ItemContainerGenerator.ContainerFromIndex(0);
            CheckBox checkBox = FindChild<CheckBox>(row, "chkSelectItem");
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    MessageBox.Show("true");
                }
                else
                {
                    MessageBox.Show("false");
                }
            }
        }

        private void chk3Item_Checked(object sender, RoutedEventArgs e)
        {
            var row = (Product)dg3.SelectedItem;
            if (row != null)
            {
                row.IsSelect = true;
            }
            
        }

        private void chk3Item_Unchecked(object sender, RoutedEventArgs e)
        {
            var row = (Product)dg3.SelectedItem;
            row.IsSelect = false;
        }

        private void cmd3_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in dg3.Items)
            { 
            
            
            }
        }

        private void chk3_Checked(object sender, RoutedEventArgs e)
        {
            List<Product> list = new List<Product>();
            foreach (Product item in dg3.Items)
            {
                item.IsSelect = true;
                list.Add(item);
            }
            BindBindGrid3(list);
        }

        private void chk3_Unchecked(object sender, RoutedEventArgs e)
        {
            List<Product> list = new List<Product>();
            foreach (Product item in dg3.Items)
            {
                item.IsSelect = false;
                list.Add(item);
            }
            BindBindGrid3(list);
        }

        private void BindBindGrid3(List<Product> list)
        {
            dg3.ItemsSource = null;
            dg3.Items.Clear();
            dg3.ItemsSource = list;
         
        
        }



    }

    public class Product
    {
        public bool IsSelect { get; set; }
        public string ProdName { get; set; }
        public int Price { get; set; }

    }
}
