using AnalyticsDashboard.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnalyticsDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrafficController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTraffic()
        {
            var logs = await _context.TrafficLogs
                .OrderByDescending(t => t.Timestamp)
                .Take(10)
                .ToListAsync();

            return Ok(new
            {
                Summary = new
                {
                    Labels = logs.Select(x => x.Timestamp.ToString("HH:mm")).Reverse().ToList(),
                    TotalClicks = logs.Select(x => x.TotalClicks).Reverse().ToList(),
                    UniqueClicks = logs.Select(x => x.UniqueClicks).Reverse().ToList(),
                    LocalIPs = logs.Select(x => x.LocalIPs).ToList(),
                    OtherIPs = logs.Select(x => x.OtherIPs).ToList(),
                },
                Details = logs.Select(x => new {
                    x.SourceDomain,
                    x.LocalIPs,
                    x.OtherIPs,
                    x.TotalClicks,
                    x.UniqueClicks
                }).ToList()
            });
        }
    }
}
