﻿#pragma checksum "..\..\..\..\..\Master\Controls\CharacterMap.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA07618D457B6602822AC060DD1C3DE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Utility {
    
    
    /// <summary>
    /// CharacterMap
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class CharacterMap : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFont;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbFont;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrint;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scr;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapanel1;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdButtons;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelect;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCopy;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectClose;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Utility;component/master/controls/charactermap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblFont = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.cmbFont = ((System.Windows.Controls.ComboBox)(target));
            
            #line 22 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.cmbFont.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnSelectionChanged);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.cmbFont.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.OnFontKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.scr = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 5:
            this.wrapanel1 = ((System.Windows.Controls.WrapPanel)(target));
            
            #line 34 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.wrapanel1.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.grdButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.btnSelect = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.btnSelect.Click += new System.Windows.RoutedEventHandler(this.Select);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnCopy = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.btnCopy.Click += new System.Windows.RoutedEventHandler(this.Copy);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnSelectClose = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\..\Master\Controls\CharacterMap.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

