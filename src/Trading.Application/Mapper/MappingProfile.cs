using AutoMapper;
using Trading.Application.Features.Positions.Commands.CreatePosition;
using Trading.Application.Features.Positions.Queries.GetAllPosition;
using Trading.Application.Features.Positions.Queries.GetLatestPositions;
using Trading.Domain.Entities;

namespace Trading.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Position, CreatePositionCommand>().ReverseMap();
            CreateMap<Position, LatestPosition>().ReverseMap();
            CreateMap<Position, GetAllPosition>().ReverseMap();
        }
    }
}
