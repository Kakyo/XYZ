namespace XYZ.Repository
{
    using XYZ.Interfaces.Repositories;
    using XYZ.Repository.Implementations;

    public static class RepositoryFactory
    {
        private static Dal.Context _dbContext;
        static RepositoryFactory()
        {
            System.Data.Entity.Database.SetInitializer(new Dal.ContextInitializer());

            RepositoryFactory._dbContext = new Dal.Context();
            RepositoryFactory._dbContext.Database.Initialize(false);
        }

        static IContatoRepository _contatoRepo;
        public static IContatoRepository ContatoRepository
        {
            get
            {
                return _contatoRepo = _contatoRepo
                    ?? new ContatoRepository(RepositoryFactory._dbContext);
            }
        }
    }
}
