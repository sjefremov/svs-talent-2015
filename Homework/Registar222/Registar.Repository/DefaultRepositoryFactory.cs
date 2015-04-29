using Registar.Common.Interfaces;
using Registar.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Repository
{
    public class DefaultRepositoryFactory : IRepositoryFactory
    {

        public TRepository CreateRepository<TRepository>() where TRepository : IRepository
        {
            if (typeof(TRepository) == typeof(IBikeRepository))
            {
                return (TRepository)(object)new BikeRepository();
            }
            if (typeof(TRepository) == typeof(IUserRepository))
            {
                return (TRepository)(object)new UserRepository();
            }

            return default(TRepository);
        }
    }
}
