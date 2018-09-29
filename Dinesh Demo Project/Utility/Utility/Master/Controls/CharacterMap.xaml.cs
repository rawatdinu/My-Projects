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
using System.Collections.Generic;

namespace Utility
{
    /// <summary>
    /// Interaction logic for CharacterMap.xaml
    /// </summary>
    public partial class CharacterMap : UserControl
    {
        public IDictionary<int, ushort> characterMap;
        private FontFamily fontf;
        private GlyphTypeface Glyph;
        private SymbolView PreviousView = null;
        private ScaleTransform Scale = new ScaleTransform(1, 1);

        public CharacterMap()
        {
            InitializeComponent();
            cmbFont.ItemsSource = Fonts.SystemFontFamilies.OrderBy(x => x.Source);
            cmbFont.SelectedIndex = 0;
            FirstFont = cmbFont.SelectedItem as FontFamily;
            ExtractSymbols();
        }
        public event EventHandler FontComboChanged;

        public FontFamily FirstFont { get; set; }
        private SymbolView previousview = null;
        private int Zindex;
        public void ResetOldSymbol()
        {
            if (previousview != null)
            {
                previousview.RenderTransform = null;
                previousview.BorderThickness = new Thickness(0, 0, 1, 1);
                Canvas.SetZIndex(previousview, Zindex);
            }
        }

        public void ExtractSymbols()
        {
            if (wrapanel1 != null)
            {
               //Wait cursur program using (new WaitCursor)
                wrapanel1.Children.Clear();

                FontFamily fontselected = cmbFont.SelectedItem as FontFamily;
                TextElement.SetFontFamily(wrapanel1, fontselected);

                foreach (Typeface typeface in fontselected.GetTypefaces())
                {
                    typeface.TryGetGlyphTypeface( out Glyph);

                    if (Glyph != null)
                    {
                        if (cmbFont.SelectedItem.ToString() == "UnicodeHindi")// Range \U0900 to 097F
                        {
                            int fromcode = 0x0900;
                            int tocode = 0x0975;
                            GetUnicodeCharacter(fromcode, tocode);
                            break;
                        }

                        else
                        {
                            characterMap = Glyph.CharacterToGlyphMap;
                            int i = 0;

                            foreach (KeyValuePair<int, ushort> kvp in characterMap)
                            {
                                SymbolView view = new SymbolView();
                                view.Character.Text = Convert.ToChar(kvp.Key).ToString();
                                wrapanel1.Children.Add(view);
                                i++;                            
                            }
                            double d = Math.Ceiling(i * 25 / 24.0);
                            wrapanel1.Height = d + d * 0.2;
                            break;
                        }
                    
                    }
                  
                
                
                }
            
            }
        
        }

        private void GetUnicodeCharacter(int fromcode, int tocode)
        {
            int i = fromcode;
            for (i = fromcode; i <= tocode; i++)
            {
                SymbolView view = new SymbolView();

                String codePoint = i.ToString("X");
                int code = int.Parse(codePoint, System.Globalization.NumberStyles.HexNumber);
                String unicodeString = char.ConvertFromUtf32(code).ToString();
                view.Character.Text = unicodeString;

                wrapanel1.Children.Add(view);

            }
            double d = Math.Ceiling((tocode - fromcode + 1) * 25 / 24.0);

            wrapanel1.Height = d + d * 0.2;

        }
        private int currentIndex = -1;
        private void FocusSymbol(SymbolView view)
        {
            currentIndex = wrapanel1.Children.IndexOf(view);
            view.RenderTransform = Scale;
            view.BorderThickness = new Thickness(1, 1, 2, 2);
            Zindex = Canvas.GetZIndex(view);
            Canvas.SetZIndex(view, 150);
            previousview = view;
        
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExtractSymbols();
            if(FontComboChanged!=null)
            {
                FontComboChanged(this, new EventArgs());
            }
        
        }

        private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SymbolView view = null;
            if (e.OriginalSource is SymbolView)
            {
                view = e.OriginalSource as SymbolView;
            }
            else
            {
                FrameworkElement element = e.OriginalSource as FrameworkElement;
                if (element != null)
                    view = element.Parent as SymbolView;            
            }

            if (view != null)
            {
                ResetOldSymbol();
                FocusSymbol(view);
                if (e.ClickCount == 2)
                    Select(sender, e);
                    
            }
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            if (currentIndex != -1)
            {
                text.BeginChange();
                text.AppendText(((SymbolView)wrapanel1.Children[currentIndex]).Character.Text);
                text.EndChange();
            }
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, text.Text);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Window w = this.Parent as Window;
            w.DialogResult = sender == btnSelectClose ? true : false;
            w.Close();
        }


        private void OnFontKeyDown(object sender, KeyEventArgs e)
        {

            e.Handled = currentIndex != -1 ? true : false;
        }

        
       
        
    }
}
