﻿#pragma checksum "C:\Users\admin\source\repos\ManageContacts\ManageContacts\ContactDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A8C84A84B816AB02E45963D3C4ACA6A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageContacts
{
    partial class ContactDetails : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.btnHomePage = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 12 "..\..\..\ContactDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnHomePage).Click += this.btnHomePage_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.btnNewContact = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 13 "..\..\..\ContactDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btnNewContact).Click += this.btnNewContact_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.txtName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.txtPhone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.btnEdit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\ContactDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEdit).Click += this.btnEdit_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.btnOk = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 26 "..\..\..\ContactDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnOk).Click += this.btnOk_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.cbbox2 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 8:
                {
                    this.btnDelete = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\ContactDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnDelete).Click += this.btnDelete_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
