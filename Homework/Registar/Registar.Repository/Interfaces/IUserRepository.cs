using Registar.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Repository.Interfaces
{
    public interface IUserRepository : IRepository
    {
        bool UpdateProfileData();
    }
}
