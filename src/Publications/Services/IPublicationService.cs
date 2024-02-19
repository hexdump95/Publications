using Publications.Entities;

namespace Publications.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> GetAllPublications();
        Task<Publication> GetPublicationById(long id);
        Task InsertPublication(Publication publication);
        Task UpdatePublication(long id, Publication publication);
        Task DeletePublication(long id);
        Task SaveChanges();
    }
}
