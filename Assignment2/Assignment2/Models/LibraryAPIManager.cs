using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment2.Models {
    public class LibraryAPIManager {

        public const string LibraryUrl = "https://openlibrary.org/";
        public const string dotJson = ".json";
        HttpClient Client;

        public LibraryAPIManager() {
            Client = new HttpClient();
        }

        public async Task<List<BookData>> GetWorksBySubjectAsync(string subject) {
            Uri uri = new Uri(string.Format(LibraryUrl + "{0}" + dotJson, subject));
            var worksJson = new List<WorksJson>();
            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                string content = await response.Content.ReadAsStringAsync();
                worksJson = JsonConvert.DeserializeObject<SubjectJson>(content).works.Take(10).ToList();
            }

            var works = new List<BookData>();
            foreach (var w in worksJson) {
                works.Add(new BookData(w, GetCoverLink(w.cover_id, "L"), string.Format(LibraryUrl + "{0}", w.key)));
            }

            return works;
        }

        

        public string GetCoverLink(string coverId, string size) {
            return string.Format("https://covers.openlibrary.org/b/id/{0}-{1}.jpg", coverId, size);
        }
    }
}
