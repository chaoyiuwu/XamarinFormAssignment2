using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Models;
using System.Collections.ObjectModel;
using Assignment2.Models;

namespace Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListPage : ContentPage
    {
        DBManager dbManager = new DBManager();
        ObservableCollection<BookList> AllBookLists;
        Works CurrentWork;

        protected async override void OnAppearing() {
            //AllBookLists = await dbManager.CreateTable();
            //bookListsListView.ItemsSource = AllBookLists;
            base.OnAppearing();

        }


        public BookListPage()  {
            InitializeComponent();
        }

    }
}