﻿using Registar.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.Factory.Interfaces
{
    public interface IDataContextFactory
    {
        TDataContext CreateDataContext<TDataContext>() where TDataContext : IDataContext;
    }
}
