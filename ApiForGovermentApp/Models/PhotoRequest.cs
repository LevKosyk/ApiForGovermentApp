namespace ApiForGovermentApp.Models
{
    public class PhotoRequest
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Login { get; set; }
        public string Description { get; set; }
        public string Situation { get; set; }
    }
}
