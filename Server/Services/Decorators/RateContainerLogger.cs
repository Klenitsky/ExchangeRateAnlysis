﻿using Server.DataStructures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Server.Services.Decorators
{
    class RateContainerLogger : IExchangeRateService
    {
        private readonly IExchangeRateService service;
        private readonly string writerFile;
        private readonly string jsonFilename;

        public RateContainerLogger(IExchangeRateService service, string filename,string jsonFileName)
        {
            this.service = service;
            this.writerFile = filename;
            this.jsonFilename = jsonFileName;
        }

        public void Clear()
        {
            using (var writer = new StreamWriter(File.Open(writerFile, FileMode.Append)))
            {
                writer.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " Calling Clear() ");
                this.service.Clear();
                writer.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " Clear() finished successfully  ");
            }
        }

   

        public List<ExchangeRate> GetRatesFromRange(DateTime startDate, DateTime endDate, string currency)
        {
            List<ExchangeRate> rates;
            using (var writer = new StreamWriter(File.Open(writerFile, FileMode.Append)))
            {
                writer.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " Calling GetRatesFromRate() with ");
                writer.Write("currency= '" + currency + "', ");
                writer.Write("startDate= '" + startDate.ToString("dd/MM/yyyy ", CultureInfo.InvariantCulture) + "'");
                writer.WriteLine("endDate= '" + endDate.ToString("dd/MM/yyyy ", CultureInfo.InvariantCulture) + "'");
                rates = this.service.GetRatesFromRange(startDate, endDate, currency);
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " GetRatesFromRate() returned '" + rates.Count + "' elements");
            }
            return rates;
        }

        public void LoadFromJson()
        {
            using (var writer = new StreamWriter(File.Open(writerFile, FileMode.Append)))
            {
                writer.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " Calling LoadFromJson() with ");
                writer.WriteLine("filename= '" + jsonFilename + "'");
                this.service.LoadFromJson();
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " LoadFromJson() finished successfully with ");
            }

        }

        public void SaveToJson()
        {
            using (var writer = new StreamWriter(File.Open(writerFile, FileMode.Append)))
            {
                writer.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " Calling SaveToJson() with ");
                writer.WriteLine("filename= '" + jsonFilename + "'");
                this.service.SaveToJson();
                writer.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture) + " SaveToJson() finished successfully ");
            }
        }

       
    }
}
