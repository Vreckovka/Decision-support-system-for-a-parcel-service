﻿#pragma checksum "..\..\PridajVozidloWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E95A834151D1FA7FF75806A0C6062FF7E33EE1E0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bakalarka;
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


namespace Bakalarka {
    
    
    /// <summary>
    /// PridajVozidloWindow
    /// </summary>
    public partial class PridajVozidloWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox znacka;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox typ;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox spz;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vyskaKuf;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sirkaKuf;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dlzkaKuf;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datumEvidencie;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\PridajVozidloWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtPridajVozidlo;
        
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
            System.Uri resourceLocater = new System.Uri("/Bakalarka;component/pridajvozidlowindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PridajVozidloWindow.xaml"
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
            this.znacka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.typ = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.spz = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.vyskaKuf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.sirkaKuf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dlzkaKuf = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.datumEvidencie = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.ButtPridajVozidlo = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\PridajVozidloWindow.xaml"
            this.ButtPridajVozidlo.Click += new System.Windows.RoutedEventHandler(this.ButtPridajVozidlo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

