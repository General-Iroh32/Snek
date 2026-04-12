using Snek.Core.Models;

namespace Snek.Core.Services;

public interface IZeitenService
{
    Task<IReadOnlyList<Zeiten>> GetByArbeitenAsync(
        int arbeitenId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Zeiten>> GetAllAsync(CancellationToken cancellationToken = default);
}
