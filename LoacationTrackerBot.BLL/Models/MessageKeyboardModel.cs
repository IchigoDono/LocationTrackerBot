using System;
using LoacationTrackerBot.BLL.Models.ExtensionModels;
using Newtonsoft.Json;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageKeyboardModel
    {
        [JsonProperty("receiver")]
        public String Receiver { get; set; }
        [JsonProperty("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        [JsonProperty("tracking_data")]
        public String TrackingData { get; set; }
        [JsonProperty("keyboard")]
        public Keyboard Keyboard { get; set; }
    }
}
