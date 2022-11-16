using Newtonsoft.Json;
using System;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class Message
    {
        public String Text { get; set; }
        public String Type { get; set; }
        [JsonProperty("tracking_data")]
        public String TrackingData { get; set; }
    }
}
