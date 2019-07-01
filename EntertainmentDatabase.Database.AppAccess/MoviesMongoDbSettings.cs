namespace EntertainmentDatabase.Database.AppAccess
{
    public class MoviesMongoDbSettings : IMoviesMongoDbSettings
    {
        public string MoviesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}