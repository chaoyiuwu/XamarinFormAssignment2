using System;
using Assignment2.Persistence;
using SQLite;
using Assignment2.Droid;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]
namespace Assignment2.Droid {
	public class SQLiteDb : ISQLiteDb {
		public SQLiteAsyncConnection GetConnection() {
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MyBookLists.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}