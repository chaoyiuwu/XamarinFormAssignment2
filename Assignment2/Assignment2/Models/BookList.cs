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

        private List<Works> _AddedWorks;
        [TextBlob("AddedWorksBlobbed")]
        public List<Works> AddedWorks {
            get { return _AddedWorks; }
            set {
                if (value == _AddedWorks)
                    return;
                _AddedWorks = value;
                if (PropertyChanged != null) {

                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(AddedWorks)));
                }
            }
        }
        public string AddedWorksBlobbed { get; set; }
    }
}
