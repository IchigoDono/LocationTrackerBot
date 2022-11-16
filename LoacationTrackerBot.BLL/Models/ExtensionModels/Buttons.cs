using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class Buttons
    {
        public String ActionType { get; set; }
        public String ActionBody { get; set; }
        [JsonPropertyName("Text")]
        public String Text { get; set; }
        [JsonPropertyName("TextSize")]
        public String TextSize { get; set; }
        [JsonPropertyName("BgColor")]
        public String BgColor { get; set; }
        [JsonPropertyName("Columns")]
        public String Columns { get; set; }
        [JsonPropertyName("Rows")]
        public String Rows { get; set; }
    }
}
