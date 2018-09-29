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
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for DataBinding.xaml
    /// </summary>
    public partial class DataBinding : UserControl
    {
        ObservableCollection<User> Users = new ObservableCollection<User>();
        int UserNo = 0;
        public DataBinding()
        {
            InitializeComponent();

            Users.Add(new User("Ram"));
            Users.Add(new User("Kumar Singh"));
            Users.Add(new User("Gabbar"));

            lstUser.ItemsSource = Users;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserNo += 1;
            String name = "User" + UserNo;
            Users.Add(new User(name));            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstUser.SelectedItem != null)
            {
                UserNo += 1;
                String tempName = "Rename" + UserNo;
                (lstUser.SelectedItem as User).Name = tempName;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstUser.SelectedItem != null)
            {
                Users.Remove(lstUser.SelectedItem as User);
            }
        }

       
    }
    public class User:INotifyPropertyChanged
    {
        private string name;
        public String Name 
        { get
            {
                return this.name;
            }
            set
            {
                if(this.name!=value)
                {
                    this.name = value;
                    this.P("Name");
                }
                
            }
        }
        
        public User(String name)
        {
            Name = name;
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
      

        public void P(string propName)
        {

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }


    }
}
