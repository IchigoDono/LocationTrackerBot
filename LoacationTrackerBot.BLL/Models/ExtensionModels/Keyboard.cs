using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class Keyboard
    {
        [JsonProperty("Type")]
        public String Type { get; set; }
        [JsonProperty("DefaultHeight")]
        public Boolean DefaultHeight { get; set; }
        [JsonProperty("Buttons")]
        public List<Buttons> Buttons { get; set; }
    }
}
