﻿#pragma checksum "..\..\..\Windows\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B37B5C34A5533E13BD135CF8F4321D847321B45E"
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
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ButtZobrazVsetkyVozidla;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ButtZobrazAktivneVozidla;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ButtZobrazNeaktivneVozidla;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ButtPridajVozidlo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame HlavnyFrame;
        
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
            System.Uri resourceLocater = new System.Uri("/Bakalarka;component/windows/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\MainWindow.xaml"
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
            
            #line 8 "..\..\..\Windows\MainWindow.xaml"
            ((Bakalarka.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ButtZobrazVsetkyVozidla = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\Windows\MainWindow.xaml"
            this.ButtZobrazVsetkyVozidla.Click += new System.Windows.RoutedEventHandler(this.ButtZobrazVsetkyVozidla_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ButtZobrazAktivneVozidla = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\Windows\MainWindow.xaml"
            this.ButtZobrazAktivneVozidla.Click += new System.Windows.RoutedEventHandler(this.ButtZobrazAktivneVozidla_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtZobrazNeaktivneVozidla = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\Windows\MainWindow.xaml"
            this.ButtZobrazNeaktivneVozidla.Click += new System.Windows.RoutedEventHandler(this.ButtZobrazNeaktivneVozidla_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtPridajVozidlo = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\Windows\MainWindow.xaml"
            this.ButtPridajVozidlo.Click += new System.Windows.RoutedEventHandler(this.ButtPridajVozidlo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HlavnyFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

