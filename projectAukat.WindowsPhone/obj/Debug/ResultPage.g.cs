﻿

#pragma checksum "C:\Users\Akshay\documents\visual studio 2013\Projects\projectAukat\projectAukat\projectAukat.WindowsPhone\ResultPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "08518095734D3761897BACA90A52458F"
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
    partial class ResultPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 81 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ListMenuItems_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 24 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.DrawerIcon_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


