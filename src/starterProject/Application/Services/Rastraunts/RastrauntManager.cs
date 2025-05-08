using Application.Features.Rastraunts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rastraunts;

public class RastrauntManager : IRastrauntService
{
    private readonly IRastrauntRepository _rastrauntRepository;
    private readonly RastrauntBusinessRules _rastrauntBusinessRules;

    public RastrauntManager(IRastrauntRepository rastrauntRepository, RastrauntBusinessRules rastrauntBusinessRules)
    {
        _rastrauntRepository = rastrauntRepository;
        _rastrauntBusinessRules = rastrauntBusinessRules;
    }

    public async Task<Restaurant?> GetAsync(
        Expression<Func<Restaurant, bool>> predicate,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Restaurant? rastraunt = await _rastrauntRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rastraunt;
    }

    public async Task<IPaginate<Restaurant>?> GetListAsync(
        Expression<Func<Restaurant, bool>>? predicate = null,
        Func<IQueryable<Restaurant>, IOrderedQueryable<Restaurant>>? orderBy = null,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Restaurant> rastrauntList = await _rastrauntRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return rastrauntList;
    }

    public async Task<Restaurant> AddAsync(Restaurant rastraunt)
    {
        Restaurant addedRastraunt = await _rastrauntRepository.AddAsync(rastraunt);

        return addedRastraunt;
    }

    public async Task<Restaurant> UpdateAsync(Restaurant rastraunt)
    {
        Restaurant updatedRastraunt = await _rastrauntRepository.UpdateAsync(rastraunt);

        return updatedRastraunt;
    }

    public async Task<Restaurant> DeleteAsync(Restaurant rastraunt, bool permanent = false)
    {
        Restaurant deletedRastraunt = await _rastrauntRepository.DeleteAsync(rastraunt);

        return deletedRastraunt;
    }
}
