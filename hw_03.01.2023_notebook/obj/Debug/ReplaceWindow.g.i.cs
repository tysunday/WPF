﻿#pragma checksum "..\..\ReplaceWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F9007EB09EC35E1D639BBF37EA97A7080338FA696CC4DDFBEC60662CAD01144F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using hw_03._01._2023_notebook;


namespace hw_03._01._2023_notebook {
    
    
    /// <summary>
    /// ReplaceWindow
    /// </summary>
    public partial class ReplaceWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearch;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtReplace;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFindNext;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReplace;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReplaceAll;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ReplaceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkMatchCase;
        
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
            System.Uri resourceLocater = new System.Uri("/hw_03.01.2023_notebook;component/replacewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ReplaceWindow.xaml"
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
            
            #line 9 "..\..\ReplaceWindow.xaml"
            ((hw_03._01._2023_notebook.ReplaceWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 11 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.FindNextCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 11 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.FindNextCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 12 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ReplaceCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 12 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReplaceCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 13 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.ReplaceAllCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 13 "..\..\ReplaceWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ReplaceAllCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtReplace = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnFindNext = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnReplace = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnReplaceAll = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.chkMatchCase = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

