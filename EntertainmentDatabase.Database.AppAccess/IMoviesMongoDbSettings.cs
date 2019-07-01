namespace EntertainmentDatabase.Database.AppAccess
{
    public interface IMoviesMongoDbSettings
    {
        string MoviesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}