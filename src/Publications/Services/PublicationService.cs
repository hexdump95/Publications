using Publications.Entities;
using Publications.Repositories;

namespace Publications.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly UnitOfWork _unitOfWork;

        public PublicationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Publication>> GetAllPublications()
        {
            return await _unitOfWork.PublicationRepository.GetAllPublications();
        }
        public async Task<Publication> GetPublicationById(long id)
        {
            return await _unitOfWork.PublicationRepository.GetPublicationById(id);
        }
        public async Task InsertPublication(Publication publication)
        {
            _unitOfWork.PublicationRepository.InsertPublication(publication);
            await _unitOfWork.Commit();
        }

        public async Task UpdatePublication(long id, Publication publication)
        {
            await _unitOfWork.PublicationRepository.UpdatePublication(id, publication);
            await _unitOfWork.Commit();
        }

        public async Task DeletePublication(long id)
        {
            var publication = await _unitOfWork.PublicationRepository.GetPublicationById(id);
            if (publication != null)
            {
                await _unitOfWork.PublicationRepository.DeletePublication(id);
                await _unitOfWork.Commit();
            }
        }

        public async Task SaveChanges()
        {
            await _unitOfWork.Commit();
        }
    }

}
