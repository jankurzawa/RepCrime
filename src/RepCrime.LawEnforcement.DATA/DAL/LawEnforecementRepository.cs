namespace RepCrime.LawEnforcement.DATA.DAL
{
    public class LawEnforecementRepository : ILawEnforecementRepository
    {
        private readonly RepCrimeLawEnforcementContext _context;
        public LawEnforecementRepository(RepCrimeLawEnforcementContext context)
            => _context = context;

        public async Task<LawEnforcementEntity> GetTheLeastLoadedLawEnforecementAsync(RankOfLawEnforcement rank)
            => await _context.LawEnforcements.Include(le=>le.AssignedCrimes).Where(le => le.Rank == rank)
                .OrderBy(le => le.AssignedCrimes.Count).FirstOrDefaultAsync();
    }
}
