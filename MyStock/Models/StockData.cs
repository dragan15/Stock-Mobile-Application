using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyStock.Models
{
    public partial class StockData
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (Daily)")]
        public Dictionary<string, TimeSeriesDaily> TimeSeriesDaily { get; set; }
    }

    public partial class MetaData
    {
        [JsonProperty("1. Information")]
        public string The1Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string The2Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTimeOffset The3LastRefreshed { get; set; }

        [JsonProperty("4. Output Size")]
        public string The4OutputSize { get; set; }

        [JsonProperty("5. Time Zone")]
        public string The5TimeZone { get; set; }
    }

    public partial class TimeSeriesDaily
    {
        [JsonProperty("1. open")]
        public string The1Open { get; set; }

        [JsonProperty("2. high")]
        public string The2High { get; set; }

        [JsonProperty("3. low")]
        public string The3Low { get; set; }

        [JsonProperty("4. close")]
        public string The4Close { get; set; }

        [JsonProperty("5. volume")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long The5Volume { get; set; }
    }

    public partial class StockData
    {
        public static StockData FromJson(string json) => JsonConvert.DeserializeObject<StockData>(json, MyStock.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this StockData self) => JsonConvert.SerializeObject(self, MyStock.Models.Converter.Settings);
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
}


