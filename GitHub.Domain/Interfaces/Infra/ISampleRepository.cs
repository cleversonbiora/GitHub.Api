using GitHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Domain.Interfaces.Infra
{
    public interface ISampleRepository
    {
        int Insert(Sample sample);
        Sample GetById(int id);
        bool Update(Sample model);
        bool Delete(int id);
    }
}