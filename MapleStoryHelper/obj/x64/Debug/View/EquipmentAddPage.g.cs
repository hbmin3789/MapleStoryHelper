﻿#pragma checksum "C:\Users\user\Documents\GitHub\MapleStoryHelper\MapleStoryHelper\View\EquipmentAddPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DA53A0B5EBFD1133857F549959A5C52A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MapleStoryHelper.View
{
    partial class EquipmentAddPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\EquipmentAddPage.xaml line 45
                {
                    this.ctrlEquipmentReinforce = (global::MapleStoryHelper.Control.EquipmentReinforceControl)(target);
                }
                break;
            case 3: // View\EquipmentAddPage.xaml line 20
                {
                    this.cbItems = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.cbItems).SelectionChanged += this.cbItems_SelectionChanged;
                }
                break;
            case 4: // View\EquipmentAddPage.xaml line 40
                {
                    this.ctrlStatusDisplay = (global::MapleStoryHelper.Control.StatusDisplayControl)(target);
                }
                break;
            case 5: // View\EquipmentAddPage.xaml line 35
                {
                    this.imgItem = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

