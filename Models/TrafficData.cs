namespace AnalyticsDashboard.Models
{
    public class TrafficData
    {
        public DateTime Date { get; set; }
        public int LocalIPs { get; set; }
        public int OtherIPs { get; set; }
        public int TotalClicks { get; set; }
        public int UniqueClicks { get; set; }
        public string SourceDomain { get; set; } = "";
        public string Country { get; set; } = "";
        public string Region { get; set; } = "";
        public string OperatingSystem { get; set; } = "";
        public string Device { get; set; } = "";
    }
}
