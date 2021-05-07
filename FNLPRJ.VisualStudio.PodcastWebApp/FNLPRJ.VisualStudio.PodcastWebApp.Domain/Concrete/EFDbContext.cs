using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FNLPRJ.VisualStudio.PodcastWebApp.Domain.Entities;
using System.Data.Entity;

namespace FNLPRJ.VisualStudio.PodcastWebApp.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; }
    }
}
