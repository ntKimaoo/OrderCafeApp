﻿#pragma checksum "..\..\..\w_dashboard.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8D00AFF84619F8D2CFA8A0529B0EFDB5ED65B557"
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
    /// w_dashboard
    /// </summary>
    public partial class w_dashboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\w_dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOrderMana;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\w_dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStaffMana;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\w_dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnItemMana;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\w_dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBanMana;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\w_dashboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectPrn;component/w_dashboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\w_dashboard.xaml"
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
            this.btnOrderMana = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\w_dashboard.xaml"
            this.btnOrderMana.Click += new System.Windows.RoutedEventHandler(this.btnOrderMana_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnStaffMana = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\w_dashboard.xaml"
            this.btnStaffMana.Click += new System.Windows.RoutedEventHandler(this.btnStaffMana_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnItemMana = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\w_dashboard.xaml"
            this.btnItemMana.Click += new System.Windows.RoutedEventHandler(this.btnItemMana_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBanMana = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\w_dashboard.xaml"
            this.btnBanMana.Click += new System.Windows.RoutedEventHandler(this.btnBanMana_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\w_dashboard.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

