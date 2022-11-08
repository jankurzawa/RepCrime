namespace RepCrime.LawEnforcement.DATA.Context
{
    public class RepCrimeLawEnforcementContext : DbContext
    {
        public DbSet<LawEnforcementEntity> LawEnforcements { get; set; }
        public DbSet<AssignCrime> AssignCrimes { get; set; }

        public RepCrimeLawEnforcementContext(DbContextOptions<RepCrimeLawEnforcementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }
    }
}
