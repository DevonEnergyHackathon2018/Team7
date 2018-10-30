﻿using Griedy.API.Hubs;
using Griedy.Lib.DataContext;
using Microsoft.AspNet.SignalR;
using System;
using System.Linq;
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
            return Ok(_context.CompressorResults);
        }

        [HttpPost]
        public IHttpActionResult Upload()
        {
            var id = _context.CompressorResults.Select(x => x.Id).Max() + 1;
            _context.CompressorResults.Add(new CompressorResult() { Id = id, CompressorId = $"ryry-serks-{id}", CompressorName = $"ryry serks {id}", RankedOn = DateTime.Now, RiskRanking = 1 });
            _context.SaveChanges();

            var signalrContext = GlobalHost.ConnectionManager.GetHubContext<CompressorHub>();
            signalrContext.Clients.All.CompressorsAdded("I added some compressors.");

            return Ok();
        }
    }
}