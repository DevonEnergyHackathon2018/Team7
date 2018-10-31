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
            parser.Delimiters = new string[] { "," };

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
                    EngineOilPressure = parseDouble(tokens[5]),
                    FuelPressure = parseDouble(tokens[6]),
                    Stage1DischargePressure = parseDouble(tokens[7]),
                    Stage2DischargePressure = parseDouble(tokens[8]),
                    Stage3DischargePressure = parseDouble(tokens[9]),
                    SuctionPressure = parseDouble(tokens[10]),
                    MaxDischargePressure = parseDouble(tokens[11]),
                    MaxSuctionPressure = parseDouble(tokens[12]),
                    CompressorOilTemp = parseDouble(tokens[13]),
                    Cylinder1DischargeTemp = parseDouble(tokens[14]),
                    Cylinder2DischargeTemp = parseDouble(tokens[15]),
                    Cylinder3DischargeTemp = parseDouble(tokens[16]),
                    Cylinder4DischargeTemp = parseDouble(tokens[17]),
                    EngineOilTemp = parseDouble(tokens[18]),
                    SuctionTemp = parseDouble(tokens[19]),
                    RPM = parseDouble(tokens[20]),
                    MaxRPMs = parseDouble(tokens[21]),
                    RunStatus = tokens[22],
                    SDStatusCode = tokens[23],
                    RuntimeHrs = parseDouble(tokens[24]),
                    DowntimeHrsYest = parseDouble(tokens[25]),
                    GasFlowRate = parseDouble(tokens[26]),
                    GasFlowRate_RAW = parseDouble(tokens[27]),
                    MaxGasFlowrate = parseDouble(tokens[28]),
                    CompressorStages = parseInt(tokens[29]),
                    Horsepower = parseDouble(tokens[30]),
                    UnitSize = tokens[31],
                    LastSuccessfulCommTime = parseDate(tokens[32]),
                    PctSuccessfulMsgsToday = parseDouble(tokens[33]),
                    SuccessfulMsgsToday = parseInt(tokens[34]),
                    FacilityDesc = tokens[35],
                    FacilityId = tokens[36],
                    TOWCompName = tokens[37]
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
