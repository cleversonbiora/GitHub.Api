using GitHub.Domain.Interfaces.Infra;
using GitHub.Domain.Models;
using System;
using Dapper;
using System.Data;
using System.Linq;

namespace GitHub.Infra.Repositories
{
    public partial class RepositoryRepository : BaseRepository, IRepositoryRepository
    {
        public Repository GetById(int id)
        {
            return _conn.Query<Repository>(QuerySelectById, new { Id = id }).FirstOrDefault();
        }

        public bool Upsert(Repository model)
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
