using Microsoft.EntityFrameworkCore;
using Trading.Application.Contracts.Persistence;
using Trading.Domain.Entities;
using Trading.Infrastructure.Persistence;

namespace Trading.Infrastructure.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        protected readonly DataBaseContext _dbContext;
        public PositionRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Position>> GetAllAsync()
        {
            return await _dbContext.Positions.ToListAsync();
        }

        public async Task<Position> AddAsync(Position entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Position>> GetPositionsByTradeId(long tradeId)
        {
            return await _dbContext.Positions
                        .Where(o => o.TradeId == tradeId)
                        .ToListAsync();
        }
    }
}
