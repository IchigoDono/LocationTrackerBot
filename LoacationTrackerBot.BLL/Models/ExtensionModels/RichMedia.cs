using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoacationTrackerBot.BLL.Models.ExtensionModels
{
    public class RichMedia
    {
        public String Type { get; set; }
        public List<Buttons> Buttons { get; set; }
    }
}
