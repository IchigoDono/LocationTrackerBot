using LoacationTrackerBot.BLL.Models.ExtensionModels;
using Newtonsoft.Json;
using System;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageTableModel
    {
        [JsonProperty("receiver")]
        public String Receiver { get; set; }
        [JsonProperty("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        [JsonProperty("type")]
        public String Type { get; set; }
        [JsonProperty("rich_media")]
        public RichMedia RichMedia { get; set; }
    }
}
