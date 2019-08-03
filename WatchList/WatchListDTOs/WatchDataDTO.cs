using Newtonsoft.Json;

namespace WatchListDTOs
{
    public class WatchDataDTO
    {
        [JsonProperty(Order = 1)]
        public int ID { get; set; }

        [JsonProperty(Order = 2)]
        public string Name { get; set; }

        [JsonProperty(Order = 3)]
        public string Genre { get; set; }

        [JsonProperty(Order = 4)]
        public byte Season { get; set; }

        [JsonProperty(Order = 5)]
        public int TotalEpisodes { get; set; }

        [JsonProperty(Order = 6)]
        public int EpisodesCompleted { get; set; }

        [JsonProperty(Order = 7)]
        public string Status { get; set; }

        [JsonProperty(Order = 8)]
        public byte Reviews { get; set; }

        [JsonProperty(Order = 9)]
        public string Description { get; set; }

        [JsonProperty(Order = 10)]
        public string DownloadLinks { get; set; }
    }
}
