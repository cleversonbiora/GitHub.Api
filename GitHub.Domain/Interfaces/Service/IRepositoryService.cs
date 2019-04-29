using GitHub.Domain.Models;
using GitHub.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using GitHub.Domain.ViewModel;
using System.Threading.Tasks;

namespace GitHub.Domain.Interfaces.Service
{
    public interface IRepositoryService
    {
        Task<RepositoryViewModel> Get(int id);
        Task<List<RepositoryResumeViewModel>> ListTop(string language, int qtd);
    }
}
