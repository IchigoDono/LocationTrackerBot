using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageTextModel
    {
        public String Receiver { get; set; }
        [JsonPropertyName("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        [JsonPropertyName("tracking_data")]
        public String TrackingData { get; set; }
        public String Type { get; set; }
        public String Text { get; set; }
    }
}
