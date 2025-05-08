using Application.Features.Rastraunts.Constants;
using Application.Features.Rastraunts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Rastraunts.Commands.Delete;

public class DeleteRastrauntCommand : IRequest<DeletedRastrauntResponse>
{
    public Guid Id { get; set; }

    public class DeleteRastrauntCommandHandler : IRequestHandler<DeleteRastrauntCommand, DeletedRastrauntResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRastrauntRepository _rastrauntRepository;
        private readonly RastrauntBusinessRules _rastrauntBusinessRules;

        public DeleteRastrauntCommandHandler(IMapper mapper, IRastrauntRepository rastrauntRepository,
                                         RastrauntBusinessRules rastrauntBusinessRules)
        {
            _mapper = mapper;
            _rastrauntRepository = rastrauntRepository;
            _rastrauntBusinessRules = rastrauntBusinessRules;
        }

        public async Task<DeletedRastrauntResponse> Handle(DeleteRastrauntCommand request, CancellationToken cancellationToken)
        {
            Restraunt? rastraunt = await _rastrauntRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rastrauntBusinessRules.RastrauntShouldExistWhenSelected(rastraunt);

            await _rastrauntRepository.DeleteAsync(rastraunt!);

            DeletedRastrauntResponse response = _mapper.Map<DeletedRastrauntResponse>(rastraunt);
            return response;
        }
    }
}