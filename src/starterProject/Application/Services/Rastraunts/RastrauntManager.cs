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

    public async Task<Restraunt?> GetAsync(
        Expression<Func<Restraunt, bool>> predicate,
        Func<IQueryable<Restraunt>, IIncludableQueryable<Restraunt, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Restraunt? rastraunt = await _rastrauntRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rastraunt;
    }

    public async Task<IPaginate<Restraunt>?> GetListAsync(
        Expression<Func<Restraunt, bool>>? predicate = null,
        Func<IQueryable<Restraunt>, IOrderedQueryable<Restraunt>>? orderBy = null,
        Func<IQueryable<Restraunt>, IIncludableQueryable<Restraunt, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Restraunt> rastrauntList = await _rastrauntRepository.GetListAsync(
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

    public async Task<Restraunt> AddAsync(Restraunt rastraunt)
    {
        Restraunt addedRastraunt = await _rastrauntRepository.AddAsync(rastraunt);

        return addedRastraunt;
    }

    public async Task<Restraunt> UpdateAsync(Restraunt rastraunt)
    {
        Restraunt updatedRastraunt = await _rastrauntRepository.UpdateAsync(rastraunt);

        return updatedRastraunt;
    }

    public async Task<Restraunt> DeleteAsync(Restraunt rastraunt, bool permanent = false)
    {
        Restraunt deletedRastraunt = await _rastrauntRepository.DeleteAsync(rastraunt);

        return deletedRastraunt;
    }
}
