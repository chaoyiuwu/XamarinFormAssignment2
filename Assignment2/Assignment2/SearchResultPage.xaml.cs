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
    public partial class SearchResultPage : ContentPage {

        ObservableCollection<BookData> SearchResults;
        public SearchResultPage(List<BookData> searchResults) {
            InitializeComponent();
            SearchResults = new ObservableCollection<BookData>(searchResults);
            searchResultListView.ItemsSource = SearchResults;
        }

        public async void OnAddToList(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            BookData book = mi.CommandParameter as BookData;
            await Navigation.PushAsync(new BookListPage(book));
        }
    }
}