namespace RepCrime.LawEnforcement.DATA.Models
{
    public class AssignCrime
    {
        [Key]
        public string Id { get; set; }
        public Guid LawEnforcementEntityId { get; set; }
        public LawEnforcementEntity LawEnforcementEntity { get; set; }

        public AssignCrime(string id, Guid lawEnforcementEntityId)
        {
            Id = id;
            LawEnforcementEntityId = lawEnforcementEntityId;
        }
    }
}
