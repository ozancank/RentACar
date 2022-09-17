using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Brand> result = await _brandRepository.GetListAsync(x => x.Name == name);
        if (result.Items.Any()) throw new BusinessException("Brand name exists");
    }

    public static void BrandShouldExistWhenRequested(Brand brand)
    {
        if (brand == null) throw new BusinessException("Requested brand does not exist");
    }
}