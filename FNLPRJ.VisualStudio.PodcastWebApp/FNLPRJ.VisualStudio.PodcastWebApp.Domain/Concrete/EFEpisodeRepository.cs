using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Abstract;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Entities;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Domain.Concrete
{
    public class EFEpisodeRepository : IEpisodeRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Episode> Episodes
        {
            get { return context.Episodes; }
        }
    }
}
