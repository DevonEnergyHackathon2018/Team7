using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griedy.Lib.Models
{
    public class CompressorInputLine
    {

        public int Id { get; set; }
        public string AssetName { get; set; }
        public DateTime LocalTimestamp { get; set; }
        public long UTCMilliseconds { get; set; }
        public double? CompressorOilPressure { get; set; }
        public double? CompressorOilTemp { get; set; }
        public int? CompressorStages { get; set; }
        public double? Cylinder1DischargeTemp { get; set; }
        public double? Cylinder2DischargeTemp { get; set; }
        public double? Cylinder3DischargeTemp { get; set; }
        public double? Cylinder4DischargeTemp { get; set; }
        public double? DowntimeHrsYest { get; set; }
        public double? EngineOilPressure { get; set; }
        public double? EngineOilTemp { get; set; }
        public string FacilityDesc { get; set; }
        public string FacilityId { get; set; }
        public double? FuelPressure { get; set; }
        public double? GasFlowRate { get; set; }
        public double? GasFlowRate_RAW { get; set; }
        public double? Horsepower { get; set; }
        public DateTime LastSuccessfulCommTime { get; set; }
        public double? MaxDischargePressure { get; set; }
        public double? MaxGasFlowrate { get; set; }
        public double? MaxRPMs { get; set; }
        public double? MaxSuctionPressure { get; set; }
        public double? PctSuccessfulMsgsToday { get; set; }
        public double? RPM { get; set; }
        public string RunStatus { get; set; }
        public double? RuntimeHrs { get; set; }
        public string SDStatusCode { get; set; }
        public double? Stage1DischargePressure { get; set; }
        public double? Stage2DischargePressure { get; set; }
        public double? Stage3DischargePressure { get; set; }
        public int? SuccessfulMsgsToday { get; set; }
        public double? SuctionPressure { get; set; }
        public double? SuctionTemp { get; set; }
        public string TOWCompName { get; set; }
        public string UnitSize { get; set; }


    }
}
