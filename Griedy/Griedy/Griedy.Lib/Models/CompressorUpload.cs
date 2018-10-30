using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griedy.Lib.Models
{
    public class CompressorResult
    {

        public string CompressorId { get; set; }
        public string CompressorName { get; set; }
        public DateTime PredictedFailure { get; set; }
        public int RiskRanking { get; set; }

    }
}
