using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListDTOs
{
    public class WatchData
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public byte Season { get; set; }
        public int TotalEpisode { get; set; }
        public int EpisodesCompleted { get; set; }
        public string Status { get; set; }
    }
}
