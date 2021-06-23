using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Assignment2.Models;

namespace Assignment2 {
    public partial class MainPage : ContentPage {
        LibraryAPIManager Service;

        public List<List<Works>> _RecommendedLists;
        public List<List<Works>> RecommendedLists {
            get { return _RecommendedLists ?? new List<List<Works>>(); }
            set {
                if (_RecommendedLists != value) {
                    _RecommendedLists = value;
                    OnPropertyChanged(nameof(RecommendedLists));
                }
            }
        }
        public MainPage(LibraryAPIManager service) {  
            InitializeComponent();           

            Service = service;
            UpdateRecommendedLists();

            BindingContext = this;
        }

        private async void UpdateRecommendedLists() {
            var tempLists = new List<List<Works>>();
            //tempLists.Add(await Service.GetWorksBySubjectAsync("subjects/romance"));
            tempLists.Add(await Service.GetWorksBySubjectAsync("subjects/fantasy"));

            RecommendedLists = tempLists;
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e) {

        }

        public async void OnMore(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            Works works = mi.CommandParameter as Works;
            await Navigation.PushAsync(new BookDetailPage(Service, works));
        }

        private async void MyBookListsButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new BookListPage());
        }
    }
}
