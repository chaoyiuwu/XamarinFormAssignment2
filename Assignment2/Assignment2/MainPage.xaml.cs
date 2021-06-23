using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment2.Models;
using Xamarin.Essentials;

namespace Assignment2 {
    public partial class MainPage : ContentPage {
        LibraryAPIManager Service = new LibraryAPIManager();

        public List<List<BookData>> _RecommendedLists;
        public List<List<BookData>> RecommendedLists {
            get { return _RecommendedLists ?? new List<List<BookData>>(); }
            set {
                if (_RecommendedLists != value) {
                    _RecommendedLists = value;
                    OnPropertyChanged(nameof(RecommendedLists));
                }
            }
        }
        protected async override void OnAppearing() {
            var tempLists = new List<List<BookData>>();
            tempLists.Add(await Service.GetWorksBySubjectAsync("subjects/romance"));
            tempLists.Add(await Service.GetWorksBySubjectAsync("subjects/fantasy"));

            RecommendedLists = tempLists;
            WorksCarouselView.ItemsSource = RecommendedLists;
            base.OnAppearing();
        }
        public MainPage() {  
            InitializeComponent();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e) {
            var searchResults = await Service.GetSearchResultAsync(SearchBar.Text);
            if (searchResults.Count == 0) {
                await DisplayAlert("No Search Results Found", "", "OK");
            }
            else {
                await Navigation.PushAsync(new SearchResultPage(searchResults));
            }
        }

        private async void MyBookListsButton_Clicked(object sender, EventArgs e) {
            try {
                await Navigation.PushAsync(new BookListPage());
            }
            catch(Exception ex) {
                await DisplayAlert("Opening page failed", ex.Message, "OK");
            }
        }

        public async void OnAddToList(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            BookData book = mi.CommandParameter as BookData;
            await Navigation.PushAsync(new BookListPage(book));
        }

        private async void OnMore(object sender, EventArgs e) {
            try {
                var mi = ((MenuItem)sender);
                BookData book = mi.CommandParameter as BookData;
                await Browser.OpenAsync(book.BookUrl, BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex) {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
