using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rastraunts.Queries.GetById;

public class GetByIdRastrauntResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}