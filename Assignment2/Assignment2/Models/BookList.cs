using SQLite;
using System.Collections.Generic;
using System.ComponentModel;

using SQLiteNetExtensions.Attributes;

namespace Assignment2.Models {
    public class BookList : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private string _Name;
        public string Name {
            get { return _Name; }
            set {
                if (value == _Name)
                    return;
                _Name = value;
                if (PropertyChanged != null) {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }

        }

        private List<BookData> _AddedBooks;
        [TextBlob("AddedBooksBlobbed")]
        public List<BookData> AddedBooks {
            get { return _AddedBooks; }
            set {
                if (value == _AddedBooks)
                    return;
                _AddedBooks = value;
                if (PropertyChanged != null) {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(AddedBooks)));
                }
            }
        }
        public string AddedBooksBlobbed { get; set; }

        public int BooksCount => AddedBooks != null ? AddedBooks.Count : 0;
    }
}
