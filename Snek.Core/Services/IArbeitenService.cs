using Snek.Core.Models;

namespace Snek.Core.Services;

public interface IArbeitenService
{
    Task<IReadOnlyList<Arbeiten>> GetByMitwirkendeAsync(
        int mitwirkendeId,
        CancellationToken cancellationToken = default);
}
