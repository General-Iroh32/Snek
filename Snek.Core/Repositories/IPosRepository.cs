using Snek.Core.Models;

namespace Snek.Core.Repositories;

public interface IPosRepository
{
    Task<IReadOnlyList<Mitwirkende>> GetMitwirkendeAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Arbeiten>> GetArbeitenAsync(
        int mitwirkendeId,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Zeiten>> GetZeitenAsync(
        int arbeitenId,
        CancellationToken cancellationToken = default);
}
