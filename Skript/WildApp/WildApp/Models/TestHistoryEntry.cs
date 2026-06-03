using System;

namespace WildApp.Models
{
    public class TestHistoryEntry
    {
        public int Id { get; set; }
        public string TestType { get; set; } = "";
        public string Summary { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
