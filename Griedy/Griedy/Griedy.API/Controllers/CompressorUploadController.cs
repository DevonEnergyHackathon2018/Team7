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
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Griedy.API.Controllers
{
    [RoutePrefix("CompressorUpload")]
    public class CompressorUploadController : ApiController
    {

        private readonly GriedyDataContext _context;

        public CompressorUploadController()
        {
            _context = new GriedyDataContext();
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Example()
        {
            string csv = File.ReadAllText("C:/Users/ryan/Downloads/input.csv");
            var lines = CompressorCsvReader.Create(csv);
            var result = await CallModel.MakeRequest(lines);
            return Ok();
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
        [Route("upload")]
        public async Task<IHttpActionResult> Upload()
        {
            var context = (CompressorHub) GlobalHost.ConnectionManager.GetHubContext<CompressorHub>();
            try
            {
                if(!Request.Content.IsMimeMultipartContent())
                {
                    return StatusCode(HttpStatusCode.UnsupportedMediaType);
                }

                var memoryStream = await Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider());
                foreach (var content in memoryStream.Contents)
                {
                    string fileName = content.Headers.ContentDisposition.FileName;
                    string name = content.Headers.ContentDisposition.Name.Replace("\"", string.Empty);
                    if (string.IsNullOrWhiteSpace(fileName))
                    {
                        continue;
                    }

                    string tsv = await content.ReadAsStringAsync();
                    List<CompressorInputLine> lines = CompressorCsvReader.Create(tsv);
                    context.Send();
                }
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            return StatusCode(HttpStatusCode.OK);
        }

        private void trunkAndReloadCompressors(List<CompressorInputLine> lines)
        {
            _context.Set<CompressorResult>().RemoveRange(_context.Set<CompressorResult>());

            var newData = lines.Aggregate(new Dictionary<string, CompressorResult>(), (acc, line) =>
            {
                if (!acc.ContainsKey(line.FacilityId))
                {
                    acc[line.FacilityId] = new CompressorResult()
                    {
                        CompressorId = line.FacilityId,
                        CompressorName = line.AssetName
                    };
                }

                return acc;
            }).Values.ToList();

            _context.Set<CompressorResult>().AddRange(newData);
            _context.SaveChanges();
        }

    }
}