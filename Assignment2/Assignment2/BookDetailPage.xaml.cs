using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Models;

namespace Assignment2 {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage {
        LibraryAPIManager Service;
        private BookData _CurrentBook;
        public BookData CurrentBook {
            get { return _CurrentBook ?? new BookData(null); }
            set {
                if (_CurrentBook != value) {
                    _CurrentBook = value;
                    OnPropertyChanged(nameof(CurrentBook));
                }
            }
        }

        public BookDetailPage(LibraryAPIManager service, BookData work) {
            InitializeComponent();
            Service = service;
            CurrentBook = work;
            BindingContext = this;
        }

        private async void SeeMoreButton_Clicked(object sender, EventArgs e) {
            try {
                await Browser.OpenAsync(CurrentBook.BookUrl, BrowserLaunchMode.SystemPreferred);
            }
            catch(Exception ex) {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void AddToListButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new BookListPage(CurrentBook));
        }
    }
}