namespace ApiForGovermentApp.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string longetude { get; set; }
        public string latitude { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Situation { get; set; }
        public User User { get; set; }
    }
}
