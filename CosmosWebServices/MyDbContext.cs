using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace CosmosWebServices.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<SearchData> SearchDatas { get; set; }
        public DbSet<DnoXRef> DnoXRefs { get; set; }
        public DbSet<DrawingIndex> DrawingIndexes { get; set; }
        public DbSet<AsBuiltDrawing> AsBuiltDrawings { get; set; }
        public DbSet<LegalPlanDrawing> LegalPlanDrawings { get; set; }
        public DbSet<PostingPlan> PostingPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasNoKey();
            modelBuilder.Entity<SearchData>().HasNoKey();
            modelBuilder.Entity<DnoXRef>().HasNoKey();
            modelBuilder.Entity<DrawingIndex>().HasNoKey();
            modelBuilder.Entity<AsBuiltDrawing>().HasNoKey();
            modelBuilder.Entity<LegalPlanDrawing>().HasNoKey();
            modelBuilder.Entity<PostingPlan>().HasNoKey();
        }
    }
}
