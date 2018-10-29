using Griedy.Lib.DataContext;
using Griedy.Lib.Models;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Griedy.API.Controllers
{
    [RoutePrefix("CompressorUpload")]
    public class CompressorUploadController : ApiController
    {

        private readonly GriedyDataContext _context;

        public CompressorUploadController(GriedyDataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] DateTime rankedOn)
        {
            return Ok(_context
                .Set<CompressorUpload>()
                .Where(cu => 
                    cu.RankedOn.Year == rankedOn.Year 
                    && cu.RankedOn.DayOfYear == rankedOn.DayOfYear));

        }

    }
}