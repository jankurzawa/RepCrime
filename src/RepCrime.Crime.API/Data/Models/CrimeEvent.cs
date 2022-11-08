namespace RepCrime.Crime.API.Data.Models
{
    public class CrimeEvent
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public Guid IdToFind { get; set; }
        public DateTime Date { get; set; }
        public CrimeType Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid? IdOfAssignedLawEnforcement { get; set; }
        public CrimeEvent()
            => IdToFind = Guid.NewGuid();
    }
}
