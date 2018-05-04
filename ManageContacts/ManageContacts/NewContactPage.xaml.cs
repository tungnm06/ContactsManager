using ManageContacts.Model;
using System;
using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ManageContacts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewContactPage : Page
    {
        StorageFile sf = null;
        StorageFolder myStorageFolder = Windows.Storage.KnownFolders.PicturesLibrary;
      
        public NewContactPage()
        {
            

            this.InitializeComponent();
            setComBo();
            cbbox.SelectedItem = "Bạn Bè";

        }
        private void setComBo()
        {
            cbbox.Items.Add("Gia Đình");
            cbbox.Items.Add("Công Ty");
            cbbox.Items.Add("Bạn Bè");

        }
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Contacts contact = new Contacts();
            int a = 0;
            contact.Name = tbName.Text;
            try
            {


                contact.Phone = Convert.ToInt32(tbPhone.Text);
                contact.Group = cbbox.SelectedItem.ToString();
                StorageFile myDocumentFile = await myStorageFolder.GetFileAsync("Contacts.txt");
                string jsonstring = await FileIO.ReadTextAsync(myDocumentFile);


                List<Contacts> myList = JsonConvert.DeserializeObject<List<Contacts>>(jsonstring);
                if (myList == null)
                    myList = new List<Contacts>();
                foreach (Contacts ct in myList)
                {
                    if (ct.Name == contact.Name)
                    {
                        a = 1;
                    }

                }
                if (a == 1)
                {
                    MessageDialog message = new MessageDialog("Tên Liên Hệ Đã Có Vui Lòng Đặt Tên Khác !");
                    message.ShowAsync();
                }
                else
                {
                    myList.Add(contact);
                    string data = JsonConvert.SerializeObject(myList);
                    FileIO.WriteTextAsync(myDocumentFile, data);
                    MessageDialog message = new MessageDialog("Đăng ký thành công  !");
                    message.ShowAsync();
                }

            }
            catch
            {
                MessageDialog message = new MessageDialog("Số Phone erro !");
                message.ShowAsync();
            }
            



        }

        private void btnReSet_Click(object sender, RoutedEventArgs e)
        {
            tbPhone.Text = "";
            tbName.Text = "";
        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchContact), new object());

        }
    }
}
