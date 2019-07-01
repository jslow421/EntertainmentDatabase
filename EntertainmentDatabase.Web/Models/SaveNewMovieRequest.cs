using System.Collections.Generic;

namespace EntertainmentDatabase.Web.Models
{
    public class SaveNewMovieRequest
    {
        public string Upc { get; set; }
        public string Ean { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}