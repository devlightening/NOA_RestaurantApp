using Application.Features.Rastraunts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rastraunts.Queries.GetById;

public class GetByIdRastrauntQuery : IRequest<GetByIdRastrauntResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRastrauntQueryHandler : IRequestHandler<GetByIdRastrauntQuery, GetByIdRastrauntResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRastrauntRepository _rastrauntRepository;
        private readonly RastrauntBusinessRules _rastrauntBusinessRules;

        public GetByIdRastrauntQueryHandler(IMapper mapper, IRastrauntRepository rastrauntRepository, RastrauntBusinessRules rastrauntBusinessRules)
        {
            _mapper = mapper;
            _rastrauntRepository = rastrauntRepository;
            _rastrauntBusinessRules = rastrauntBusinessRules;
        }

        public async Task<GetByIdRastrauntResponse> Handle(GetByIdRastrauntQuery request, CancellationToken cancellationToken)
        {
            Restraunt? rastraunt = await _rastrauntRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rastrauntBusinessRules.RastrauntShouldExistWhenSelected(rastraunt);

            GetByIdRastrauntResponse response = _mapper.Map<GetByIdRastrauntResponse>(rastraunt);
            return response;
        }
    }
}