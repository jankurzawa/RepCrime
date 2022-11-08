namespace RepCrime.LawEnforcement.DATA.DAL
{
    public class AssignCrimeRepository : IAssignCrimeRepository
    {
        private readonly RepCrimeLawEnforcementContext _context;
        public AssignCrimeRepository(RepCrimeLawEnforcementContext context)
            => _context = context;

        public async Task AddNewCrimeRepositoryAsync(AssignCrime entity)
        {
            await _context.AssignCrimes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
