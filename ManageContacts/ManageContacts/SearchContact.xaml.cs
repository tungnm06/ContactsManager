using ManageContacts.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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
    public sealed partial class SearchContact : Page
    {
        StorageFolder myStorageFolder = Windows.Storage.KnownFolders.PicturesLibrary;

        public SearchContact()
        {
            this.InitializeComponent();
            getContacts();
        }
        public async void getContacts()
        {
            StorageFile myDocumentFile = await myStorageFolder.GetFileAsync("Contacts.txt");
            string jsonstring = await FileIO.ReadTextAsync(myDocumentFile);


            List<Contacts> myList = JsonConvert.DeserializeObject<List<Contacts>>(jsonstring);
            if (myList == null)
                myList = new List<Contacts>();
            //foreach(Contacts ct in myList)
            // {
            //     string namephone;
            //     namephone = ct.Name + "-" +ct.Phone;
            //     ListViewItem lv = new ListViewItem();
            //     lv.Content = namephone;
            //     lstFile.Items.Add(lv);
            // }
            lstFile.ItemsSource = myList;
        }
        private void lstFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contacts contact = new Contacts();
            contact = lstFile.SelectedItem as Contacts;
            Frame.Navigate(typeof(ContactDetails), contact);

        }

        private void lstFile2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contacts contact2 = new Contacts();
            contact2 = lstFile2.SelectedItem as Contacts;
            Frame.Navigate(typeof(ContactDetails), contact2);
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            StorageFile myDocumentFile = await myStorageFolder.GetFileAsync("Contacts.txt");
            if(myDocumentFile == null)
            {
                myDocumentFile = await myStorageFolder.CreateFileAsync("Contacts.txt");
            }
            string jsonstring = await FileIO.ReadTextAsync(myDocumentFile);


            List<Contacts> myList = JsonConvert.DeserializeObject<List<Contacts>>(jsonstring);
            if (myList == null)
                myList = new List<Contacts>();
            List<Contacts> list = new List<Contacts>();
            int a = 0;
            foreach (Contacts ct in myList)
            {
                ct.Name.ToUpper();
                   
                if (convertToUnSign3(ct.Name) == convertToUnSign3(txtSearch.Text))
                {
                    list.Add(ct);
                     a = 1;
                }
            }
            if(a == 0)
            {
                MessageDialog message = new MessageDialog("Không tìm thấy");
                message.ShowAsync();
            }
            else
            {
                lstFile2.ItemsSource = list;

            }
        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToUpper();
        }


        private void btnNewContact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewContactPage), new object());
         
        }
        
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
             Frame.Navigate(typeof(SearchContact), new object());
        }
    }
}
