using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickType
{
    public partial class AdressApiResult
    {
        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("query")]
        public Query Query { get; set; }
    }

    public partial class Query
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("parsed")]
        public Parsed Parsed { get; set; }
    }

    public partial class Parsed
    {
        [JsonProperty("housenumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Housenumber { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("postcode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Postcode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("expected_type")]
        public string ExpectedType { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("datasource")]
        public Datasource Datasource { get; set; }

        [JsonProperty("housenumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Housenumber { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("postcode")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Postcode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("lon")]
        public decimal Lon { get; set; }

        [JsonProperty("lat")]
        public decimal Lat { get; set; }

        [JsonProperty("state_code")]
        public string StateCode { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        [JsonProperty("address_line1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("result_type")]
        public string ResultType { get; set; }

        [JsonProperty("rank")]
        public Rank Rank { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("bbox")]
        public Bbox Bbox { get; set; }
    }

    public partial class Bbox
    {
        [JsonProperty("lon1")]
        public double Lon1 { get; set; }

        [JsonProperty("lat1")]
        public double Lat1 { get; set; }

        [JsonProperty("lon2")]
        public double Lon2 { get; set; }

        [JsonProperty("lat2")]
        public double Lat2 { get; set; }
    }

    public partial class Datasource
    {
        [JsonProperty("sourcename")]
        public string Sourcename { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class Rank
    {
        [JsonProperty("importance")]
        public double Importance { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("confidence")]
        public long Confidence { get; set; }

        [JsonProperty("confidence_city_level")]
        public long ConfidenceCityLevel { get; set; }

        [JsonProperty("confidence_street_level")]
        public long ConfidenceStreetLevel { get; set; }

        [JsonProperty("match_type")]
        public string MatchType { get; set; }
    }

    public partial class Timezone
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offset_STD")]
        public string OffsetStd { get; set; }

        [JsonProperty("offset_STD_seconds")]
        public long OffsetStdSeconds { get; set; }

        [JsonProperty("offset_DST")]
        public string OffsetDst { get; set; }

        [JsonProperty("offset_DST_seconds")]
        public long OffsetDstSeconds { get; set; }

        [JsonProperty("abbreviation_STD")]
        public string AbbreviationStd { get; set; }

        [JsonProperty("abbreviation_DST")]
        public string AbbreviationDst { get; set; }
    }

    public partial class IAdressApiResult
    {
        public static IAdressApiResult FromJson(string json) => JsonConvert.DeserializeObject<IAdressApiResult>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this IAdressApiResult self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
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
    }
}

