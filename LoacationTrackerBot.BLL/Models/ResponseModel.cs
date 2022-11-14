using LoacationTrackerBot.BLL.Models.ExtensionModels;
using System;
using System.Text.Json.Serialization;

namespace LoacationTrackerBot.BLL.Models
{
    public class ResponseModel
    {
            public String Event { get; set; }
            public Int64 Timestamp { get; set; }
            [JsonPropertyName("chat_hostname")]
            public String ChatHostname { get; set; }
            [JsonPropertyName("message_token")]
            public Int64 MessageToken { get; set; }
            public Sender Sender { get; set; }
            public Message Message { get; set; }
            public Boolean Silent { get; set; }
        }
}
