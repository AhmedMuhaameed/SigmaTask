using Microsoft.EntityFrameworkCore;
using SigmaTask.Entities.Models;

namespace SigmaTask.Domain
{
    public class SigmaDBContext: DbContext
    {
        public SigmaDBContext(DbContextOptions<SigmaDBContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }

    }
}
