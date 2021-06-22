using System;
using Assignment2.Persistence;
using Xamarin.Forms;
using SQLite;
using System.IO;
using Assignment2.iOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Assignment2.iOS {
    public class SQLiteDb : ISQLiteDb {
        public SQLiteAsyncConnection GetConnection() {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}