﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Models;
using System.Collections.ObjectModel;

namespace Assignment2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookListPage : ContentPage
    {
        DBManager dbManager = new DBManager();
        ObservableCollection<BookList> AllBookLists;
        Works CurrentWork;

        protected async override void OnAppearing() {
            AllBookLists = await dbManager.CreateTable();
            bookListsListView.ItemsSource = AllBookLists;
            base.OnAppearing();

        }


        public BookListPage()  {
            InitializeComponent();
        }

        private void AddNewListButton_Clicked(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(NewListNameEntry.Text)) {
                DisplayAlert("Error", "Please enter a name for the list.", "OK");
            }else {
                try {
                    var newList = new BookList();
                    newList.AddedWorks = new List<Works>();
                    newList.Name = NewListNameEntry.Text;
                    dbManager.InsertNewList(newList);
                    DisplayAlert("Success", "List is added.", "OK");
                    NewListNameEntry.Text = "";
                }
                catch (Exception ex) {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private void OnDelete(object sender, EventArgs e) {
            try {
                var mi = ((MenuItem)sender);
                var list = mi.CommandParameter as BookList;
                dbManager.DeleteList(list);
                DisplayAlert("Success", "List is deleted.", "OK");
            }
            catch (Exception ex) {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void OnDeleteAddedBook(object sender, EventArgs e) {

        }
    }
}