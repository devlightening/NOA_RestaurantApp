using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Rastraunts.Queries.GetList;

public class GetListRastrauntQuery : IRequest<GetListResponse<GetListRastrauntListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRastrauntQueryHandler : IRequestHandler<GetListRastrauntQuery, GetListResponse<GetListRastrauntListItemDto>>
    {
        private readonly IRastrauntRepository _rastrauntRepository;
        private readonly IMapper _mapper;

        public GetListRastrauntQueryHandler(IRastrauntRepository rastrauntRepository, IMapper mapper)
        {
            _rastrauntRepository = rastrauntRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRastrauntListItemDto>> Handle(GetListRastrauntQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Restraunt> rastraunts = await _rastrauntRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRastrauntListItemDto> response = _mapper.Map<GetListResponse<GetListRastrauntListItemDto>>(rastraunts);
            return response;
        }
    }
}