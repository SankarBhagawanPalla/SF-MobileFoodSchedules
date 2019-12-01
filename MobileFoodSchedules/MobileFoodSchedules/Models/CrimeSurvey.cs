namespace readSurvey
{
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CrimeSurvey
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("cityYouLive")]
        public string CityYouLive { get; set; }

        [JsonProperty("isSafe")]
        public bool IsSafe { get; set; }

        [JsonProperty("shiftCity")]
        public string ShiftCity { get; set; }
    }

    public partial class CrimeSurvey
    {
        public static CrimeSurvey[] FromJson(string json) => JsonConvert.DeserializeObject<CrimeSurvey[]>(json, readSurvey.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CrimeSurvey[] self) => JsonConvert.SerializeObject(self, readSurvey.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
