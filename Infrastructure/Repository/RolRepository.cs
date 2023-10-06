using Core;
using Core.Interfaces;
using Infrastructure;

namespace Infrastructure.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        public RolRepository(BaseContext context) : base(context)
        {
        }
    }
}