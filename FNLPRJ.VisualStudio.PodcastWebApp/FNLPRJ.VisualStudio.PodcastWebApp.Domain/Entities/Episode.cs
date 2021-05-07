using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Domain.Entities
{
    public class Episode
    {
        public int episodeNumber { get; set; }
        public string soundFileLocation { get; set; }
        public string description { get; set; }
        public string picFileLocation { get; set; }
    }
}
