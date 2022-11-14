using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class Keyboard
    {
        [JsonPropertyName("Type")]
        public String Type { get; set; }
        [JsonPropertyName("DefaultHeight")]
        public Boolean DefaultHeight { get; set; }
        [JsonPropertyName("Buttons")]
        public List<Buttons> Buttons { get; set; }
    }
}
