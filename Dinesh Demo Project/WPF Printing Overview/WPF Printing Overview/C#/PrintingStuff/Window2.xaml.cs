using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Printing;
using System.Windows.Documents.DocumentStructures;
namespace PrintingStuff
{
    public partial class Window2 : Window 
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            //If you reduce the size of the view area of the window, so the text does not all fit into one page, it will print separate pages
            string str = " If you reduce the size of the view area of the window, so \nthe text does not all fit into one page, it will print separate pages ";
            List<string> PrinterList = new List<string>();
            /*******************************/
            //printicket
            PrintTicket ticket = new PrintTicket();
            ticket.PageMediaSize = new PageMediaSize(100, 100);
            ticket.PageOrientation = PageOrientation.Portrait;
            ticket.PageOrder = PageOrder.Standard;


            LocalPrintServer prntserver = new LocalPrintServer();
            PrintQueueCollection queueCollection = prntserver.GetPrintQueues();
            PrintDialog printDialog = new PrintDialog();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterList.Add(printer);
                //MessageBox.Show(printer);

            }
            PageRange pr = new PageRange(1, 3);
            string[] tempPrint = PrinterList.ToArray();
            string printFullName = printDialog.PrintQueue.FullName;
            printDialog.PrintQueue = prntserver.GetPrintQueue(PrinterList[0]);
            printDialog.PrintTicket = ticket;
            printDialog.PageRange = pr;
            //DocumentPaginator paginatro = new DocumentPaginator();



            /***************************************************************/
            // add exptra pages
            FixedPage page = new FixedPage();
            FixedDocument Doc = new FixedDocument();


            //if(printDialog.ShowDialog() == true)
            //printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, str + "This is a Flow Document");

            string NewSelectedPrinter = printDialog.PrintQueue.FullName;


            /*****************new code*********************/
          
            // select printer and get printer settings
        PrintDialog pd = new PrintDialog();
            //if (pd.ShowDialog() != true) return;
         //Create a document
        double width = 400;
        double height = 600;
            
            FixedDocument fxDoc = new FixedDocument();
            fxDoc.DocumentPaginator.PageSize = new Size(width, height);

            // Create fixed page1
            //FixedPage page1 = new FixedPage();
            //page1.Width = width;
            //page1.Height = height;

            //// Create fixed page2
            //FixedPage page2 = new FixedPage();
            //page2.Width = width;
            //page2.Height = height;

            ////Add some text1
            TextBlock tx1 = new TextBlock();
            //tx1.Width = width;            
            //tx1.FontSize = 12;
            //tx1.Text = " Page1 And add the page to the document, this is a little tricky because we need to use a PageContent object as an intermediary and it looks like there is no way to add the page to the page content, the trick is to use the IAddChild interface – according to the documentation you’re not supposed to use IAddChild directly but it’s the only way to build a fixed document.";
            //tx1.TextAlignment = TextAlignment.Justify;
            //tx1.TextWrapping = TextWrapping.Wrap;
            //page1.Children.Add(tx1);

            ////Add some text2
            //tx1 = new TextBlock();
            //tx1.Width = width;
            //tx1.FontSize = 20;
            //tx1.Text = "  Page 2 And add the page to the document, this is a little tricky because we need to use a PageContent object as an intermediary and it looks like there is no way to add the page to the page content, the trick is to use the IAddChild interface – according to the documentation you’re not supposed to use IAddChild directly but it’s the only way to build a fixed document.";
            //tx1.TextAlignment = TextAlignment.Justify;
            //tx1.TextWrapping = TextWrapping.Wrap;
            //page2.Children.Add(tx1);




            // add page to document bye PageContent object
            //PageContent pgCont = new PageContent();
            //pgCont.Child = page1;
            //fxDoc.Pages.Add(pgCont);
            //pgCont = new PageContent();
            //pgCont.Child = page2;
            //fxDoc.Pages.Add(pgCont);

            FixedPage page1;
            Grid grd1;
            TextBlock tx2;
          
           fxDoc = new FixedDocument();
           FixedDocument fixDocument2=new FixedDocument();
           PageContent pgCont = new PageContent();
           Grid grd;
           FixedPage[] pageCollection = new FixedPage[10];
           //List<FixedPage> listPageCollection = new List<FixedPage>();
            for (int i = 0; i < 8; i++)
            {
               //CreatePage
                page = new FixedPage();
                page.Name = "Page" + i;
                page.Width = width;
                page.Height = height;
                /***********(2)*************/
                page1 = new FixedPage();
                page1.Name = "Page" + i;
                page1.Width = width;
                page1.Height = height;
               
                //Add text to Page.
                grd = new Grid();
                grd.Width = width;
                /*******(2)**********/
                grd1 = new Grid();
                grd1.Width = width;

                //Grid
                RowDefinition row = new RowDefinition();
                grd.RowDefinitions.Add(row);
                row = new RowDefinition();
                grd.RowDefinitions.Add(row);
                /************(2)******************/
                RowDefinition row1 = new RowDefinition();
                grd1.RowDefinitions.Add(row1);
                row1 = new RowDefinition();
                grd1.RowDefinitions.Add(row1);

                //Header TextBlock
                tx1 = new TextBlock();
                tx1.Width = width;
                tx1.FontSize = 20;
                tx1.Text ="Page Index " + i ;
                tx1.TextAlignment = TextAlignment.Center;
                //tx1.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(tx1, 0);
                grd.Children.Add(tx1);
                /***********(2)**************/
                //Header TextBlock
                tx2 = new TextBlock();
                tx2.Width = width;
                tx2.FontSize = 20;
                tx2.Text = "Page Index " + i;
                tx2.TextAlignment = TextAlignment.Center;
                //tx1.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(tx2, 0);
                grd1.Children.Add(tx2);
               


                //Paragraph
                tx1 = new TextBlock();
                tx1.Width = width;
                tx1.FontSize = 14;
                tx1.Text = "Page " + i + " And add the page to the document, this is a little tricky because we need to use a PageContent object as an intermediary and it looks like there is no way to add the page to the page content, the trick is to use the IAddChild interface – according to the documentation you’re not supposed to use IAddChild directly but it’s the only way to build a fixed document.";
                tx1.TextAlignment = TextAlignment.Justify;
                tx1.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(tx1, 1);
                grd.Children.Add(tx1);

                /**************(2)*********************/
                //Paragraph
                tx2 = new TextBlock();
                tx2.Width = width;
                tx2.FontSize = 14;
                tx2.Text = "Page " + i + " And add the page to the document, this is a little tricky because we need to use a PageContent object as an intermediary and it looks like there is no way to add the page to the page content, the trick is to use the IAddChild interface – according to the documentation you’re not supposed to use IAddChild directly but it’s the only way to build a fixed document.";
                tx2.TextAlignment = TextAlignment.Justify;
                tx2.TextWrapping = TextWrapping.Wrap;
                Grid.SetRow(tx2, 1);
                grd1.Children.Add(tx2);

               

                page.Children.Add(grd);
                //Add text to pagecontent
                page1.Children.Add(grd1);

                CloneObject c1= new CloneObject();
                pageCollection[i] = (FixedPage)c1.DeepCopy();

                pgCont = new PageContent();
                pgCont.Child = page;
                fxDoc.Pages.Add(pgCont);
                


            }
           
            ticket = new PrintTicket();
            ticket.PageMediaSize = new PageMediaSize(width , height);
            ticket.PageOrientation = PageOrientation.Portrait;
            //ticket.PagesPerSheet = 2;
            pd.PrintTicket = ticket;
            pd.PrintDocument(fxDoc.DocumentPaginator, "My First Document");


            /*****************Print According to Index************************************/

            pgCont = new PageContent();
            //pgCont= fxDoc.Pages[4];

            page = new FixedPage();
            page = pageCollection[3];
            pgCont.Child = page;

            fxDoc = new FixedDocument();
            fxDoc.Pages.Add(pgCont);

            ticket = new PrintTicket();
            ticket.PageMediaSize = new PageMediaSize(width, height);
            ticket.PageOrientation = PageOrientation.Portrait;
            //ticket.PagesPerSheet = 2;
            pd.PrintTicket = ticket;
            pd.PrintDocument(fxDoc.DocumentPaginator, "My First Document");

            /*****************************Cloning of Object******************************************************/
          

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window3();
            win.Show();
            this.Close();
        }

       
    }
}
