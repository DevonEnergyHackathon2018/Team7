using Griedy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Griedy.Lib.Business
{
    public static class CompressorCsvReader
    {

        public static List<CompressorInputLine> Create(string tsv)
        {
            string[] lines = tsv.Split('\n');
            var inputLines = new List<CompressorInputLine>();
            for(int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if(string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] tokens = line.Split(',');
                inputLines.Add(new CompressorInputLine()
                {
                    Id = parseInt(tokens[0]),
                    AssetName = tokens[1],
                    LocalTimestamp = parseDate(tokens[2]),
                    UTCMilliseconds = parseInt(tokens[3]),
                    CompressorOilPressure = parseDouble(tokens[4]),
                    CompressorOilTemp = parseDouble(tokens[5]),
                    CompressorStages = parseInt(tokens[6]),
                    Cylinder1DischargeTemp = parseDouble(tokens[7]),
                    Cylinder2DischargeTemp = parseDouble(tokens[8]),
                    Cylinder3DischargeTemp = parseDouble(tokens[9]),
                    Cylinder4DischargeTemp = parseDouble(tokens[10]),
                    DowntimeHrsYest = parseDouble(tokens[11]),
                    EngineOilPressure = parseDouble(tokens[12]),
                    EngineOilTemp = parseDouble(tokens[13]),
                    FacilityDesc = tokens[14],
                    FacilityId = tokens[15],
                    FuelPressure = parseDouble(tokens[16]),
                    GasFlowRate = parseDouble(tokens[17]),
                    GasFlowRate_RAW = parseDouble(tokens[18]),
                    Horsepower = parseDouble(tokens[19]),
                    LastSuccessfulCommTime = parseDate(tokens[20]),
                    MaxDischargePressure = parseDouble(tokens[21]),
                    MaxGasFlowrate = parseDouble(tokens[22]),
                    MaxRPMs = parseDouble(tokens[23]),
                    MaxSuctionPressure = parseDouble(tokens[24]),
                    PctSuccessfulMsgsToday = parseDouble(tokens[25]),
                    RPM = parseDouble(tokens[26]),
                    RunStatus = tokens[27],
                    RuntimeHrs = parseDouble(tokens[28]),
                    SDStatusCode = tokens[29],
                    Stage1DischargePressure = parseDouble(tokens[30]),
                    Stage2DischargePressure = parseDouble(tokens[31]),
                    Stage3DischargePressure = parseDouble(tokens[32]),
                    SuccessfulMsgsToday = parseInt(tokens[33]),
                    SuctionPressure = parseDouble(tokens[34]),
                    SuctionTemp = parseDouble(tokens[35]),
                    TOWCompName = tokens[36],
                    UnitSize = tokens[37]
                });
            }

            return inputLines;
        }

        public static DateTime? parseDate(string dateString)
        {
            if(string.IsNullOrWhiteSpace(dateString))
            {
                return null;
            }

            DateTime value;
            return DateTime.TryParse(dateString, out value) ? (DateTime?)value : null;
        }

        public static int? parseInt(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            int x;
            return int.TryParse(token, out x) ? (int?)x : null;
        }

        public static double? parseDouble(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            double x;
            return double.TryParse(token, out x) ? (double?)x : null;
        }

    }
}
