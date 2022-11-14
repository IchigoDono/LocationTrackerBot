using System.Text.Json.Serialization;
using System;
using LoacationTrackerBot.BLL.Models.ExtensionModels;

namespace LoacationTrackerBot.BLL.Models
{
    public class MessageKeyboardModel
    {
        public String Receiver { get; set; }
        [JsonPropertyName("min_api_version")]
        public Int32 MinApiVersion { get; set; }
        [JsonPropertyName("keyboard")]
        public Keyboard Keyboard { get; set; }
    }
}
