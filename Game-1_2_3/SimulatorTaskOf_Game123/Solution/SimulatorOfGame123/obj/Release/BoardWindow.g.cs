﻿#pragma checksum "..\..\BoardWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2478A58C4249DBAAAE5E318E915C9AE9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
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
using WpfApplication2;


namespace WpfApplication2 {
    
    
    /// <summary>
    /// BoardWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class BoardWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rightGrid;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.ScoreControl secondAlgorithmScores;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.StartButton secondAlgorithmNextButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid boardGrid;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid topMiddleGrid;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.StartButton startButton;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid leftGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock title;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.ScoreControl firstAlgorithmScores;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\BoardWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.StartButton firstAlgorithmNextButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication2;component/boardwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BoardWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 2 "..\..\BoardWindow.xaml"
            ((WpfApplication2.BoardWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.boardGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 2 "..\..\BoardWindow.xaml"
            ((WpfApplication2.BoardWindow)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.boardGrid_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 2 "..\..\BoardWindow.xaml"
            ((WpfApplication2.BoardWindow)(target)).MouseMove += new System.Windows.Input.MouseEventHandler(this.boardGrid_MouseMove);
            
            #line default
            #line hidden
            
            #line 2 "..\..\BoardWindow.xaml"
            ((WpfApplication2.BoardWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rightGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.title1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.secondAlgorithmScores = ((WpfApplication2.ScoreControl)(target));
            return;
            case 5:
            this.secondAlgorithmNextButton = ((WpfApplication2.StartButton)(target));
            return;
            case 6:
            this.boardGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 42 "..\..\BoardWindow.xaml"
            this.boardGrid.Loaded += new System.Windows.RoutedEventHandler(this.boardGrid_Loaded);
            
            #line default
            #line hidden
            return;
            case 7:
            this.topMiddleGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            this.startButton = ((WpfApplication2.StartButton)(target));
            return;
            case 9:
            this.leftGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.firstAlgorithmScores = ((WpfApplication2.ScoreControl)(target));
            return;
            case 12:
            this.firstAlgorithmNextButton = ((WpfApplication2.StartButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
