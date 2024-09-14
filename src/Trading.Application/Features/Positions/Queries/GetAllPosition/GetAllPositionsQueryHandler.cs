using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trading.Application.Contracts.Persistence;


namespace Trading.Application.Features.Positions.Queries.GetAllPosition
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionQuery, List<GetAllPosition>>
    {

        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllPositionQuery> _logger;

        public GetAllPositionsQueryHandler(IPositionRepository positionRepository, IMapper mapper, ILogger<GetAllPositionQuery> logger)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<GetAllPosition>> Handle(GetAllPositionQuery request, CancellationToken cancellationToken)
        {
            var positionList = await _positionRepository.GetAllAsync();
            return _mapper.Map<List<GetAllPosition>>(positionList);
        }
    }
}
