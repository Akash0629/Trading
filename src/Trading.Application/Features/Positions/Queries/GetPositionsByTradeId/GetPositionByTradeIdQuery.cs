using MediatR;
using Trading.Application.Features.Positions.Queries.GetPositionList;

namespace Trading.Application.Features.Positions.Queries.GetPositionsByTradeId
{
    public class GetPositionByTradeIdQuery : IRequest<List<PositionModel>>
    {
        public long TradeId { get; set; }
        public GetPositionByTradeIdQuery(long tradeId)
        {
            TradeId = tradeId;
        }
    }
}
