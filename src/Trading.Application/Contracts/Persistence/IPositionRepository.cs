using Trading.Domain.Entities;

namespace Trading.Application.Contracts.Persistence
{
    public interface IPositionRepository 
    {
        Task<IList<Position>> GetAllAsync();
        Task<Position> AddAsync(Position entity);
        Task<IEnumerable<Position>> GetPositionsByTradeId(long tradeId);
    }
}
