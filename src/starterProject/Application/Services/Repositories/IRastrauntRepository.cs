using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRastrauntRepository : IAsyncRepository<Restaurant, Guid>, IRepository<Restaurant, Guid>
{
}