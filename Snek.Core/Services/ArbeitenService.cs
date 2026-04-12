using Snek.Core.Models;
using Snek.Core.Repositories;

namespace Snek.Core.Services;

public sealed class ArbeitenService(IPosRepository repository) : IArbeitenService
{
    public Task<IReadOnlyList<Arbeiten>> GetByMitwirkendeAsync(
        int mitwirkendeId,
        CancellationToken cancellationToken = default) =>
        repository.GetArbeitenAsync(mitwirkendeId, cancellationToken);
}
