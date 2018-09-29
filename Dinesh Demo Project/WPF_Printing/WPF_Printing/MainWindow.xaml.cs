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
using System.Printing;
using System.Drawing;
using System.Windows.Documents.DocumentStructures;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using WPF_Printing;




namespace WPF_Printing
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

        //private FixedPage CurrentPage;
        PageContent pgContent;


        private FixedDocument PrnDoc;
        private FixedDocument PrnBookDoc;
        int PageCount = 0;


        private double PaperWidth;
        private double PaperHight;
        private double PageWidth;
        private double PageHeight;

        private double CenterGap;

        PageOrientation PageOrientation;
       


        List<FixedPage> pgCollection = new List<FixedPage>();

        //private double MarginTop;
        //private double MarginBottom;
        //private double MarginLeft;
        //private double MarginRight;

        //private double AdjtMarginTop;
        //private double AdjtMarginBottom;
        //private double AdjtMarginLeft;
        //private double AdjtMarginRight;


        //private double PrnWidth;
        //private double PrnHeight;
        Printing objPrint;
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            objPrint = new Printing();
            objPrint.PrintType = cmbType.Text.Trim();
            objPrint.predictionText = txtText.Text;
            objPrint.Show();
            objPrint.Visibility = Visibility.Hidden;
           
            objPrint.CreatePageCollection();

            

            pgCollection = objPrint.pgCollection;

            PageWidth = objPrint.PageWidth;
            PageHeight = objPrint.PageHeight;
            CenterGap = objPrint.CenterGap;

            PageCollectionToDoc();

        }

     

        //private void CreateNewPage()
        //{
        //    CurrentPage = new FixedPage();
        //    CurrentPage.Name = "Page" + PageCount;
        //    CurrentPage.Width = PageWidth;
        //    CurrentPage.Height = PageHeight;

        //}

        //private void AddPageToCollection()
        //{
        //    pgCollection.Add(CurrentPage);
        //    PageCount = pgCollection.Count;
        //}
        //private void SetPaper()
        //{
        //    if (cmbType.Text == "A4")
        //    {
        //        PageWidth = double.Parse(txtWidth.Text);
        //        PageHeight = double.Parse(txtHeight.Text);
        //        PaperWidth = PageWidth;
        //        PaperHight = PageHeight;
        //        PageOrientation = PageOrientation.Portrait;
        //    }

        //    else if (cmbType.Text == "Book")
        //    {

        //        PageWidth = double.Parse(txtWidth.Text);
        //        PageHeight = double.Parse(txtHeight.Text);
        //        CenterGap = double.Parse(txtCenterGap.Text);

        //        PaperWidth = 2 * PageWidth + CenterGap;
        //        PaperHight = PageHeight;
        //        SwapPageSize();
        //        PageOrientation = PageOrientation.Landscape;
        //    }

        //    MarginTop = double.Parse(txtTop.Text);
        //    MarginBottom = double.Parse(txtBottom.Text);
        //    MarginLeft = double.Parse(txtLeft.Text);
        //    MarginRight = double.Parse(txtRight.Text);

        //    PrnWidth = PageWidth - (MarginLeft + MarginRight);
        //    PrnHeight = PageHeight - (MarginTop + MarginBottom);

        //    #region AdjustMargin

        //    AdjtMarginTop = double.Parse(txtAdjtTop.Text);
        //    AdjtMarginBottom = double.Parse(txtAdjtBottom.Text);
        //    AdjtMarginLeft = double.Parse(txtAdjtLeft.Text);
        //    AdjtMarginRight = double.Parse(txtAdjtRight.Text);

        //    MarginTop -= AdjtMarginTop;
        //    MarginBottom -= AdjtMarginBottom;
        //    MarginLeft -= AdjtMarginLeft;
        //    MarginRight -= AdjtMarginRight;

        //    #endregion

        //}

     

        private void PrintDocument(FixedDocument PrnDocument)
        {
            PrintDialog pd = new PrintDialog();
            PrintTicket ticket = new PrintTicket();

            ticket = new PrintTicket();
            ticket.PageMediaSize = new PageMediaSize(PageMediaSizeName.Unknown,PaperWidth, PaperHight);

            ticket.PageOrientation = PageOrientation;
            ticket.PageMediaType = PageMediaType.AutoSelect;
            ticket.PageResolution = new PageResolution(PageQualitativeResolution.Normal);
            ticket.PageBorderless = PageBorderless.None;

            //ticket.Stapling = Stapling.None;

            #region ServerPrinter

            //List<string> PrinterList = new List<string>();

            //PrintServer prntserver = new PrintServer(@"\\mksnet");
            //PrintQueueCollection queueCollection = prntserver.GetPrintQueues();

            //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    PrinterList.Add(printer);

            //}

            //string[] tempPrint = PrinterList.ToArray();
            //PrintQueue pq = prntserver.GetPrintQueue("HP LaserJet P2015 Series UPD PCL 6");


            #endregion



            #region Virtual Printer


            List<string> PrinterList = new List<string>();
            LocalPrintServer prntserver = new LocalPrintServer();
            PrintQueueCollection queueCollection = prntserver.GetPrintQueues();

            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                PrinterList.Add(printer);

            }

            string[] tempPrint = PrinterList.ToArray();
            PrintQueue pq = prntserver.GetPrintQueue(PrinterList[0]);  //Virtual


            #endregion

            #region Cannon Printer
            //List<string> PrinterList = new List<string>();
            //LocalPrintServer prntserver = new LocalPrintServer();
            //PrintQueueCollection queueCollection = prntserver.GetPrintQueues();

            //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    PrinterList.Add(printer);

            //}

            //string[] tempPrint = PrinterList.ToArray();


            //PrintQueue pq = prntserver.GetPrintQueue(PrinterList[5]);   //Canon

            #endregion




            #region printcapability




            // get selected printer capabilities
            //System.Printing.PrintCapabilities capabilities = pd.PrintQueue.GetPrintCapabilities(pd.PrintTicket);

            ////get scale of the print wrt to screen of WPF visual
            //double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / this.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
            //               this.ActualHeight);

            ////Transform the Visual to scale
            //this.LayoutTransform = new ScaleTransform(scale, scale);

            ////get the size of the printer page
            //Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

            ////update the layout of the visual to the printer page size.
            //this.Measure(sz);
            //this.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

            //now print the visual to printer to fit on the one page.
            //pd.PrintVisual(this, "First Fit to Page WPF Print");


            #endregion

            pq.UserPrintTicket = ticket;

            pd.PrintQueue = pq;
            pd.PrintDocument(PrnDocument.DocumentPaginator, "My First Document");


            /************************************/

        }

        private void SwapPageSize()
        {
            double tempDou = PaperWidth;
            PaperWidth = PaperHight;
            PaperHight = tempDou;

        }

        private void PageCollectionToDoc()
        {
            if (cmbType.Text == "A4")
            {
                PaperWidth = PageWidth;
                PaperHight = PageHeight;
                PageOrientation = PageOrientation.Portrait;

                SingleDocument();
               
            }
            else
            {
                PaperWidth = 2 * PageWidth + CenterGap;
                PaperHight = PageHeight;
                SwapPageSize();
                PageOrientation = PageOrientation.Landscape;

                BookSizeDocument();
              
            }
        }

        private void SingleDocument()
        {

            PrnDoc = new FixedDocument();
            foreach (FixedPage page in pgCollection)
            {
                pgContent = new PageContent();
                pgContent.Child = page;
                PrnDoc.Pages.Add(pgContent);

            }

            PrintDocument(PrnDoc);
        }

        private void BookSizeDocument()
        {
            GetBookSizePageNo();
            ArrangePageIndex();
            GetBookSizePageCollection();
            PrnBookDoc = new FixedDocument();
            int partLength = Count / 4;
            for (int i = 0; i < partLength; i++)
            {
                pgContent = new PageContent();
                pgContent.Child = BookSizePgCollection[i];
                PrnBookDoc.Pages.Add(pgContent);

            }
            //foreach (FixedPage page in BookSizePgCollection)
            //{
            //    pgContent = new PageContent();
            //    pgContent.Child = page;
            //    PrnBookDoc.Pages.Add(pgContent);

            //}

            PrintDocument(PrnBookDoc);

            MessageBox.Show("Reverse Pages for Backside Printing");
            PrnBookDoc = new FixedDocument();

            for (int i = partLength; i < Count / 2; i++)
            {
                pgContent = new PageContent();
                pgContent.Child = BookSizePgCollection[i];
                PrnBookDoc.Pages.Add(pgContent);

            }

            PrintDocument(PrnBookDoc);

            //foreach (FixedPage page in BookSizePgCollection)
            //{
            //    pgContent = new PageContent();
            //    pgContent.Child = page;
            //    PrnBookDoc.Pages.Add(pgContent);

            //}

        }

        List<FixedPage> BookSizePgCollection = new List<FixedPage>();
        int[] Arr1, Arr2;
        int Count;

        private void GetBookSizePageNo()
        {
            Count = pgCollection.Count;
            if (Count == 1)
            {
                pgCollection.Add(new FixedPage());
                Count = pgCollection.Count;
            }

            int temRem = Count % 4;

            if (temRem != 0)
            {
                Count += (4 - temRem);
            }

            for (int j = 0; j < temRem; j++)
            {
                pgCollection.Add(new FixedPage());
            }

        }

        private void ArrangePageIndex()
        {
            Arr1 = new int[Count / 2];
            Arr2 = new int[Count / 2];
            for (int i = 0; i < Count / 2; i++)
            {
                Arr1[i] = (2 * i + 1) - 1;
                Arr2[i] = (Count - 2 * i) - 1;
            }

        }


        private void GetBookSizePageCollection()
        {
            BookSizePgCollection = new List<FixedPage>();
            FixedPage LPage, RPage, page;

            Grid grd;
            for (int i = 0; i < Count / 2; i++)
            {
                //LeftPage
                grd = new Grid();
                grd.Width = 2 * PageWidth + CenterGap;
                grd.HorizontalAlignment = HorizontalAlignment.Stretch;
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(PageWidth);
                grd.ColumnDefinitions.Add(colDef);
                //CentreGap
                colDef = new ColumnDefinition();
                colDef.Width = new GridLength(CenterGap);
                grd.ColumnDefinitions.Add(colDef);
                //RightPage
                colDef = new ColumnDefinition();
                colDef.Width = new GridLength(PageWidth);
                grd.ColumnDefinitions.Add(colDef);

                LPage = new FixedPage();
                RPage = new FixedPage();
                page = new FixedPage();

                LPage = pgCollection[Arr2[i]];
                RPage = pgCollection[Arr1[i]];

                LPage.HorizontalAlignment = HorizontalAlignment.Right;
                RPage.HorizontalAlignment = HorizontalAlignment.Left;
                grd.RowDefinitions.Add(new RowDefinition());

                Grid.SetColumn(LPage, 0);
                Grid.SetRow(LPage, 0);
                grd.Children.Add(LPage);

                Grid.SetColumn(RPage, 2);
                Grid.SetRow(RPage, 0);
                grd.Children.Add(RPage);

                page.Children.Add(grd);

                BookSizePgCollection.Add(page);

            }

        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var win = new WinStringLength();
           
            win.Show();
        }

        private void btnPgSetup_Click(object sender, RoutedEventArgs e)
        {
            var win = new PageSetup();
            win.Activate();
            win.Show();
        }

       
    }
}
