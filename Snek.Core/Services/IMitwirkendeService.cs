using Snek.Core.Models;

namespace Snek.Core.Services;

public interface IMitwirkendeService
{
    Task<IReadOnlyList<Mitwirkende>> GetAllAsync(CancellationToken cancellationToken = default);
}
