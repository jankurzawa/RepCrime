namespace RepCrime.Crime.API.Data.DAL
{
    public class CrimeRepository
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _collection;

        public CrimeRepository(string connectionString, string databaseName, string collection)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
            _collection = collection;
        }
        private IMongoCollection<CrimeEvent> ConnectToMongo()
            => (new MongoClient(_connectionString).GetDatabase(_databaseName)).GetCollection<CrimeEvent>(_collection);

        public Task Create(CrimeEvent entity)
            => ConnectToMongo().InsertOneAsync(entity);

        public async Task<long> GetNumberOfAllEventsAsync()
            => ConnectToMongo().Find(_ => true).Count();

        public async Task<CrimeEvent> GetByIdToFindAsync(Guid idToFind)
            => (await ConnectToMongo().FindAsync(c => c.IdToFind == idToFind)).FirstOrDefault();

        public async Task UpdateAsync(CrimeEvent crimeEvent)
            => ConnectToMongo().ReplaceOneAsync(Builders<CrimeEvent>.Filter.Eq("Id", crimeEvent.Id), crimeEvent, new ReplaceOptions { IsUpsert = true });
    }
}
