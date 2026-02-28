using Snek.Core.Models;
using Snek.Graph_Creation.ViewModel;
using System.Windows.Controls;

namespace Snek.Graph_Creation.View;

public partial class PosView : UserControl
{
    public PosView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>
        {
            if (DataContext is PosViewModel viewModel)
            {
                await viewModel.InitializeAsync();
            }
        };
    }

    private async void MitwirkendeSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is PosViewModel viewModel && sender is ListBox listBox)
        {
            await viewModel.SelectMitwirkendeAsync(listBox.SelectedItem as Mitwirkende);
        }
    }

    private async void ArbeitenSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (DataContext is PosViewModel viewModel && sender is ListBox listBox)
        {
            await viewModel.SelectArbeitenAsync(listBox.SelectedItem as Arbeiten);
        }
    }
}
