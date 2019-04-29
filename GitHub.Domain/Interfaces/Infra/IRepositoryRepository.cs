using GitHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.Interfaces.Infra
{
    public interface IRepositoryRepository
    {
        Repository GetById(int id);
        bool Upsert(Repository model);
    }
}
