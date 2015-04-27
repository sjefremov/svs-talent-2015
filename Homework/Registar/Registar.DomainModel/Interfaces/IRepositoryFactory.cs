﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DomainModel.Interfaces
{
    public interface IRepositoryFactory
    {
        TRepository CreateRepository<TRepository>() where TRepository : IRepository;
    }
}
