using Trading.Domain.Enums;

namespace Trading.Application.Features.Positions.Queries.GetAllPosition
{
    public class GetAllPosition
    {
        public long TransactionId { get; set; }
        public long TradeId { get; set; }
        public long Version { get; set; }
        public required string SecurityCode { get; set; }
        public long Quantity { get; set; }

        public string Action { get; set; }
        public string Operation { get; set; }
    }
}
