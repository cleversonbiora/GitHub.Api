using GitHub.Domain.Models;
using GitHub.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using GitHub.Domain.ViewModel;

namespace GitHub.Domain.Interfaces.Service
{
    public interface ISampleService
    {
        SampleViewModel Get(int id);
        int Post(InsertSampleCommand sample);
        bool Put(UpdateSampleCommand sample);
        bool Delete(int id);
    }
}
