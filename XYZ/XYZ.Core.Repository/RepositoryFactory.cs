namespace XYZ.Repositories
{
    using XYZ.Interfaces.Repositories;
    using XYZ.Repositories.Implementations;

    public static class RepositoryFactory
    {
        static IParceiroRepository _parceiroRepo;
        public static IParceiroRepository ParceiroRepository
        {
            get
            {
                return _parceiroRepo = _parceiroRepo ?? new ParceiroRepository();
            }
        }

        static IContatoRepository _contatoRepo;
        public static IContatoRepository ContatoRepository
        {
            get
            {
                return _contatoRepo = _contatoRepo ?? new ContatoRepository();
            }
        }
    }
}
