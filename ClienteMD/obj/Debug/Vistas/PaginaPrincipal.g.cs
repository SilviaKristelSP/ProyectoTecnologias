﻿#pragma checksum "..\..\..\Vistas\PaginaPrincipal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7BC9ACC157F268087549BECBDA8AE4D83849F110EDA4271C9AC840E10FBB3569"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteMD.Vistas;
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


namespace ClienteMD.Vistas {
    
    
    /// <summary>
    /// PaginaPrincipal
    /// </summary>
    public partial class PaginaPrincipal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 98 "..\..\..\Vistas\PaginaPrincipal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid partidasDisponibles;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteMD;component/vistas/paginaprincipal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vistas\PaginaPrincipal.xaml"
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
            
            #line 14 "..\..\..\Vistas\PaginaPrincipal.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.moverVentana);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 27 "..\..\..\Vistas\PaginaPrincipal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickCerrarSesion);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 49 "..\..\..\Vistas\PaginaPrincipal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickPerfil);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 73 "..\..\..\Vistas\PaginaPrincipal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickEntrarPartida);
            
            #line default
            #line hidden
            return;
            case 5:
            this.partidasDisponibles = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 110 "..\..\..\Vistas\PaginaPrincipal.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickCrearPartida);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

