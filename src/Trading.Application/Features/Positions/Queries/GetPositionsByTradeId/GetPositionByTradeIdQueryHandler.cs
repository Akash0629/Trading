using AutoMapper;
using MediatR;
using Trading.Application.Contracts.Persistence;
using Trading.Application.Features.Positions.Queries.GetPositionList;

namespace Trading.Application.Features.Positions.Queries.GetPositionsByTradeId
{
    public class GetPositionByTradeIdQueryHandler : IRequestHandler<GetPositionByTradeIdQuery, List<PositionModel>>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public GetPositionByTradeIdQueryHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<List<PositionModel>> Handle(GetPositionByTradeIdQuery request, CancellationToken cancellationToken)
        {
            var positions = await _positionRepository.GetPositionsByTradeId(request.TradeId);
            return _mapper.Map<List<PositionModel>>(positions);
        }
    }
}
