using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Rastraunts;

public interface IRastrauntService
{
    Task<Restaurant?> GetAsync(
        Expression<Func<Restaurant, bool>> predicate,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Restaurant>?> GetListAsync(
        Expression<Func<Restaurant, bool>>? predicate = null,
        Func<IQueryable<Restaurant>, IOrderedQueryable<Restaurant>>? orderBy = null,
        Func<IQueryable<Restaurant>, IIncludableQueryable<Restaurant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Restaurant> AddAsync(Restaurant rastraunt);
    Task<Restaurant> UpdateAsync(Restaurant rastraunt);
    Task<Restaurant> DeleteAsync(Restaurant rastraunt, bool permanent = false);
}
