namespace AnalyticsDashboard.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public string Referrer { get; set; } = "";
        public string UserAgent { get; set; } = "";
        public string Language { get; set; } = "";
        public string Screen { get; set; } = "";
        public string IpAddress { get; set; } = "";
        public DateTime Timestamp { get; set; }
    }
}
