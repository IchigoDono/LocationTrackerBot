using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class Sender
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Language { get; set; }
        public String Country { get; set; }
        [JsonProperty("api_version")]
        public Int32 ApiVersion { get; set; }
    }
}
