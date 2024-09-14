using MediatR;
using Trading.Domain.Enums;

namespace Trading.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<bool>
    {
        public long TradeId { get; set; }
        public required string SecurityCode { get; set; }
        public long Quantity { get; set; }
        public TradingType Action { get; set; }
        public Operation Operation { get; set; }
    }
}
