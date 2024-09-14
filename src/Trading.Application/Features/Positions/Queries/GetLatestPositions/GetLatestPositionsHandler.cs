using AutoMapper;
using MediatR;
using Trading.Application.Contracts.Persistence;
using Trading.Application.Features.Positions.Queries.GetLatestPositions;

namespace Trading.Application.Features.Positions.Queries.GetPositionList
{
    public class GetLatestPositionsHandler : IRequestHandler<GetLatestPositionsQuery, List<LatestPosition>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public GetLatestPositionsHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<List<LatestPosition>> Handle(GetLatestPositionsQuery request, CancellationToken cancellationToken)
        {
            var updateList = new List<LatestPosition>();
            var positionList = await _positionRepository.GetAllAsync();

            var positionsByCode = positionList.GroupBy(x => x.SecurityCode).ToList();

            foreach (var position in positionsByCode)
            {
                long quantity = 0;

                foreach (var item in position)
                {
                    if (item.Operation == Domain.Enums.Operation.Cancel)
                    {
                        quantity = 0;
                        break;
                    }
                    else if (item.Operation == Domain.Enums.Operation.Update)
                    {
                        quantity = item.Quantity;
                    }
                    else
                    {
                        quantity += item.Action == Domain.Enums.TradingType.Buy ? item.Quantity : -item.Quantity;
                    }
                }
                updateList.Add(new LatestPosition { SecurityCode = position.Key, Quantity = quantity });
            }

            return _mapper.Map<List<LatestPosition>>(updateList);
        }
    }
}
