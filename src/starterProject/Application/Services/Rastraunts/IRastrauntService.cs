using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rastraunts;

public interface IRastrauntService
{
    Task<Restraunt?> GetAsync(
        Expression<Func<Restraunt, bool>> predicate,
        Func<IQueryable<Restraunt>, IIncludableQueryable<Restraunt, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Restraunt>?> GetListAsync(
        Expression<Func<Restraunt, bool>>? predicate = null,
        Func<IQueryable<Restraunt>, IOrderedQueryable<Restraunt>>? orderBy = null,
        Func<IQueryable<Restraunt>, IIncludableQueryable<Restraunt, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Restraunt> AddAsync(Restraunt rastraunt);
    Task<Restraunt> UpdateAsync(Restraunt rastraunt);
    Task<Restraunt> DeleteAsync(Restraunt rastraunt, bool permanent = false);
}
