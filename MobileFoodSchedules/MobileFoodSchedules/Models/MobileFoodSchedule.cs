namespace Schedules
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MobileFoodSchedule
    {
        private long dayorder;
        private Dayofweekstr dayofweekstr;
        private Time starttime;
        private Time endtime;
        private string permit;
        private string location;
        private string locationdesc;
        private string optionaltext;
        private long locationid;
        private End24 start24;
        private End24 end24;
        private long cnn;
        private DateTimeOffset addrDateCreate;
        private DateTimeOffset? addrDateModified;
        private string block;
        private string lot;
        private Coldtruck coldtruck;
        private string applicant;
        private string x;
        private string y;
        private string latitude;
        private string longitude;
        private Location2 location2;

        [JsonProperty("dayorder")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Dayorder { get => dayorder; set => dayorder = value; }

        [JsonProperty("dayofweekstr")]
        public Dayofweekstr Dayofweekstr { get => dayofweekstr; set => dayofweekstr = value; }

        [JsonProperty("starttime")]
        public Time Starttime { get => starttime; set => starttime = value; }

        [JsonProperty("endtime")]
        public Time Endtime { get => endtime; set => endtime = value; }

        [JsonProperty("permit")]
        public string Permit { get => permit; set => permit = value; }

        [JsonProperty("location")]
        public string Location { get => location; set => location = value; }

        [JsonProperty("locationdesc", NullValueHandling = NullValueHandling.Ignore)]
        public string Locationdesc { get => locationdesc; set => locationdesc = value; }

        [JsonProperty("optionaltext", NullValueHandling = NullValueHandling.Ignore)]
        public string Optionaltext { get => optionaltext; set => optionaltext = value; }

        [JsonProperty("locationid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Locationid { get => locationid; set => locationid = value; }

        [JsonProperty("start24")]
        public End24 Start24 { get => start24; set => start24 = value; }

        [JsonProperty("end24")]
        public End24 End24 { get => end24; set => end24 = value; }

        [JsonProperty("cnn")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Cnn { get => cnn; set => cnn = value; }

        [JsonProperty("addr_date_create")]
        public DateTimeOffset AddrDateCreate { get => addrDateCreate; set => addrDateCreate = value; }

        [JsonProperty("addr_date_modified", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AddrDateModified { get => addrDateModified; set => addrDateModified = value; }

        [JsonProperty("block")]
        public string Block { get => block; set => block = value; }

        [JsonProperty("lot")]
        public string Lot { get => lot; set => lot = value; }

        [JsonProperty("coldtruck")]
        public Coldtruck Coldtruck { get => coldtruck; set => coldtruck = value; }

        [JsonProperty("applicant")]
        public string Applicant { get => applicant; set => applicant = value; }

        [JsonProperty("x")]
        public string X { get => x; set => x = value; }

        [JsonProperty("y")]
        public string Y { get => y; set => y = value; }

        [JsonProperty("latitude")]
        public string Latitude { get => latitude; set => latitude = value; }

        [JsonProperty("longitude")]
        public string Longitude { get => longitude; set => longitude = value; }

        [JsonProperty("location_2")]
        public Location2 Location2 { get => location2; set => location2 = value; }
    }

    public partial class Location2
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }

    public enum Coldtruck { N, Y };

    public enum Dayofweekstr { Friday, Monday, Saturday, Sunday, Thursday, Tuesday, Wednesday };

    public enum End24 { The0000, The0100, The0300, The0400, The0500, The0600, The0700, The0800, The0900, The1000, The1100, The1200, The1300, The1400, The1500, The1600, The1700, The1800, The1900, The2000, The2100, The2200, The2300, The2400 };

    public enum Time { The10Am, The10Pm, The11Am, The11Pm, The12Am, The12Pm, The1Am, The1Pm, The2Pm, The3Am, The3Pm, The4Am, The4Pm, The5Am, The5Pm, The6Am, The6Pm, The7Am, The7Pm, The8Am, The8Pm, The9Am, The9Pm };

    public enum TypeEnum { Point };

    public partial class MobileFoodSchedule
    {
        public static MobileFoodSchedule[] FromJson(string json) => JsonConvert.DeserializeObject<MobileFoodSchedule[]>(json, Schedules.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MobileFoodSchedule[] self) => JsonConvert.SerializeObject(self, Schedules.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ColdtruckConverter.Singleton,
                DayofweekstrConverter.Singleton,
                End24Converter.Singleton,
                TimeConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class ColdtruckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Coldtruck) || t == typeof(Coldtruck?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "N":
                    return Coldtruck.N;
                case "Y":
                    return Coldtruck.Y;
            }
            throw new Exception("Cannot unmarshal type Coldtruck");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Coldtruck)untypedValue;
            switch (value)
            {
                case Coldtruck.N:
                    serializer.Serialize(writer, "N");
                    return;
                case Coldtruck.Y:
                    serializer.Serialize(writer, "Y");
                    return;
            }
            throw new Exception("Cannot marshal type Coldtruck");
        }

        public static readonly ColdtruckConverter Singleton = new ColdtruckConverter();
    }

    internal class DayofweekstrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Dayofweekstr) || t == typeof(Dayofweekstr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Friday":
                    return Dayofweekstr.Friday;
                case "Monday":
                    return Dayofweekstr.Monday;
                case "Saturday":
                    return Dayofweekstr.Saturday;
                case "Sunday":
                    return Dayofweekstr.Sunday;
                case "Thursday":
                    return Dayofweekstr.Thursday;
                case "Tuesday":
                    return Dayofweekstr.Tuesday;
                case "Wednesday":
                    return Dayofweekstr.Wednesday;
            }
            throw new Exception("Cannot unmarshal type Dayofweekstr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Dayofweekstr)untypedValue;
            switch (value)
            {
                case Dayofweekstr.Friday:
                    serializer.Serialize(writer, "Friday");
                    return;
                case Dayofweekstr.Monday:
                    serializer.Serialize(writer, "Monday");
                    return;
                case Dayofweekstr.Saturday:
                    serializer.Serialize(writer, "Saturday");
                    return;
                case Dayofweekstr.Sunday:
                    serializer.Serialize(writer, "Sunday");
                    return;
                case Dayofweekstr.Thursday:
                    serializer.Serialize(writer, "Thursday");
                    return;
                case Dayofweekstr.Tuesday:
                    serializer.Serialize(writer, "Tuesday");
                    return;
                case Dayofweekstr.Wednesday:
                    serializer.Serialize(writer, "Wednesday");
                    return;
            }
            throw new Exception("Cannot marshal type Dayofweekstr");
        }

        public static readonly DayofweekstrConverter Singleton = new DayofweekstrConverter();
    }

    internal class End24Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(End24) || t == typeof(End24?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "00:00":
                    return End24.The0000;
                case "01:00":
                    return End24.The0100;
                case "03:00":
                    return End24.The0300;
                case "04:00":
                    return End24.The0400;
                case "05:00":
                    return End24.The0500;
                case "06:00":
                    return End24.The0600;
                case "07:00":
                    return End24.The0700;
                case "08:00":
                    return End24.The0800;
                case "09:00":
                    return End24.The0900;
                case "10:00":
                    return End24.The1000;
                case "11:00":
                    return End24.The1100;
                case "12:00":
                    return End24.The1200;
                case "13:00":
                    return End24.The1300;
                case "14:00":
                    return End24.The1400;
                case "15:00":
                    return End24.The1500;
                case "16:00":
                    return End24.The1600;
                case "17:00":
                    return End24.The1700;
                case "18:00":
                    return End24.The1800;
                case "19:00":
                    return End24.The1900;
                case "20:00":
                    return End24.The2000;
                case "21:00":
                    return End24.The2100;
                case "22:00":
                    return End24.The2200;
                case "23:00":
                    return End24.The2300;
                case "24:00":
                    return End24.The2400;
            }
            throw new Exception("Cannot unmarshal type End24");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (End24)untypedValue;
            switch (value)
            {
                case End24.The0000:
                    serializer.Serialize(writer, "00:00");
                    return;
                case End24.The0100:
                    serializer.Serialize(writer, "01:00");
                    return;
                case End24.The0300:
                    serializer.Serialize(writer, "03:00");
                    return;
                case End24.The0400:
                    serializer.Serialize(writer, "04:00");
                    return;
                case End24.The0500:
                    serializer.Serialize(writer, "05:00");
                    return;
                case End24.The0600:
                    serializer.Serialize(writer, "06:00");
                    return;
                case End24.The0700:
                    serializer.Serialize(writer, "07:00");
                    return;
                case End24.The0800:
                    serializer.Serialize(writer, "08:00");
                    return;
                case End24.The0900:
                    serializer.Serialize(writer, "09:00");
                    return;
                case End24.The1000:
                    serializer.Serialize(writer, "10:00");
                    return;
                case End24.The1100:
                    serializer.Serialize(writer, "11:00");
                    return;
                case End24.The1200:
                    serializer.Serialize(writer, "12:00");
                    return;
                case End24.The1300:
                    serializer.Serialize(writer, "13:00");
                    return;
                case End24.The1400:
                    serializer.Serialize(writer, "14:00");
                    return;
                case End24.The1500:
                    serializer.Serialize(writer, "15:00");
                    return;
                case End24.The1600:
                    serializer.Serialize(writer, "16:00");
                    return;
                case End24.The1700:
                    serializer.Serialize(writer, "17:00");
                    return;
                case End24.The1800:
                    serializer.Serialize(writer, "18:00");
                    return;
                case End24.The1900:
                    serializer.Serialize(writer, "19:00");
                    return;
                case End24.The2000:
                    serializer.Serialize(writer, "20:00");
                    return;
                case End24.The2100:
                    serializer.Serialize(writer, "21:00");
                    return;
                case End24.The2200:
                    serializer.Serialize(writer, "22:00");
                    return;
                case End24.The2300:
                    serializer.Serialize(writer, "23:00");
                    return;
                case End24.The2400:
                    serializer.Serialize(writer, "24:00");
                    return;
            }
            throw new Exception("Cannot marshal type End24");
        }

        public static readonly End24Converter Singleton = new End24Converter();
    }

    internal class TimeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Time) || t == typeof(Time?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "10AM":
                    return Time.The10Am;
                case "10PM":
                    return Time.The10Pm;
                case "11AM":
                    return Time.The11Am;
                case "11PM":
                    return Time.The11Pm;
                case "12AM":
                    return Time.The12Am;
                case "12PM":
                    return Time.The12Pm;
                case "1AM":
                    return Time.The1Am;
                case "1PM":
                    return Time.The1Pm;
                case "2PM":
                    return Time.The2Pm;
                case "3AM":
                    return Time.The3Am;
                case "3PM":
                    return Time.The3Pm;
                case "4AM":
                    return Time.The4Am;
                case "4PM":
                    return Time.The4Pm;
                case "5AM":
                    return Time.The5Am;
                case "5PM":
                    return Time.The5Pm;
                case "6AM":
                    return Time.The6Am;
                case "6PM":
                    return Time.The6Pm;
                case "7AM":
                    return Time.The7Am;
                case "7PM":
                    return Time.The7Pm;
                case "8AM":
                    return Time.The8Am;
                case "8PM":
                    return Time.The8Pm;
                case "9AM":
                    return Time.The9Am;
                case "9PM":
                    return Time.The9Pm;
            }
            throw new Exception("Cannot unmarshal type Time");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Time)untypedValue;
            switch (value)
            {
                case Time.The10Am:
                    serializer.Serialize(writer, "10AM");
                    return;
                case Time.The10Pm:
                    serializer.Serialize(writer, "10PM");
                    return;
                case Time.The11Am:
                    serializer.Serialize(writer, "11AM");
                    return;
                case Time.The11Pm:
                    serializer.Serialize(writer, "11PM");
                    return;
                case Time.The12Am:
                    serializer.Serialize(writer, "12AM");
                    return;
                case Time.The12Pm:
                    serializer.Serialize(writer, "12PM");
                    return;
                case Time.The1Am:
                    serializer.Serialize(writer, "1AM");
                    return;
                case Time.The1Pm:
                    serializer.Serialize(writer, "1PM");
                    return;
                case Time.The2Pm:
                    serializer.Serialize(writer, "2PM");
                    return;
                case Time.The3Am:
                    serializer.Serialize(writer, "3AM");
                    return;
                case Time.The3Pm:
                    serializer.Serialize(writer, "3PM");
                    return;
                case Time.The4Am:
                    serializer.Serialize(writer, "4AM");
                    return;
                case Time.The4Pm:
                    serializer.Serialize(writer, "4PM");
                    return;
                case Time.The5Am:
                    serializer.Serialize(writer, "5AM");
                    return;
                case Time.The5Pm:
                    serializer.Serialize(writer, "5PM");
                    return;
                case Time.The6Am:
                    serializer.Serialize(writer, "6AM");
                    return;
                case Time.The6Pm:
                    serializer.Serialize(writer, "6PM");
                    return;
                case Time.The7Am:
                    serializer.Serialize(writer, "7AM");
                    return;
                case Time.The7Pm:
                    serializer.Serialize(writer, "7PM");
                    return;
                case Time.The8Am:
                    serializer.Serialize(writer, "8AM");
                    return;
                case Time.The8Pm:
                    serializer.Serialize(writer, "8PM");
                    return;
                case Time.The9Am:
                    serializer.Serialize(writer, "9AM");
                    return;
                case Time.The9Pm:
                    serializer.Serialize(writer, "9PM");
                    return;
            }
            throw new Exception("Cannot marshal type Time");
        }

        public static readonly TimeConverter Singleton = new TimeConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Point")
            {
                return TypeEnum.Point;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Point)
            {
                serializer.Serialize(writer, "Point");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
