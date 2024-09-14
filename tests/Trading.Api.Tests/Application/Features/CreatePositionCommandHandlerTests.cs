using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Trading.Application.Contracts.Persistence;
using Trading.Application.Features.Positions.Commands.CreatePosition;
using Trading.Domain.Entities;
using Xunit;

namespace Trading.Api.Tests.Application.Features
{
    public class CreatePositionCommandHandlerTests
    {

        private readonly Mock<IPositionRepository> _mockPositionRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<CreatePositionCommand>> _mockLogger;
        private readonly CreatePositionCommandHandler _handler;

        public CreatePositionCommandHandlerTests()
        {
            _mockPositionRepository = new Mock<IPositionRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockLogger = new Mock<ILogger<CreatePositionCommand>>();
            _handler = new CreatePositionCommandHandler(
                _mockPositionRepository.Object,
                _mockMapper.Object,
                _mockLogger.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldCreatePosition_WhenRequestIsValid()
        {
            // Arrange
            var command = new CreatePositionCommand
            {
                TradeId = 1,
                SecurityCode = "REL"
                // Set other properties as needed
            };

            var positionEntity = new Position
            {
                TradeId = command.TradeId,
                SecurityCode = command.SecurityCode,
                // Set other properties as needed
            };

            var newPosition = new Position
            {
                TransactionId = 1,
                SecurityCode = command.SecurityCode
            };

            _mockMapper.Setup(m => m.Map<Position>(command)).Returns(positionEntity);
            _mockPositionRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Position>
                {
                    new Position { TradeId = 1, Version = 1, SecurityCode = command.SecurityCode }
                });
            _mockPositionRepository.Setup(r => r.AddAsync(positionEntity))
                .ReturnsAsync(newPosition);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
            _mockMapper.Verify(m => m.Map<Position>(command), Times.Once);
            _mockPositionRepository.Verify(r => r.GetAllAsync(), Times.Once);
            _mockPositionRepository.Verify(r => r.AddAsync(positionEntity), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenTransactionIdIsZero()
        {
            // Arrange
            var command = new CreatePositionCommand
            {
                TradeId = 1 ,
                SecurityCode = "REL"
                // Set other properties as needed
            };

            var positionEntity = new Position
            {
                TradeId = command.TradeId,
                SecurityCode = command.SecurityCode,
                // Set other properties as needed
            };

            var newPosition = new Position
            {
                TransactionId = 0,
                SecurityCode = command.SecurityCode
                // Set other properties as needed
            };

            _mockMapper.Setup(m => m.Map<Position>(command)).Returns(positionEntity);
            _mockPositionRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(new List<Position>());
            _mockPositionRepository.Setup(r => r.AddAsync(positionEntity))
                .ReturnsAsync(newPosition);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeFalse();
            _mockMapper.Verify(m => m.Map<Position>(command), Times.Once);
            _mockPositionRepository.Verify(r => r.GetAllAsync(), Times.Once);
            _mockPositionRepository.Verify(r => r.AddAsync(positionEntity), Times.Once);
        }
    }
}
