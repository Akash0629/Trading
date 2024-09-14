using Trading.Domain.Common;
using Trading.Domain.Enums;

namespace Trading.Domain.Entities
{
    public class Position : EntityBase
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
