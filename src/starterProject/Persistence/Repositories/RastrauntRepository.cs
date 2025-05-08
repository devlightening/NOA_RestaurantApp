using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RastrauntRepository : EfRepositoryBase<Restaurant, Guid, BaseDbContext>, IRastrauntRepository
{
    public RastrauntRepository(BaseDbContext context) : base(context)
    {
    }
}