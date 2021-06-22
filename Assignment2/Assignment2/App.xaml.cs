﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Assignment2.Models;

namespace Assignment2 {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new LibraryAPIManager()));
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
