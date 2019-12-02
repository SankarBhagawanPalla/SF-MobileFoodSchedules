namespace Accidents
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CincinnatiAccident
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("accidentDate")]
        public string AccidentDate { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("accidentType")]
        public string AccidentType { get; set; }
    }

    public partial class CincinnatiAccident
    {
        public static CincinnatiAccident[] FromJson(string json) => JsonConvert.DeserializeObject<CincinnatiAccident[]>(json);
    }

    public static class Serialize
    {
        public static string ToJson(this CincinnatiAccident[] self) => JsonConvert.SerializeObject(self);
    }

    
   
        
    
}
