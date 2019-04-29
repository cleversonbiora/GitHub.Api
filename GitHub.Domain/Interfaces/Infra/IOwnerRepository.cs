using GitHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.Interfaces.Infra
{
    public interface IOwnerRepository
    {
        Owner GetById(int id);
        bool Upsert(Owner model);
    }
}
