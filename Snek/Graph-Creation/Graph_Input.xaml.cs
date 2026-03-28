using Snek.Core.Graphs;
using Snek.Presentation;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snek.Graph_Creation;

public partial class Graph_Input : VsWindow
{
    private readonly GraphType _type;
    private readonly GraphValueParser _valueParser;
    private IReadOnlyList<double>? _validValues;

    public Graph_Input(GraphType type, IReadOnlyList<double>? initialValues = null)
    {
        _type = type;
        _valueParser = App.GetRequiredService<GraphValueParser>();
        InitializeComponent();
        GraphTypeText.Text = $"{type.ToDisplayName()}  •  beliebig viele Werte";
        if (initialValues is { Count: > 0 })
        {
            ValuesInput.Text = string.Join(
                Environment.NewLine,
                initialValues.Select(value => value.ToString(CultureInfo.InvariantCulture)));
        }
        ValuesInput.Focus();
    }

    private void ValuesInput_TextChanged(object sender, TextChangedEventArgs e) => ValidateInput();

    private void ValidateInput()
    {
        try
        {
            _validValues = _valueParser.ParseText(ValuesInput.Text);
            ValueCountText.Text = _validValues.Count == 1 ? "1 gültiger Wert" : $"{_validValues.Count} gültige Werte";
            ValidationMessage.Text = string.Empty;
            CreateButton.IsEnabled = true;
        }
        catch (FormatException exception)
        {
            _validValues = null;
            ValueCountText.Text = "0 gültige Werte";
            ValidationMessage.Text = exception.Message;
            CreateButton.IsEnabled = false;
        }
    }

    private void CreateButton_Click(object sender, RoutedEventArgs e) => CreateGraph();

    private void CreateGraph()
    {
        if (_validValues is null)
        {
            return;
        }

        new Graph_Creator(new GraphDocument(_type, _validValues)).Show();
        Close();
    }

    private void SampleButton_Click(object sender, RoutedEventArgs e)
    {
        ValuesInput.Text = "12\n18,5\n9\n24\n16";
        ValuesInput.Focus();
        ValuesInput.CaretIndex = ValuesInput.Text.Length;
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ValuesInput.Clear();
        ValuesInput.Focus();
    }

    private void BackButton_Click(object sender, RoutedEventArgs e) => ShowTypeSelection();

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
        {
            CreateGraph();
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            ShowTypeSelection();
            e.Handled = true;
        }
    }

    private void ShowTypeSelection()
    {
        new Create_Graph_Type().Show();
        Close();
    }
}
