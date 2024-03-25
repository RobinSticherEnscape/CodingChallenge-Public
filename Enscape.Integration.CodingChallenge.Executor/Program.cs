using Enscape.Integration.CodingChallenge;
using Enscape.Integration.CodingChallenge.Executor;

var printer = new GridPrinter();

int[][] sampleGrid = [
    [0, 0, 0, 1, 1, 1, 0, 0, 0],
    [1, 1, 0, 1, 1, 1, 0, 1, 0],
    [1, 1, 0, 1, 0, 1, 0, 0, 0],
    [1, 1, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 1, 1, 0, 0, 1, 0, 1],
    [0, 0, 1, 1, 0, 0, 1, 1, 1]
];

IPixelGrid pixelGrid;
try
{
    pixelGrid = InitializePixelGrid(sampleGrid);
}
catch (NotImplementedException)
{
    Console.WriteLine();
    Console.WriteLine("Challenge 1 not implemented yet");
    return;
}

try
{
    var clusterizer = new PixelClusterizer();
    var clusters = clusterizer.CreateClusters(pixelGrid);

    foreach (var cluster in clusters)
    {
        printer.SetColoredCluster(cluster);
    }
}
catch (NotImplementedException)
{
    Console.WriteLine();
    Console.WriteLine("Challenge 2 not implemented yet");
}

PrintGrid(pixelGrid);

return;

void PrintGrid(IPixelGrid grid)
{
    Console.WriteLine("Printing PixelGrid");
    Console.WriteLine();
    printer.Print(grid);
}


IPixelGrid InitializePixelGrid(int[][] ints)
{
    Console.WriteLine("Initializing PixelGrid");

    var grid = new PixelGrid(ints[0].Length, ints.Length);

    for (var y = 0; y < ints.Length; y++)
    {
        for (var x = 0; x < ints[y].Length; x++)
        {
            grid.Set(x, y, ints[y][x] == 1);
        }
    }

    return grid;
}