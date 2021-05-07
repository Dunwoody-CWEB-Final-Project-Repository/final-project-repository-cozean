using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Entities;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Domain.Abstract
{
    public interface IEpisodeRepository
    {
        IEnumerable<Episode> Episodes { get; }
    }
}
