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
        CreateMap<Restaurant, CreateRastrauntCommand>().ReverseMap();
        CreateMap<Restaurant, CreatedRastrauntResponse>().ReverseMap();
        CreateMap<Restaurant, UpdateRastrauntCommand>().ReverseMap();
        CreateMap<Restaurant, UpdatedRastrauntResponse>().ReverseMap();
        CreateMap<Restaurant, DeleteRastrauntCommand>().ReverseMap();
        CreateMap<Restaurant, DeletedRastrauntResponse>().ReverseMap();
        CreateMap<Restaurant, GetByIdRastrauntResponse>().ReverseMap();
        CreateMap<Restaurant, GetListRastrauntListItemDto>().ReverseMap();
        CreateMap<IPaginate<Restaurant>, GetListResponse<GetListRastrauntListItemDto>>().ReverseMap();
    }
}