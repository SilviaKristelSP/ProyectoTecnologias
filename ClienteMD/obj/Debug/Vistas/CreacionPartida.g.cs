﻿#pragma checksum "..\..\..\Vistas\CreacionPartida.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1A40B44F7761601605E5C4E8D69C37682F100E795103267E0771878243167B36"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
    /// CreacionPartida
    /// </summary>
    public partial class CreacionPartida : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Vistas\CreacionPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Categoria;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Vistas\CreacionPartida.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Palabra;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteMD;component/vistas/creacionpartida.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vistas\CreacionPartida.xaml"
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
            
            #line 13 "..\..\..\Vistas\CreacionPartida.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.moverVentana);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Categoria = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\Vistas\CreacionPartida.xaml"
            this.Categoria.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Categoria_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Palabra = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 36 "..\..\..\Vistas\CreacionPartida.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickRegresar);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 57 "..\..\..\Vistas\CreacionPartida.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.clickCrearPartida);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

