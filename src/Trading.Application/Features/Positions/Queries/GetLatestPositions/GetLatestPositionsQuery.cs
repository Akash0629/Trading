using MediatR;

namespace Trading.Application.Features.Positions.Queries.GetLatestPositions
{
    public class GetLatestPositionsQuery : IRequest<List<LatestPosition>>
    {
    }
}
