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

namespace GitHub.Service.Services
{
    public class SampleService : BaseService, ISampleService
    {
        private readonly IMapper _mapper;
        private readonly ISampleRepository _sampleRepository;

        public SampleService(IMapper mapper, ISampleRepository sampleRepository)
        {
            _mapper = mapper;
            _sampleRepository = sampleRepository;
        }

        public SampleViewModel Get(int id)
        {
            return _mapper.Map<SampleViewModel>(_sampleRepository.GetById(id));
        }
        
        public int Post(InsertSampleCommand sample)
        {
            Validate(sample, new InsertSampleValidator()); //Validations are realized on FluentValidation 
            return _sampleRepository.Insert(_mapper.Map<Sample>(sample));
        }

        public bool Put(UpdateSampleCommand sample)
        {
            Validate(sample, new UpdateSampleValidator());
            return _sampleRepository.Update(_mapper.Map<Sample>(sample));
        }

        public bool Delete(int id)
        {
            return _sampleRepository.Delete(id);
        }
    }
}
