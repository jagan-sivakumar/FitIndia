using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace FitIndia.Models
{
    public class AadhaarClientApi
    {
        public AadhaarData DownloadPageAsync(String page)
        {
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(page);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(AadhaarData));
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(content));
            var aadhaardata = (AadhaarData)serializer.ReadObject(ms);
            return aadhaardata;
        }
    }
}