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

namespace PrintingStuff
{
    /// <summary>
    /// Interaction logic for PrinterSetting.xaml
    /// </summary>
    public partial class PrinterSetting : Window
    {
        public PrinterSetting()
        {
            InitializeComponent();
        }

        private void PrintTestPageClick(object sender, RoutedEventArgs e)
        {
            var server = new PrintServer();
            
            var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local,
     EnumeratedPrintQueueTypes.Connections});

            foreach (var queue in queues)
            {
                string PrinterName = queue.FullName.ToString();
                List<string> PageSizeList = new List<string>();
                string tempList="";
                //Console.WriteLine(queue.Name);
                var capabilities = queue.GetPrintCapabilities();
                foreach (PageMediaSize size in capabilities.PageMediaSizeCapability)
                {
                    PageSizeList.Add(size.ToString());
                    tempList += "\n" + size.ToString();
                
                }

                MessageBox.Show(PrinterName+ "\n" + tempList);
               
            }
        }
    }
}
