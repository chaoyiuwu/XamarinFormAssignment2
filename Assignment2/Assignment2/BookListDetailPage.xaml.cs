using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Models;
using System.Collections.ObjectModel;

namespace Assignment2 {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListDetailPage : ContentPage {

        DBManager dbManager = new DBManager();
        BookList List;
        ObservableCollection<BookData> AddedWorks;

        public BookListDetailPage(BookList list) {
            InitializeComponent();
            List = list;
            AddedWorks = new ObservableCollection<BookData>(list.AddedBooks);
            bookListListView.ItemsSource = AddedWorks;
        }

        private void OnDelete(object sender, EventArgs e) {
            try {
                var mi = ((MenuItem)sender);
                var book = mi.CommandParameter as BookData;
                List.AddedBooks.Remove(book);
                 dbManager.UpdateList(List);
                DisplayAlert("Success", "Book deleted", "OK");
            }
            catch (Exception ex) {
                DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}