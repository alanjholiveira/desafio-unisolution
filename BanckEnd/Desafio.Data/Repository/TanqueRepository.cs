using Desafio.Data.DBContext;
using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;

namespace Desafio.Data.Repository
{
    public class TanqueRepository : RepositoryBase<Tanque>, ITanqueRepository
    {
        private readonly MySqlContext _context;
        public TanqueRepository(MySqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
