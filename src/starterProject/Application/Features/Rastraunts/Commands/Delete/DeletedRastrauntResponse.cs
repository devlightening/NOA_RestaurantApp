using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rastraunts.Commands.Delete;

public class DeletedRastrauntResponse : IResponse
{
    public Guid Id { get; set; }
}