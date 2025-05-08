using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Rastraunts.Queries.GetList;

public class GetListRastrauntListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}