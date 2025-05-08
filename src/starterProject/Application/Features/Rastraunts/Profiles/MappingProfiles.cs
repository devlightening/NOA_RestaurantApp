using Application.Features.Rastraunts.Commands.Create;
using Application.Features.Rastraunts.Commands.Delete;
using Application.Features.Rastraunts.Commands.Update;
using Application.Features.Rastraunts.Queries.GetById;
using Application.Features.Rastraunts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Rastraunts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Restraunt, CreateRastrauntCommand>().ReverseMap();
        CreateMap<Restraunt, CreatedRastrauntResponse>().ReverseMap();
        CreateMap<Restraunt, UpdateRastrauntCommand>().ReverseMap();
        CreateMap<Restraunt, UpdatedRastrauntResponse>().ReverseMap();
        CreateMap<Restraunt, DeleteRastrauntCommand>().ReverseMap();
        CreateMap<Restraunt, DeletedRastrauntResponse>().ReverseMap();
        CreateMap<Restraunt, GetByIdRastrauntResponse>().ReverseMap();
        CreateMap<Restraunt, GetListRastrauntListItemDto>().ReverseMap();
        CreateMap<IPaginate<Restraunt>, GetListResponse<GetListRastrauntListItemDto>>().ReverseMap();
    }
}