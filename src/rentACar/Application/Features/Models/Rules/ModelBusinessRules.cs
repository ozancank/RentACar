using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Models.Rules;

public class ModelBusinessRules
{
    private readonly IModelRepository _modelRepository;

    public ModelBusinessRules(IModelRepository modelRepository, IBrandRepository brandRepository)
    {
        _modelRepository = modelRepository;
    }

    public async Task ModelNameOfBrandCanNotBeDuplicatedWhenInserted(string name, int brandId)
    {
        var result = await _modelRepository.GetListAsync(x => x.BrandId == brandId && x.Name == name);
        var a = result.Items.Any();
        if (result.Items.Any()) throw new BusinessException("Model name exists.");
    }
}