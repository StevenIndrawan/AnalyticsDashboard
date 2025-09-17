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
            var dates = Enumerable.Range(0, 7)
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
                new { SourceDomain = "VIN", LocalIPs = _rnd.Next(80000,120000), OtherIPs = _rnd.Next(30000,50000), TotalClicks = _rnd.Next(100000,150000), UniqueClicks = _rnd.Next(50000,80000) },
                new { SourceDomain = "LO", LocalIPs = _rnd.Next(2000,6000), OtherIPs = _rnd.Next(1500,4000), TotalClicks = _rnd.Next(4000,8000), UniqueClicks = _rnd.Next(2500,5000) },
                new { SourceDomain = "SHD", LocalIPs = _rnd.Next(15000,25000), OtherIPs = _rnd.Next(10000,15000), TotalClicks = _rnd.Next(30000,40000), UniqueClicks = _rnd.Next(20000,30000) },
                new { SourceDomain = "UNITVIDEOS", LocalIPs = _rnd.Next(2500,4000), OtherIPs = _rnd.Next(700,1500), TotalClicks = _rnd.Next(4000,6000), UniqueClicks = _rnd.Next(2000,4000) }
            };

            return Ok(new { Summary = summary, Details = details });
        }
    }
}
