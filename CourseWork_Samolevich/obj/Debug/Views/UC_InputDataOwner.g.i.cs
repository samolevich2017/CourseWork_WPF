#pragma checksum "..\..\..\Views\UC_InputDataOwner.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1A87787B7B6AA40F3550346329F1FD13ABE26FCA843359086738F30F1F55886C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseWork_Samolevich;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace CourseWork_Samolevich.Views {
    
    
    /// <summary>
    /// UC_InputDataOwner
    /// </summary>
    public partial class UC_InputDataOwner : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbOwner;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameTextBoxOwn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBoxOwn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PatronymicTextBoxOwn;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegistrationTextBoxOwn;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDateOfBirthdayOwn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccept;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\UC_InputDataOwner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseWork_Samolevich;component/views/uc_inputdataowner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UC_InputDataOwner.xaml"
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
            this.txbOwner = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.SurnameTextBoxOwn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NameTextBoxOwn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.PatronymicTextBoxOwn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.RegistrationTextBoxOwn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dpDateOfBirthdayOwn = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btnAccept = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\Views\UC_InputDataOwner.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

