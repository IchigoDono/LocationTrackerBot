using LoacationTrackerBot.BLL.Models.ExtensionModels;
using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageTableModel
    {
        public String Receiver { get; set; }
        [JsonPropertyName("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        public String Type { get; set; }
        [JsonPropertyName("rich_media")]
        public RichMedia RichMedia { get; set; }
    }
}
