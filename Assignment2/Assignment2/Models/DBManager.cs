using SQLite;
using Xamarin.Forms;
using Assignment2.Persistence;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

namespace Assignment2.Models {
    class DBManager {
        private SQLiteAsyncConnection _connection;

        public DBManager() {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<ObservableCollection<BookList>> CreateTable() {
            await _connection.CreateTableAsync<BookList>();
            var booklists = await ReadOperations.GetAllWithChildrenAsync<BookList>(_connection);
            var _booklists = new ObservableCollection<BookList>(booklists);
            return _booklists;
        }

        public async void InsertNewList(BookList list) {
            await WriteOperations.InsertWithChildrenAsync(_connection, list);
        }

        public async void UpdateList(BookList list) {
            await WriteOperations.UpdateWithChildrenAsync(_connection, list);
        }

        public async void DeleteList(BookList list) {
            await WriteOperations.DeleteAsync(_connection, list, false);
        }
    }
}
