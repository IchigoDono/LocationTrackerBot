using LoacationTrackerBot.BLL.Models.ExtensionModels;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models
{
    public class ResponseModel
    {
        public String Event { get; set; }
        public Int64 Timestamp { get; set; }
        [JsonProperty("chat_hostname")]
        public String ChatHostname { get; set; }
        [JsonProperty("message_token")]
        public Int64 MessageToken { get; set; }
        public Sender Sender { get; set; }
        public Message Message { get; set; }
        public Boolean Silent { get; set; }
    }
}
