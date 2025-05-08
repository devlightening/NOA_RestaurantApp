using Application.Features.Rastraunts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rastraunts.Commands.Update;

public class UpdateRastrauntCommand : IRequest<UpdatedRastrauntResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public class UpdateRastrauntCommandHandler : IRequestHandler<UpdateRastrauntCommand, UpdatedRastrauntResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRastrauntRepository _rastrauntRepository;
        private readonly RastrauntBusinessRules _rastrauntBusinessRules;

        public UpdateRastrauntCommandHandler(IMapper mapper, IRastrauntRepository rastrauntRepository,
                                         RastrauntBusinessRules rastrauntBusinessRules)
        {
            _mapper = mapper;
            _rastrauntRepository = rastrauntRepository;
            _rastrauntBusinessRules = rastrauntBusinessRules;
        }

        public async Task<UpdatedRastrauntResponse> Handle(UpdateRastrauntCommand request, CancellationToken cancellationToken)
        {
            Restaurant? rastraunt = await _rastrauntRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rastrauntBusinessRules.RastrauntShouldExistWhenSelected(rastraunt);
            rastraunt = _mapper.Map(request, rastraunt);

            await _rastrauntRepository.UpdateAsync(rastraunt!);

            UpdatedRastrauntResponse response = _mapper.Map<UpdatedRastrauntResponse>(rastraunt);
            return response;
        }
    }
}