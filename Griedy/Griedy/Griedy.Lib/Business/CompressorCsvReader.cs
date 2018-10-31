using Griedy.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace Griedy.Lib.Business
{
    public static class CompressorCsvReader
    {

        public static List<CompressorInputLine> Create(Stream inputFile)
        {
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(inputFile);
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.Delimiters = new string[] { "\t" };

            //skip the first line, it's header info
            parser.ReadLine();

            var inputLines = new List<CompressorInputLine>();
            while (!parser.EndOfData)
            {
                string[] tokens = parser.ReadFields();

                //column order from the most recent CSV file we've seen
                //Id Asset Name Local Timestamp UTC Milliseconds Compressor Oil Pressure Engine Oil Pressure Fuel Pressure Stage 1 Discharge Pressure  Stage 2 Discharge Pressure  Stage 3 Discharge Pressure  Suction Pressure    Max Discharge Pressure Max Suction Pressure    Compressor Oil Temp Cylinder 1 Discharge Temp   Cylinder 2 Discharge Temp   Cylinder 3 Discharge Temp   Cylinder 4 Discharge Temp   Engine Oil Temp Suction Temp RPM Max RPMs    Run Status  SD Status Code Runtime Hrs Downtime Hrs Yest   Gas Flow Rate Gas Flow Rate_RAW   Max Gas Flowrate Compressor Stages Horsepower  Unit Size   Last Successful Comm Time   Pct Successful Msgs Today   Successful Msgs Today Facility Desc Facility ID TOW Comp Name
                //Successful Msgs Today Facility Desc Facility ID TOW Comp Name


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
                return 0;
            }
            int x;
            return int.TryParse(token, out x) ? (int?)x : 0;
        }

        public static double? parseDouble(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return 0;
            }
            double x;
            return double.TryParse(token, out x) ? (double?)x : 0;
        }

    }
}
