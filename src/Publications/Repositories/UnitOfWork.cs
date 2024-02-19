namespace Publications.Repositories
{
    public class UnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPublicationRepository _publicationRepository;

        public UnitOfWork(ApplicationDbContext dbContext, IPublicationRepository publicationRepository)
        {
            _dbContext = dbContext;
            _publicationRepository = publicationRepository;
        }

        public IPublicationRepository PublicationRepository => _publicationRepository;

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
