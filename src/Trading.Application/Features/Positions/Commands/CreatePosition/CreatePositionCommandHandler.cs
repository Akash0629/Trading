using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trading.Application.Contracts.Persistence;
using Trading.Domain.Entities;


namespace Trading.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly ILogger<CreatePositionCommand> _logger;

        public CreatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper, ILogger<CreatePositionCommand> logger)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var positionEntity = _mapper.Map<Position>(request);

            var positionList = await _positionRepository.GetAllAsync();
            if (positionList.Count > 0)
            {
                var currentVersion = positionList.FirstOrDefault(x => x.TradeId == positionEntity.TradeId)?.Version ?? 0;
                positionEntity.Version = currentVersion + 1;
            }
            else
            {
                positionEntity.Version = 1;
            }
            var newPosition = await _positionRepository.AddAsync(positionEntity);

            _logger.LogInformation($"Position {newPosition.TransactionId} is successfully created.");

            return newPosition.TransactionId > 0 ? true : false;
        }
    }
}
