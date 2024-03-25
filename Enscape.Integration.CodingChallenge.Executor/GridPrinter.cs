namespace Enscape.Integration.CodingChallenge.Executor;

public class GridPrinter
{
    const string Separator = "|";

    private readonly ConsoleColor[] _colors = [
        ConsoleColor.Red,
        ConsoleColor.Green,
        ConsoleColor.Yellow,
        ConsoleColor.Blue,
        ConsoleColor.Magenta,
        ConsoleColor.Cyan,
        ConsoleColor.Gray,
        ConsoleColor.DarkRed,
        ConsoleColor.DarkGreen,
        ConsoleColor.DarkBlue
    ];

    private int _nextColorIndex = 0;

    private readonly Dictionary<(int x, int y), ConsoleColor> _clusterColors = new();

    const ConsoleColor ForegroundColor = ConsoleColor.Black;
    const ConsoleColor BackgroundColor = ConsoleColor.White;

    public void Print(IPixelGrid grid)
    {
        var defaultForegroundColor = Console.ForegroundColor;
        var defaultBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = ForegroundColor;
        Console.BackgroundColor = BackgroundColor;

        WriteSeparatorRow(grid);

        for (var y = 0; y < grid.Height; y++)
        {
            Console.Write(" " + Separator);

            for (var x = 0; x < grid.Width; x++)
            {
                Console.BackgroundColor = GetColor(x, y);
                Console.Write(grid.Get(x, y) ? " 1 " : " 0 ");
                Console.BackgroundColor = BackgroundColor;
                Console.Write(Separator);
            }

            Console.Write(" ");

            Console.WriteLine();

            WriteSeparatorRow(grid);
        }

        Console.ForegroundColor = defaultForegroundColor;
        Console.BackgroundColor = defaultBackgroundColor;
    }

    public void SetColoredCluster(PixelCluster cluster)
    {
        foreach (var pixel in cluster.Pixels)
        {
            var color = _colors[_nextColorIndex];
            _clusterColors[pixel] = color;
        }

        _nextColorIndex = (_nextColorIndex + 1) % _colors.Length;
    }

    private ConsoleColor GetColor(int x, int y)
    {
        return _clusterColors.GetValueOrDefault((x, y), BackgroundColor);
    }

    private static void WriteSeparatorRow(IPixelGrid grid)
    {
        Console.Write(" |");

        Console.Write(new string('-', grid.Width * 4 - 1));
        Console.Write("| ");

        Console.WriteLine();
    }
}