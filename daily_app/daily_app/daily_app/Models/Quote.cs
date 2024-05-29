using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace daily_app.Models
{
    public class Quote
    {
        [JsonInclude]
        public string q { get; set; }
        [JsonInclude]
        public string a { get; set; }
        [JsonInclude]
        public string h { get; set; }
    }
}
