namespace FoodPermits
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class MobileFoodPermit
    {
        private long objectid;
        private string applicant;
        private Facilitytype? facilitytype;
        private long cnn;
        private string locationdescription;
        private string address;
        private string blocklot;
        private string block;
        private string lot;
        private string permit;
        private Status status;
        private string fooditems;
        private string x;
        private string y;
        private string latitude;
        private string longitude;
        private Uri schedule;
        private DateTimeOffset? approved;
        private DateTimeOffset received;
        private long priorpermit;
        private DateTimeOffset? expirationdate;
        private Location location;
        private string dayshours;
        private DateTimeOffset? noisent;

        [JsonProperty("objectid")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Objectid { get => objectid; set => objectid = value; }

        [JsonProperty("applicant")]
        public string Applicant { get => applicant; set => applicant = value; }

        [JsonProperty("facilitytype", NullValueHandling = NullValueHandling.Ignore)]
        public Facilitytype? Facilitytype { get => facilitytype; set => facilitytype = value; }

        [JsonProperty("cnn")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Cnn { get => cnn; set => cnn = value; }

        [JsonProperty("locationdescription", NullValueHandling = NullValueHandling.Ignore)]
        public string Locationdescription { get => locationdescription; set => locationdescription = value; }

        [JsonProperty("address")]
        public string Address { get => address; set => address = value; }

        [JsonProperty("blocklot", NullValueHandling = NullValueHandling.Ignore)]
        public string Blocklot { get => blocklot; set => blocklot = value; }

        [JsonProperty("block", NullValueHandling = NullValueHandling.Ignore)]
        public string Block { get => block; set => block = value; }

        [JsonProperty("lot", NullValueHandling = NullValueHandling.Ignore)]
        public string Lot { get => lot; set => lot = value; }

        [JsonProperty("permit")]
        public string Permit { get => permit; set => permit = value; }

        [JsonProperty("status")]
        public Status Status { get => status; set => status = value; }

        [JsonProperty("fooditems", NullValueHandling = NullValueHandling.Ignore)]
        public string Fooditems { get => fooditems; set => fooditems = value; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public string X { get => x; set => x = value; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public string Y { get => y; set => y = value; }

        [JsonProperty("latitude")]
        public string Latitude { get => latitude; set => latitude = value; }

        [JsonProperty("longitude")]
        public string Longitude { get => longitude; set => longitude = value; }

        [JsonProperty("schedule")]
        public Uri Schedule { get => schedule; set => schedule = value; }

        [JsonProperty("approved", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Approved { get => approved; set => approved = value; }

        [JsonProperty("received")]
        public DateTimeOffset Received { get => received; set => received = value; }

        [JsonProperty("priorpermit")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Priorpermit { get => priorpermit; set => priorpermit = value; }

        [JsonProperty("expirationdate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Expirationdate { get => expirationdate; set => expirationdate = value; }

        [JsonProperty("location")]
        public Location Location { get => location; set => location = value; }

        [JsonProperty("dayshours", NullValueHandling = NullValueHandling.Ignore)]
        public string Dayshours { get => dayshours; set => dayshours = value; }

        [JsonProperty("noisent", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Noisent { get => noisent; set => noisent = value; }
    }

    public partial class Location
    {
        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }
    }

    public enum Facilitytype { PushCart, Truck };

    public enum TypeEnum { Point };

    public enum Status { Approved, Expired, Inactive, Issued, Requested, Suspend };

    public partial class MobileFoodPermit
    {
        public static MobileFoodPermit[] FromJson(string json) => JsonConvert.DeserializeObject<MobileFoodPermit[]>(json, FoodPermits.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MobileFoodPermit[] self) => JsonConvert.SerializeObject(self, FoodPermits.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                FacilitytypeConverter.Singleton,
                TypeEnumConverter.Singleton,
                StatusConverter.Singleton,
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

    internal class FacilitytypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Facilitytype) || t == typeof(Facilitytype?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Push Cart":
                    return Facilitytype.PushCart;
                case "Truck":
                    return Facilitytype.Truck;
            }
            throw new Exception("Cannot unmarshal type Facilitytype");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Facilitytype)untypedValue;
            switch (value)
            {
                case Facilitytype.PushCart:
                    serializer.Serialize(writer, "Push Cart");
                    return;
                case Facilitytype.Truck:
                    serializer.Serialize(writer, "Truck");
                    return;
            }
            throw new Exception("Cannot marshal type Facilitytype");
        }

        public static readonly FacilitytypeConverter Singleton = new FacilitytypeConverter();
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

    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "APPROVED":
                    return Status.Approved;
                case "EXPIRED":
                    return Status.Expired;
                case "INACTIVE":
                    return Status.Inactive;
                case "ISSUED":
                    return Status.Issued;
                case "REQUESTED":
                    return Status.Requested;
                case "SUSPEND":
                    return Status.Suspend;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Approved:
                    serializer.Serialize(writer, "APPROVED");
                    return;
                case Status.Expired:
                    serializer.Serialize(writer, "EXPIRED");
                    return;
                case Status.Inactive:
                    serializer.Serialize(writer, "INACTIVE");
                    return;
                case Status.Issued:
                    serializer.Serialize(writer, "ISSUED");
                    return;
                case Status.Requested:
                    serializer.Serialize(writer, "REQUESTED");
                    return;
                case Status.Suspend:
                    serializer.Serialize(writer, "SUSPEND");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}
