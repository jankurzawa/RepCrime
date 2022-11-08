namespace RepCrime.LawEnforcement.DATA.DAL.Intefaces
{
    public interface ILawEnforecementRepository
    {
        Task<LawEnforcementEntity> GetTheLeastLoadedLawEnforecementAsync(RankOfLawEnforcement rank);
    }
}