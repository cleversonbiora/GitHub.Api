using FluentValidation;
using GitHub.Domain.Interfaces.Service;
using GitHub.Domain.Models;
using GitHub.Service.Validators;
using GitHub.Domain.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GitHub.Domain.Interfaces.Infra;
using GitHub.Domain.ViewModel;
using Refit;
using GitHub.CrossCutting.Apis;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;

namespace GitHub.Service.Services
{
    public class RepositoryService : BaseService, IRepositoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryRepository _repositoryRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IGitHubApi _githubService;

        public RepositoryService(IMapper mapper, IRepositoryRepository repositoryRepository, IOwnerRepository ownerRepository)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Environment.GetEnvironmentVariable("GitHubUrl")),
                DefaultRequestHeaders = { { "User-Agent", "GitHubApi" } }
            };
            _mapper = mapper;
            _repositoryRepository = repositoryRepository;
            _ownerRepository = ownerRepository;
            _githubService = RestService.For<IGitHubApi>(httpClient);
        }
        public async Task<List<RepositoryResumeViewModel>> ListTop(string language, int qtd)
        {
            var res = await _githubService.GetRepositories($"language:{language}","stars","desc",qtd);
            res.Items.ForEach(x => {
                    x.OwnerId = x.Owner.Id;
                    _repositoryRepository.Upsert(x);
                    _ownerRepository.Upsert(x.Owner);
                });
            return _mapper.Map<List<RepositoryResumeViewModel>>(res.Items);
        }
        public async Task<RepositoryViewModel> Get(int id)
        {
            Repository source = _repositoryRepository.GetById(id);
            source.Owner = _ownerRepository.GetById(source.OwnerId);
            ReadMe readMe = await _githubService.GetReadMe(source.Owner.Login, source.Name);
            source.ReadMe = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(readMe.Content));
            return _mapper.Map<RepositoryViewModel>(source); ;
        }

    }
}
