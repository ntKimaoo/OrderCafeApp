﻿#pragma checksum "..\..\..\w_goiMon.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9687334BB017D510CFA54346E7CFA252D6CE7168"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectPrn;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ProjectPrn {
    
    
    /// <summary>
    /// w_goiMon
    /// </summary>
    public partial class w_goiMon : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel ProductWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvChoseItem;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOrder;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnResetOrder;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblSoBan;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblNhanvienid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\w_goiMon.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblBanid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectPrn;component/w_goimon.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\w_goiMon.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ProductWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 2:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\w_goiMon.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lvChoseItem = ((System.Windows.Controls.ListView)(target));
            
            #line 26 "..\..\..\w_goiMon.xaml"
            this.lvChoseItem.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvChoseItem_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnOrder = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\w_goiMon.xaml"
            this.btnOrder.Click += new System.Windows.RoutedEventHandler(this.btnOrder_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnResetOrder = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\w_goiMon.xaml"
            this.btnResetOrder.Click += new System.Windows.RoutedEventHandler(this.btnResetOrder_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tblSoBan = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.tblNhanvienid = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.tblBanid = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

