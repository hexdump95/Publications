using Microsoft.EntityFrameworkCore.ChangeTracking;
using Publications.Entities;

namespace Publications.Repositories.Interfaces
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> GetAllPublications();
        Task<Publication> GetPublicationById(long id);
        void InsertPublication(Publication publication);
        Task UpdatePublication(long id, Publication publication);
        Task DeletePublication(long id);
    }
}
