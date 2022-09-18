using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.CreateModel;

public class CreateModelCommand : IRequest<CreateModelDto>
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelDto>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;
        private readonly ModelBusinessRules _modelBusinessRules;

        public CreateModelCommandHandler(IMapper mapper, IModelRepository modelRepository, ModelBusinessRules modelBusinessRules)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<CreateModelDto> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelNameOfBrandCanNotBeDuplicatedWhenInserted(request.Name, request.BrandId);

            var model = _mapper.Map<Model>(request);
            var createdModel = await _modelRepository.AddAsync(model);
            var createdModelDto = _mapper.Map<CreateModelDto>(createdModel);

            return createdModelDto;
        }
    }
}