﻿#pragma checksum "..\..\..\JanelaInimigos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A6A52EBA2470FE96C1BBAC8BD17811DD3730A5ED"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Space_Invaders_Game_WPF_MOO_ICT;
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


namespace Space_Invaders_Game_WPF_MOO_ICT {
    
    
    /// <summary>
    /// JanelaInimigos
    /// </summary>
    public partial class JanelaInimigos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\JanelaInimigos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button botaoIniciar;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\JanelaInimigos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNumero;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Space Invaders Game WPF MOO ICT;component/janelainimigos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\JanelaInimigos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.botaoIniciar = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\JanelaInimigos.xaml"
            this.botaoIniciar.Click += new System.Windows.RoutedEventHandler(this.IniciarJogo);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxNumero = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\JanelaInimigos.xaml"
            this.textBoxNumero.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.InputTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\JanelaInimigos.xaml"
            this.textBoxNumero.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.InputTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

