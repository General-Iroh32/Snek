using Snek.Core.Models;
using Snek.Core.Repositories;

namespace Snek.Core.Services;

public sealed class MitwirkendeService(IPosRepository repository) : IMitwirkendeService
{
    public Task<IReadOnlyList<Mitwirkende>> GetAllAsync(CancellationToken cancellationToken = default) =>
        repository.GetMitwirkendeAsync(cancellationToken);
}
