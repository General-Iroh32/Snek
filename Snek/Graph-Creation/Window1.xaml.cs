using Snek.Presentation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snek.Graph_Creation;

public partial class Window1 : VsWindow
{
    private const int BoardWidth = 620;
    private const int BoardHeight = 380;
    private const int CellSize = 10;
    private readonly DispatcherTimer _timer = new() { Interval = TimeSpan.FromMilliseconds(90) };
    private readonly Random _random = new();
    private readonly List<Point> _snake = [];
    private Vector _direction = new(1, 0);
    private Vector _pendingDirection = new(1, 0);
    private Point _food;
    private int _score;
    private bool _isPaused;
    private bool _isGameOver;

    public Window1()
    {
        InitializeComponent();
        _timer.Tick += Timer_Tick;
        ResetGame();
    }

    protected override void OnClosed(EventArgs e)
    {
        _timer.Stop();
        base.OnClosed(e);
    }

    private void ResetGame()
    {
        _timer.Stop();
        _snake.Clear();
        for (var index = 0; index < 5; index++)
        {
            _snake.Add(new Point(150 - index * CellSize, 190));
        }

        _direction = new Vector(1, 0);
        _pendingDirection = _direction;
        _score = 0;
        _isPaused = false;
        _isGameOver = false;
        ScoreText.Text = "0";
        GameStateText.Text = "Läuft";
        GameStateText.Foreground = (Brush)FindResource("VsSuccessBrush");
        Overlay.Visibility = Visibility.Collapsed;
        SpawnFood();
        RenderGame();
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (_isPaused || _isGameOver)
        {
            return;
        }

        _direction = _pendingDirection;
        var head = _snake[0];
        var next = new Point(
            head.X + _direction.X * CellSize,
            head.Y + _direction.Y * CellSize);

        if (next.X < 0 || next.X >= BoardWidth || next.Y < 0 || next.Y >= BoardHeight
            || _snake.SkipLast(1).Contains(next))
        {
            EndGame();
            return;
        }

        _snake.Insert(0, next);
        if (next == _food)
        {
            _score += 10;
            ScoreText.Text = _score.ToString();
            SpawnFood();
        }
        else
        {
            _snake.RemoveAt(_snake.Count - 1);
        }

        RenderGame();
    }

    private void SpawnFood()
    {
        do
        {
            _food = new Point(
                _random.Next(BoardWidth / CellSize) * CellSize,
                _random.Next(BoardHeight / CellSize) * CellSize);
        }
        while (_snake.Contains(_food));
    }

    private void RenderGame()
    {
        GameCanvas.Children.Clear();
        AddCell(_food, (Brush)FindResource("VsErrorBrush"));

        for (var index = _snake.Count - 1; index >= 0; index--)
        {
            AddCell(
                _snake[index],
                index == 0 ? (Brush)FindResource("VsAccentHoverBrush") : (Brush)FindResource("VsSuccessBrush"));
        }
    }

    private void AddCell(Point point, Brush color)
    {
        var cell = new Rectangle
        {
            Width = CellSize - 1,
            Height = CellSize - 1,
            RadiusX = 2,
            RadiusY = 2,
            Fill = color
        };
        Canvas.SetLeft(cell, point.X);
        Canvas.SetTop(cell, point.Y);
        GameCanvas.Children.Add(cell);
    }

    private void EndGame()
    {
        _isGameOver = true;
        _timer.Stop();
        GameStateText.Text = "Game Over";
        GameStateText.Foreground = (Brush)FindResource("VsErrorBrush");
        OverlayTitle.Text = "Game Over";
        OverlayHint.Text = $"Score: {_score}  •  R für einen Neustart";
        Overlay.Visibility = Visibility.Visible;
    }

    private void TogglePause()
    {
        if (_isGameOver)
        {
            return;
        }

        _isPaused = !_isPaused;
        GameStateText.Text = _isPaused ? "Pausiert" : "Läuft";
        GameStateText.Foreground = (Brush)FindResource(_isPaused ? "VsWarningBrush" : "VsSuccessBrush");
        OverlayTitle.Text = "Pausiert";
        OverlayHint.Text = "Leertaste zum Fortsetzen";
        Overlay.Visibility = _isPaused ? Visibility.Visible : Visibility.Collapsed;
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        var requestedDirection = e.Key switch
        {
            Key.Up or Key.W => new Vector(0, -1),
            Key.Down or Key.S => new Vector(0, 1),
            Key.Left or Key.A => new Vector(-1, 0),
            Key.Right or Key.D => new Vector(1, 0),
            _ => (Vector?)null
        };

        if (requestedDirection is { } direction && direction + _direction != new Vector(0, 0))
        {
            _pendingDirection = direction;
            e.Handled = true;
        }
        else if (e.Key == Key.Space)
        {
            TogglePause();
            e.Handled = true;
        }
        else if (e.Key == Key.R)
        {
            ResetGame();
            e.Handled = true;
        }
        else if (e.Key == Key.Escape)
        {
            Close();
            e.Handled = true;
        }
    }
}
