namespace RepCrime.MVC.Services.Interfaces
{
    public interface ICrimeService
    {
        Task AddNew(CreateCrimeDTO crimeDTO);
    }
}