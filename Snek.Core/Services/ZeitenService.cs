using Snek.Core.Models;
using Snek.Core.Repositories;

namespace Snek.Core.Services;

public sealed class ZeitenService(IPosRepository repository) : IZeitenService
{
    public Task<IReadOnlyList<Zeiten>> GetByArbeitenAsync(
        int arbeitenId,
        CancellationToken cancellationToken = default) =>
        repository.GetZeitenAsync(arbeitenId, cancellationToken);

    public Task<IReadOnlyList<Zeiten>> GetAllAsync(CancellationToken cancellationToken = default) =>
        repository.GetAllZeitenAsync(cancellationToken);
}
