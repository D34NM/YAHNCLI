using System;
using Newtonsoft.Json;

namespace HackerNews.Client.Models
{
    public struct Response
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("by")]
        public string By { get; set; }

        [JsonProperty("descendants")]
        public long Descendants { get; set; }

        [JsonProperty("kids")]
        public long[] Kids { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}