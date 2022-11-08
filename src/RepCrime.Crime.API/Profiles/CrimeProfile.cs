namespace RepCrime.Crime.API.Profiles
{
    public class CrimeProfile : Profile
    {
        public CrimeProfile()
        {
            CreateMap<CreateCrimeDTO, CrimeEvent>();
            CreateMap<CrimeEvent, AssignToLawEnforcementCrimeDTO>();
        }
    }
}
