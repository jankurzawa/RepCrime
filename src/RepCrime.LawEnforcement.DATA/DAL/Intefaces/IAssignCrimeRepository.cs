namespace RepCrime.LawEnforcement.DATA.DAL.Intefaces
{
    public interface IAssignCrimeRepository
    {
        Task AddNewCrimeRepositoryAsync(AssignCrime entity);
    }
}