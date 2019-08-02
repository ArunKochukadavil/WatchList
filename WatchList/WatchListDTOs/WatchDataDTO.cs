namespace WatchListDTOs
{
    public class WatchDataDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public byte Season { get; set; }
        public int TotalEpisodes { get; set; }
        public int EpisodesCompleted { get; set; }
        public string Status { get; set; }
    }
}
