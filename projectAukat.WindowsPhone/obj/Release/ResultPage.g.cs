﻿

#pragma checksum "C:\Users\Akshay\Documents\Visual Studio 2013\Projects\projectAukat\projectAukat\projectAukat.WindowsPhone\ResultPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B68D1D9A5F1B0AE703370DB93FF01D64"
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
                #line 91 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ListMenuItems_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 34 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.DrawerIcon_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 25 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 26 "..\..\ResultPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Button_Click_1;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


