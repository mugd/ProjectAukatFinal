﻿

#pragma checksum "C:\Users\Akshay\Documents\Visual Studio 2013\Projects\projectAukat\projectAukat\projectAukat.WindowsPhone\Compare.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E235FE08B9B35CF9457F3EABB3A3BB67"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectAukat
{
    partial class Compare : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 133 "..\..\Compare.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ListMenuItems_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 51 "..\..\Compare.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.box_LostFocus;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 100 "..\..\Compare.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).GotFocus += this.PivotItem_GotFocus;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 27 "..\..\Compare.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.DrawerIcon_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 29 "..\..\Compare.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.Help_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


