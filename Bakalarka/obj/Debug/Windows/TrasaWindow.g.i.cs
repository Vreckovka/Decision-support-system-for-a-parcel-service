﻿#pragma checksum "..\..\..\Windows\TrasaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7FBD5550A02C848AFF6B124C92B0BE0C94455CE7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bakalarka.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Bakalarka.Windows {
    
    
    /// <summary>
    /// TrasaWindow
    /// </summary>
    public partial class TrasaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 23 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelVozidla;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateTimePicker_VybratyDatum;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtPotvrdDatum;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ZoznamAut;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelTovary;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\TrasaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid vsetkyTovaryGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Bakalarka;component/windows/trasawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\TrasaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Windows\TrasaWindow.xaml"
            ((Bakalarka.Windows.TrasaWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Windows\TrasaWindow.xaml"
            ((Bakalarka.Windows.TrasaWindow)(target)).StateChanged += new System.EventHandler(this.Window_StateChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\Windows\TrasaWindow.xaml"
            ((Bakalarka.Windows.TrasaWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StackPanelVozidla = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.DateTimePicker_VybratyDatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.ButtPotvrdDatum = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Windows\TrasaWindow.xaml"
            this.ButtPotvrdDatum.Click += new System.Windows.RoutedEventHandler(this.ButtPotvrdDatum_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ZoznamAut = ((System.Windows.Controls.ListBox)(target));
            
            #line 31 "..\..\..\Windows\TrasaWindow.xaml"
            this.ZoznamAut.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ZoznamAut_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StackPanelTovary = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.vsetkyTovaryGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            
            #line 143 "..\..\..\Windows\TrasaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Uloz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 8:
            
            #line 122 "..\..\..\Windows\TrasaWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.PrijatCheckBox_Click);
            
            #line default
            #line hidden
            
            #line 122 "..\..\..\Windows\TrasaWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

