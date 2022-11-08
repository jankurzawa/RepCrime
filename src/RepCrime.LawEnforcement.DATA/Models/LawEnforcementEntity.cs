namespace RepCrime.LawEnforcement.DATA.Models
{
    public class LawEnforcementEntity
    {
        [Key]
        public Guid Id { get; set; }
        public RankOfLawEnforcement Rank { get; set; }
        public List<AssignCrime> AssignedCrimes { get; set; }

        public LawEnforcementEntity() { }
        
        public LawEnforcementEntity(RankOfLawEnforcement rank)
        {
            Id = Guid.NewGuid();
            Rank = rank;
            AssignedCrimes = new List<AssignCrime>();
        }
    }
}
