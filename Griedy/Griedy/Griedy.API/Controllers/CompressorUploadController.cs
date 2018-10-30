using Griedy.API.Hubs;
using Griedy.Lib.DataContext;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Web.Http;

namespace Griedy.API.Controllers
{
    public class CompressorUploadController : ApiController
    {
        private readonly GriedyDataContext _context;

        public CompressorUploadController()
        {
            _context = new GriedyDataContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(new CompressorResult[] {
                new CompressorResult { CompressorId = "comp0", CompressorName = "name0", RiskRanking = 1 },
                new CompressorResult { CompressorId = "comp1", CompressorName = "name1", RiskRanking = 1 },
                new CompressorResult { CompressorId = "comp2", CompressorName = "name2", RiskRanking = 1 },
                new CompressorResult { CompressorId = "comp3", CompressorName = "name3", RiskRanking = 2 },
                new CompressorResult { CompressorId = "comp4", CompressorName = "name4", RiskRanking = 2 },
                new CompressorResult { CompressorId = "comp5", CompressorName = "name5", RiskRanking = 2 },
                new CompressorResult { CompressorId = "comp6", CompressorName = "name6", RiskRanking = 3 },
                new CompressorResult { CompressorId = "comp7", CompressorName = "name7", RiskRanking = 3 },
                new CompressorResult { CompressorId = "comp8", CompressorName = "name8", RiskRanking = 3 },
                new CompressorResult { CompressorId = "comp9", CompressorName = "name9", RiskRanking = 3 }
            });
        }

        [HttpPost]
        public IHttpActionResult Upload()
        {
            var context = (CompressorHub)GlobalHost.ConnectionManager.GetHubContext<CompressorHub>();
            context.Send();
            return Ok();
        }
    }
}