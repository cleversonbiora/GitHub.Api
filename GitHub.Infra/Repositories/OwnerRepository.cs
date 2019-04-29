using GitHub.Domain.Interfaces.Infra;
using GitHub.Domain.Models;
using System;
using Dapper;
using System.Data;
using System.Linq;

namespace GitHub.Infra.Repositories
{
    public partial class OwnerRepository : BaseRepository, IOwnerRepository
    {
        public Owner GetById(int id)
        {
            return _conn.Query<Owner>(QuerySelectById, new { Id = id }).FirstOrDefault();
        }

        public bool Upsert(Owner model)
        {
            IDbTransaction trans = _conn.BeginTransaction();
            try
            {
                _conn.Query(QueryUpdate, model, trans); 

                trans.Commit();

                return true;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        
    }
}
