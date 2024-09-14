using Trading.Domain.Enums;

namespace Trading.Application.Features.Positions.Queries.GetPositionsByTradeId
{
    public class PositionModel
    {
        public long TransactionId { get; set; }
        public long TradeId { get; set; }
        public long Version { get; set; }
        public required string SecurityCode { get; set; }
        public long Quantity { get; set; }
        public TradingType Action { get; set; }
        public Operation Operation { get; set; }
    }
}
