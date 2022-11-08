namespace RepCrime.LawEnforcement.DATA.Seeders
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<LawEnforcementEntity> lawEnforcements = new List<LawEnforcementEntity>()
            {
                new LawEnforcementEntity(RankOfLawEnforcement.Investigation),
                new LawEnforcementEntity(RankOfLawEnforcement.Criminal),
                new LawEnforcementEntity(RankOfLawEnforcement.Asset_Recovery)
            };

            modelBuilder.Entity<LawEnforcementEntity>()
                .HasData(lawEnforcements);
        }
    }
}
