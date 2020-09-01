using System.Collections.Generic;

namespace authors.models
{

    public class Response {
        public string page { get; set; }
        public int per_page { get; set; }  
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Author> data { get; set; }
    }
}