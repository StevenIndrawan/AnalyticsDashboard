using Microsoft.AspNetCore.Mvc;

namespace AnalyticsDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrafficController : ControllerBase
    {
        private readonly Random _rnd = new();

        [HttpGet]
        public IActionResult GetTraffic()
        {
            var dates = Enumerable.Range(0, 14)
                .Select(i => DateTime.Now.Date.AddDays(-i))
                .Reverse()
                .ToList();

            var summary = new
            {
                Labels = dates.Select(d => d.ToString("yyyy-MM-dd")).ToList(),
                LocalIPs = dates.Select(_ => _rnd.Next(50, 200)).ToList(),
                OtherIPs = dates.Select(_ => _rnd.Next(20, 100)).ToList(),
                TotalClicks = dates.Select(_ => _rnd.Next(300, 600)).ToList(),
                UniqueClicks = dates.Select(_ => _rnd.Next(100, 400)).ToList()
            };

            var details = new List<object>
            {
                new { SourceDomain = "google", LocalIPs = _rnd.Next(5000,10000), OtherIPs = _rnd.Next(3000,8000), TotalClicks = _rnd.Next(20000,30000), UniqueClicks = _rnd.Next(10000,20000) },
                new { SourceDomain = "bing", LocalIPs = _rnd.Next(2000,5000), OtherIPs = _rnd.Next(1000,3000), TotalClicks = _rnd.Next(5000,10000), UniqueClicks = _rnd.Next(2500,6000) },
                new { SourceDomain = "direct", LocalIPs = _rnd.Next(1000,3000), OtherIPs = _rnd.Next(500,2000), TotalClicks = _rnd.Next(3000,7000), UniqueClicks = _rnd.Next(1500,4000) },
                new { SourceDomain = "yahoo", LocalIPs = _rnd.Next(500,2000), OtherIPs = _rnd.Next(300,1000), TotalClicks = _rnd.Next(2000,5000), UniqueClicks = _rnd.Next(1000,2000) }
            };

            return Ok(new { Summary = summary, Details = details });
        }
    }
}
