using Griedy.API.Hubs;
using Griedy.Lib.Business;
using Griedy.Lib.DataAccess;
using Griedy.Lib.DataContext;
using Griedy.Lib.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Griedy.API.Controllers
{
    public class CompressorUploadController : ApiController
    {
        //private readonly GriedyDataContext _context;

        public CompressorUploadController()
        {
            //_context = new GriedyDataContext();
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Example()
        {
            //string csv = File.ReadAllText("C:/temp/input.csv");
            using (var instream = File.OpenRead("C:/temp/input.tsv"))
            {
                var lines = CompressorCsvReader.Create(instream);
                var result = await CallModel.CalculateFullSet(lines);

                instream.Close();
                return Ok();
            }
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IHttpActionResult> Get()
        //{
        //    var uploads = await _context
        //        .Set<CompressorResult>()
        //        .ToListAsync();
        //    return Ok(uploads);

        //}

        [HttpPost]
        public async Task<IHttpActionResult> Upload()
        {
            //var id = _context.CompressorResults.Select(x => x.Id).Max() + 1;
            //_context.CompressorResults.Add(new CompressorResult() { Id = id, CompressorId = $"ryry-serks-{id}", CompressorName = $"ryry serks {id}", RankedOn = DateTime.Now, RiskRanking = 1 });
            //_context.SaveChanges();
            var signalrContext = GlobalHost.ConnectionManager.GetHubContext<CompressorHub>();
            var memoryStream = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
            foreach (var content in memoryStream.Contents)
            {
                //string fileName = content.Headers.ContentDisposition.FileName;
                //string name = content.Headers.ContentDisposition.Name.Replace("\"", string.Empty);
                //if (string.IsNullOrWhiteSpace(fileName))
                //{
                //    continue;
                //}
                List<CompressorInputLine> lines = CompressorCsvReader.Create(await content.ReadAsStreamAsync());
                var result = await CallModel.CalculateFullSet(lines);
                signalrContext.Clients.All.CompressorsChanged(result);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Dismiss(string key)    
        {
            //var compressor = _context.CompressorResults.Find(key);
            //if (compressor == null) { return NotFound(); }

            //_context.CompressorResults.Remove(compressor);
            //_context.SaveChanges();

            var signalrContext = GlobalHost.ConnectionManager.GetHubContext<CompressorHub>();
            signalrContext.Clients.All.CompressorDismissed(key);

            return Ok();
        }
    }
}