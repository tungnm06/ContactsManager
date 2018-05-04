using ManageContacts.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ManageContacts
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactDetails : Page
    {
        Contacts ct = new Contacts();
        StorageFolder myStorageFolder = Windows.Storage.KnownFolders.PicturesLibrary;
        String nameold;
        public ContactDetails()
        {
            this.InitializeComponent();

            cbbox2.Items.Add("Gia Đình");
            cbbox2.Items.Add("Công Ty");
            cbbox2.Items.Add("Bạn Bè");

        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ct = e.Parameter as Contacts;
            nameold = ct.Name;
            //  id = e.Parameter as String;
            txtName.Text = ct.Name;
            txtPhone.Text = ct.Phone.ToString();
            cbbox2.SelectedItem = ct.Group;
            txtPhone.IsEnabled = false;
            txtName.IsEnabled = false;
            cbbox2.IsEnabled = false;
            btnOk.IsEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtPhone.IsEnabled = true;
            txtName.IsEnabled = true;
            cbbox2.IsEnabled = true;
            btnOk.IsEnabled = true;
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            StorageFile myDocumentFile = await myStorageFolder.GetFileAsync("Contacts.txt");
            string jsonstring = await FileIO.ReadTextAsync(myDocumentFile);


            List<Contacts> myList = JsonConvert.DeserializeObject<List<Contacts>>(jsonstring);
            if (myList == null)
                myList = new List<Contacts>();
           foreach(Contacts ct in myList)
            {
                if(ct.Name == nameold)
                {
                    try
                    {
                        ct.Name = txtName.Text;

                        ct.Phone = Convert.ToInt32(txtPhone.Text);
                        ct.Group = cbbox2.SelectedItem.ToString();
                        
                    }
                    catch {
                        MessageDialog message1 = new MessageDialog("Số Phone erro !");
                        message1.ShowAsync();
                    }
                }
            }
            string data = JsonConvert.SerializeObject(myList);
            FileIO.WriteTextAsync(myDocumentFile, data);
            txtPhone.IsEnabled = false;
            txtName.IsEnabled = false;
            cbbox2.IsEnabled = false;
            btnOk.IsEnabled = false;
            MessageDialog message = new MessageDialog("Edit thành công  !");
            message.ShowAsync();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            StorageFile myDocumentFile = await myStorageFolder.GetFileAsync("Contacts.txt");
            string jsonstring = await FileIO.ReadTextAsync(myDocumentFile);


            List<Contacts> myList = JsonConvert.DeserializeObject<List<Contacts>>(jsonstring);
            List<Contacts> myList2 = new List<Contacts>();
            if (myList == null)
                myList = new List<Contacts>();
            foreach (Contacts ct2 in myList)
            {
                if(ct.Name != ct2.Name)
                {
                    myList2.Add(ct2);

                }
            }

                
            string data = JsonConvert.SerializeObject(myList2);
            FileIO.WriteTextAsync(myDocumentFile, data);
            MessageDialog message2 = new MessageDialog("Delete thành công   !");
            message2.ShowAsync();
            Frame.Navigate(typeof(SearchContact),new object());

        }

        private void btnHomePage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SearchContact), new object());

        }

        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewContactPage), new object());

        }
    }
}
