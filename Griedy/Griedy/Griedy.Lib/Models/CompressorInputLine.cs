using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griedy.Lib.Models
{
    public class CompressorInputLine
    {

        public int? Id { get; set; }
        [JsonProperty(PropertyName = "Asset Name")]
        public string AssetName { get; set; }
        [JsonProperty(PropertyName = "Local Timestamp")]
        public DateTime? LocalTimestamp { get; set; }
        [JsonProperty(PropertyName = "UTC Milliseconds")]
        public long? UTCMilliseconds { get; set; }
        [JsonProperty(PropertyName = "Compressor Oil Pressure")]
        public double? CompressorOilPressure { get; set; }
        [JsonProperty(PropertyName = "Compressor Oil Temp")]
        public double? CompressorOilTemp { get; set; }
        [JsonProperty(PropertyName = "Compressor Stages")]
        public int? CompressorStages { get; set; }
        [JsonProperty(PropertyName = "Cylinder 1 Discharge Temp")]
        public double? Cylinder1DischargeTemp { get; set; }
        [JsonProperty(PropertyName = "Cylinder 2 Discharge Temp")]
        public double? Cylinder2DischargeTemp { get; set; }
        [JsonProperty(PropertyName = "Cylinder 3 Discharge Temp")]
        public double? Cylinder3DischargeTemp { get; set; }
        [JsonProperty(PropertyName = "Cylinder 4 Discharge Temp")]
        public double? Cylinder4DischargeTemp { get; set; }
        [JsonProperty(PropertyName = "Downtime Hrs Yest")]
        public double? DowntimeHrsYest { get; set; }
        [JsonProperty(PropertyName = "Engine Oil Pressure")]
        public double? EngineOilPressure { get; set; }
        [JsonProperty(PropertyName = "Engine Oil Temp")]
        public double? EngineOilTemp { get; set; }
        [JsonProperty(PropertyName = "Facility Desc")]
        public string FacilityDesc { get; set; }
        [JsonProperty(PropertyName = "Facility ID")]
        public string FacilityId { get; set; }
        [JsonProperty(PropertyName = "Fuel Pressure")]
        public double? FuelPressure { get; set; }
        [JsonProperty(PropertyName = "Gas Flow Rate")]
        public double? GasFlowRate { get; set; }
        [JsonProperty(PropertyName = "Gas Flow Rate_RAW")]
        public double? GasFlowRate_RAW { get; set; }
        [JsonProperty(PropertyName = "Horsepower")]
        public double? Horsepower { get; set; }
        [JsonProperty(PropertyName = "Last Successful Comm Time")]
        public DateTime? LastSuccessfulCommTime { get; set; }
        [JsonProperty(PropertyName = "Max Discharge Pressure")]
        public double? MaxDischargePressure { get; set; }
        [JsonProperty(PropertyName = "Max Gas Flowrate")]
        public double? MaxGasFlowrate { get; set; }
        [JsonProperty(PropertyName = "Max RPMs")]
        public double? MaxRPMs { get; set; }
        [JsonProperty(PropertyName = "Max Suction Pressure")]
        public double? MaxSuctionPressure { get; set; }
        [JsonProperty(PropertyName = "Pct Successful Msgs Today")]
        public double? PctSuccessfulMsgsToday { get; set; }
        [JsonProperty(PropertyName = "RPM")]
        public double? RPM { get; set; }
        [JsonProperty(PropertyName = "Run Status")]
        public string RunStatus { get; set; }
        [JsonProperty(PropertyName = "Runtime Hrs")]
        public double? RuntimeHrs { get; set; }
        [JsonProperty(PropertyName = "SD Status Code")]
        public string SDStatusCode { get; set; }
        [JsonProperty(PropertyName = "Stage 1 Discharge Pressure")]
        public double? Stage1DischargePressure { get; set; }
        [JsonProperty(PropertyName = "Stage 2 Discharge Pressure")]
        public double? Stage2DischargePressure { get; set; }
        [JsonProperty(PropertyName = "Stage 3 Discharge Pressure")]
        public double? Stage3DischargePressure { get; set; }
        [JsonProperty(PropertyName = "Successful Msgs Today")]
        public int? SuccessfulMsgsToday { get; set; }
        [JsonProperty(PropertyName = "Suction Pressure")]
        public double? SuctionPressure { get; set; }
        [JsonProperty(PropertyName = "Suction Temp")]
        public double? SuctionTemp { get; set; }
        [JsonProperty(PropertyName = "TOW Comp Name")]
        public string TOWCompName { get; set; }
        [JsonProperty(PropertyName = "Unit Size")]
        public string UnitSize { get; set; }

        public string[] Headers()
        {
            return new string[]
            {"Asset Name", "Local Timestamp", "UTC Milliseconds", "Compressor Oil Pressure", "Compressor Oil Temp", "Compressor Stages", "Cylinder 1 Discharge Temp", "Cylinder 2 Discharge Temp", "Cylinder 3 Discharge Temp", "Cylinder 4 Discharge Temp", "Downtime Hrs Yest", "Engine Oil Pressure", "Engine Oil Temp", "Facility Desc", "Fuel Pressure", "Gas Flow Rate", "Gas Flow Rate_RAW", "Horsepower", "Last Successful Comm Time", "Max Discharge Pressure", "Max Gas Flowrate", "Max RPMs", "Max Suction Pressure", "Pct Successful Msgs Today", "RPM", "Run Status", "Runtime Hrs", "SD Status Code", "Stage 1 Discharge Pressure", "Stage 2 Discharge Pressure", "Stage 3 Discharge Pressure", "Suction Pressure", "Suction Temp", "Unit Size"};
        }

        public string[] Values()
        {
            return new string[]
            {
                ""+AssetName,
                ""+LocalTimestamp?.ToString("u"),
                ""+UTCMilliseconds,
                ""+CompressorOilPressure,
                ""+CompressorOilTemp,
                ""+CompressorStages,
                ""+Cylinder1DischargeTemp,
                ""+Cylinder2DischargeTemp,
                ""+Cylinder3DischargeTemp,
                ""+Cylinder4DischargeTemp,
                ""+DowntimeHrsYest,
                ""+EngineOilPressure,
                ""+EngineOilTemp,
                ""+FacilityDesc,
                ""+FuelPressure,
                ""+GasFlowRate,
                ""+GasFlowRate_RAW,
                ""+Horsepower,
                ""+LastSuccessfulCommTime?.ToString("u"),
                ""+MaxDischargePressure,
                ""+MaxGasFlowrate,
                ""+MaxRPMs,
                ""+MaxSuctionPressure,
                ""+PctSuccessfulMsgsToday,
                ""+RPM,
                ""+RunStatus,
                ""+RuntimeHrs,
                ""+SDStatusCode,
                ""+Stage1DischargePressure,
                ""+Stage2DischargePressure,
                ""+Stage3DischargePressure,
                ""+SuctionPressure,
                ""+SuctionTemp,
                ""+UnitSize
            };
        }

    }
}
