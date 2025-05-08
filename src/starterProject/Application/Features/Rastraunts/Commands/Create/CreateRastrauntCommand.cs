using Application.Features.Rastraunts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rastraunts.Commands.Create;

public class CreateRastrauntCommand : IRequest<CreatedRastrauntResponse>
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public class CreateRastrauntCommandHandler : IRequestHandler<CreateRastrauntCommand, CreatedRastrauntResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRastrauntRepository _rastrauntRepository;
        private readonly RastrauntBusinessRules _rastrauntBusinessRules;

        public CreateRastrauntCommandHandler(IMapper mapper, IRastrauntRepository rastrauntRepository,
                                         RastrauntBusinessRules rastrauntBusinessRules)
        {
            _mapper = mapper;
            _rastrauntRepository = rastrauntRepository;
            _rastrauntBusinessRules = rastrauntBusinessRules;
        }

        public async Task<CreatedRastrauntResponse> Handle(CreateRastrauntCommand request, CancellationToken cancellationToken)
        {
            Restaurant rastraunt = _mapper.Map<Restaurant>(request);

            await _rastrauntRepository.AddAsync(rastraunt);

            CreatedRastrauntResponse response = _mapper.Map<CreatedRastrauntResponse>(rastraunt);
            return response;
        }
    }
}