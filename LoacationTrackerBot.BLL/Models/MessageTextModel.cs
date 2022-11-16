using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageTextModel
    {
        public String Receiver { get; set; }
        [JsonProperty("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        [JsonProperty("tracking_data")]
        public String TrackingData { get; set; }
        public String Type { get; set; }
        public String Text { get; set; }
    }
}
