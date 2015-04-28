using Registar.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registar.DataLayer
{
    public interface IDataContext:IDisposable
    {
        /// <summary>
        /// Returns set of TEntity elements
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> GetIDBSet<TEntity>() where TEntity : class, IsEntity;
        int SaveChanges();
    }
}
