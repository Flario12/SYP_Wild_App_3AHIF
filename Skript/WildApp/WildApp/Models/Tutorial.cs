namespace WildApp.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        public string Category { get; set; } = "";
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Steps { get; set; } = "";
        public string VideoUrl { get; set; } = "";
    }
}
