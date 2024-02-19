using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Publications.Entities;
using Publications.Repositories.Interfaces;

namespace Publications.Repositories
{
    public class PublicationRepository : IPublicationRepository
    {
        private readonly ApplicationDbContext _context;
        public PublicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publication>> GetAllPublications()
        {
            return await _context.Publications
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<Publication> GetPublicationById(long id)
        {
            var publication = await _context.Publications
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
            return publication;
        }

        public void InsertPublication(Publication publication)
        {
            _context.Publications.Add(publication);
        }

        public async Task UpdatePublication(long id, Publication publication)
        {
            var entity = await _context.Publications.FindAsync(id);
            if (entity != null) {
                entity.AuthorId = publication.AuthorId;
                _context.Publications.Update(entity);
            }
        }

        public async Task DeletePublication(long id)
        {
            var publication = await _context.Publications.FindAsync(id);
            if (publication != null)
            {
                _context.Publications.Remove(publication);
            }
        }
    }
}
