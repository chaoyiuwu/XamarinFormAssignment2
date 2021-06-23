
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace Assignment2.Models {
    public class SubjectJson {
        public string key { get; set; }
        public string works_count { get; set; }
        public List<WorksJson> works { get; set; }
    }
    public class WorksAuthorJson {
        public string key { get; set; }
        public string name { get; set; }
    }
    public class WorksJson {
        [JsonProperty]
        public string key { get; set; }
        [JsonProperty]
        public string title { get; set; }
        [JsonProperty]
        public string cover_id { get; set; }
        [JsonProperty]
        public string cover_i { get; set; }
        [JsonProperty]
        public WorksAuthorJson[] authors { get; set; }
        [JsonProperty]
        public string author_name { get; set; }
    }

    public class SearchedWorksJson {
        public string key { get; set; }
        public string title { get; set; }

        public string cover_i { get; set; }

        public string[] author_name { get; set; }
    }

    public class SearchJson {
        public SearchedWorksJson[] docs { get; set; }
    }

    public class BookData : INotifyPropertyChanged {
        public string Key { get; set; }
        public string Title { get; set; }
        public string AuthorNameShort { get; set; }
        public string AuthorNameLong { get; set; }
        public string CoverUrl { get; set; }
        public string BookUrl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// DEFAULT
        /// </summary>
        public BookData() {
            Key = ""; Title = ""; AuthorNameShort = ""; AuthorNameLong = ""; CoverUrl = ""; BookUrl = "";
        }

        public BookData(WorksJson jsonObj, string coverUrl = "", string bookUrl = "") {
            if (jsonObj == null) {
                Key = ""; Title = ""; AuthorNameShort = ""; AuthorNameLong = "";
            }
            else {

                Key = jsonObj.key ?? "";
                Title = jsonObj.title ?? "";
                AuthorNameShort = jsonObj.authors != null ? (jsonObj.authors.Length > 1 ? jsonObj.authors[0].name + " et al." :
                                        (jsonObj.authors.FirstOrDefault() != null ? jsonObj.authors.First().name : "")) : "";
                AuthorNameLong = jsonObj.authors != null ? string.Join("\n", jsonObj.authors.Select(a => a.name)) : "";
            }
            CoverUrl = coverUrl;
            BookUrl = bookUrl;
        }

        public BookData(SearchedWorksJson jsonObj, string coverUrl = "", string bookUrl = "") {
            if (jsonObj == null) {
                Key = ""; Title = ""; AuthorNameShort = ""; AuthorNameLong = "";
            }
            else {

                Key = jsonObj.key ?? "";
                Title = jsonObj.title ?? "";
                AuthorNameShort = jsonObj.author_name != null ? (jsonObj.author_name.Length > 1 ? jsonObj.author_name[0] + " et al." :
                                        (jsonObj.author_name.FirstOrDefault() != null ? jsonObj.author_name.First() : "")) : "";
                AuthorNameLong = jsonObj.author_name != null ? string.Join("\n", jsonObj.author_name) : "";
            }
            CoverUrl = coverUrl;
            BookUrl = bookUrl;
        }

        public bool IsEmpty() {
            return Key == "" && Title == "" && AuthorNameLong == "" && AuthorNameShort == "" && CoverUrl == "" && BookUrl == "";
        }
    }
}
