using CommunityToolkit.Mvvm.ComponentModel;
using Snek.Core.Models;
using Snek.Core.Repositories;
using Snek.Core.Services;
using System.Collections.ObjectModel;

namespace Snek.Graph_Creation.ViewModel;

public sealed class PosViewModel(IPosRepository repository) : ObservableObject
{
    private bool _isBusy;
    private string? _errorMessage;
    private string _gesamtzeit = "00:00:00";
    private Mitwirkende? _selectedMitwirkende;
    private Arbeiten? _selectedArbeiten;

    public ObservableCollection<Mitwirkende> AllMitwirkende { get; } = [];

    public ObservableCollection<Arbeiten> ArbeitenByMitwirkende { get; } = [];

    public ObservableCollection<Zeiten> ZeitenByArbeiten { get; } = [];

    public Mitwirkende? SelectedMitwirkende
    {
        get => _selectedMitwirkende;
        private set => SetProperty(ref _selectedMitwirkende, value);
    }

    public Arbeiten? SelectedArbeiten
    {
        get => _selectedArbeiten;
        private set => SetProperty(ref _selectedArbeiten, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        private set => SetProperty(ref _isBusy, value);
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        private set => SetProperty(ref _errorMessage, value);
    }

    public string Gesamtzeit
    {
        get => _gesamtzeit;
        private set => SetProperty(ref _gesamtzeit, value);
    }

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        if (AllMitwirkende.Count > 0)
        {
            return;
        }

        await ExecuteAsync(async () =>
        {
            Replace(AllMitwirkende, await repository.GetMitwirkendeAsync(cancellationToken));
        });
    }

    public async Task SelectMitwirkendeAsync(
        Mitwirkende? mitwirkende,
        CancellationToken cancellationToken = default)
    {
        SelectedMitwirkende = mitwirkende;
        SelectedArbeiten = null;
        ArbeitenByMitwirkende.Clear();
        ZeitenByArbeiten.Clear();
        Gesamtzeit = "00:00:00";

        if (mitwirkende is null)
        {
            return;
        }

        await ExecuteAsync(async () =>
        {
            Replace(
                ArbeitenByMitwirkende,
                await repository.GetArbeitenAsync(mitwirkende.Id, cancellationToken));
        });
    }

    public async Task SelectArbeitenAsync(
        Arbeiten? arbeiten,
        CancellationToken cancellationToken = default)
    {
        SelectedArbeiten = arbeiten;
        ZeitenByArbeiten.Clear();
        Gesamtzeit = "00:00:00";

        if (arbeiten is null)
        {
            return;
        }

        await ExecuteAsync(async () =>
        {
            var entries = await repository.GetZeitenAsync(arbeiten.Id, cancellationToken);
            Replace(ZeitenByArbeiten, entries);
            Gesamtzeit = TimeSummary.Format(TimeSummary.Calculate(entries));
        });
    }

    private async Task ExecuteAsync(Func<Task> action)
    {
        IsBusy = true;
        ErrorMessage = null;
        try
        {
            await action();
        }
        catch (Exception exception)
        {
            ErrorMessage = exception.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private static void Replace<T>(ObservableCollection<T> target, IEnumerable<T> values)
    {
        target.Clear();
        foreach (var value in values)
        {
            target.Add(value);
        }
    }
}
