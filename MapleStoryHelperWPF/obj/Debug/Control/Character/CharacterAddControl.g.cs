﻿#pragma checksum "..\..\..\..\Control\Character\CharacterAddControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C47362B9663CF776D9771C45B2008AC5A272D2C3682A37FF0EB003299E1F11F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MapleStoryHelperWPF.Control;
using MapleStoryHelperWPF.Control.Character.CharacterAdd;
using MapleStoryHelperWPF.Converter;
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


namespace MapleStoryHelperWPF.Control {
    
    
    /// <summary>
    /// CharacterAddControl
    /// </summary>
    public partial class CharacterAddControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditJob;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnItemSetting;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MapleStoryHelperWPF.Control.Character.CharacterAdd.CharacterItemControl ctrlCharacterItem;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MapleStoryHelperWPF.Control.Character.CharacterAdd.CharacterJobControl ctrlCharacterJob;
        
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
            System.Uri resourceLocater = new System.Uri("/MapleStoryHelperWPF;component/control/character/characteraddcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.btnEditJob = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
            this.btnEditJob.Click += new System.Windows.RoutedEventHandler(this.btnEditJob_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnItemSetting = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Control\Character\CharacterAddControl.xaml"
            this.btnItemSetting.Click += new System.Windows.RoutedEventHandler(this.btnItemSetting_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ctrlCharacterItem = ((MapleStoryHelperWPF.Control.Character.CharacterAdd.CharacterItemControl)(target));
            return;
            case 4:
            this.ctrlCharacterJob = ((MapleStoryHelperWPF.Control.Character.CharacterAdd.CharacterJobControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
