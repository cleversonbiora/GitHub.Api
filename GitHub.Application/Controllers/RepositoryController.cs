using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using GitHub.Domain.Interfaces.Service;
using GitHub.Domain.Models;
using FluentValidation;
using GitHub.Domain.Commands.Sample;
using GitHub.CrossCutting.Attributes;

//https://api.github.com/search/repositories?q=language:css&sort=stars&order=desc&per_page=10

namespace GitHub.Application.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[Controller]")]
    public class RepositoryController : BaseController
    {
        private readonly IRepositoryService _repositoryService;

        public RepositoryController(IRepositoryService repositoryService) => _repositoryService = repositoryService;

        [AllowAnonymous, HttpGet("ListTop")]
        public async Task<IActionResult> ListTop(string language, int qtd) => Response(await _repositoryService.ListTop(language,qtd));

        //[TestAutmated(1)]
        [AllowAnonymous, HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Response(await _repositoryService.Get(id)); //All Exception are manipulated on ResponseExceptionHandler, no nedeed add try/catch on controller.
    }
}
