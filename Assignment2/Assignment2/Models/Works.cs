
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

    public class Works : INotifyPropertyChanged {
        public string Key { get; }
        public string Title { get; }
        public string AuthorNameShort { get; }
        public string AuthorNameLong { get; }
        public string CoverUrl { get; }
        public string BookUrl { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Works(WorksJson jsonObj, string coverUrl = "", string bookUrl = "") {
            if (jsonObj == null) {
                Key = ""; Title = ""; AuthorNameShort = ""; AuthorNameLong = "";
            }
            else {

                Key = jsonObj.key;
                Title = jsonObj.title;
                AuthorNameShort = jsonObj.authors.Length > 1 ? jsonObj.authors[0].name + " et al." :
                                        (jsonObj.authors.FirstOrDefault() != null ? jsonObj.authors.First().name : "");
                AuthorNameLong = string.Join("\n", jsonObj.authors.Select(a => a.name));
            }
            CoverUrl = coverUrl;
            BookUrl = bookUrl;
        }
    }
}
