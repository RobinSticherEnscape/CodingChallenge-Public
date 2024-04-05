namespace Enscape.Integration.CodingChallenge;

/* Challenge 1 */

/// <summary>
/// A data structure to store and load pixels. All accesses have to happen
/// within the bounds of including (0, 0) to excluding (width, height).
/// </summary>
public interface IPixelGrid
{
    int Width { get; }
    int Height { get; }

    bool Get(int x, int y);
    void Set(int x, int y, bool value);
}

public class PixelGrid : IPixelGrid
{
    private bool[][] _pixel;

    public PixelGrid(int width, int height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException();
        Width = width;
        Height = height;

        _pixel = new bool[width][];
        for (int i = 0; i < width; i++)
        {
            _pixel[i] = new bool[height];
        }
    }

    public int Width { get; }
    public int Height { get; }

    public bool Get(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
            throw new ArgumentException();
        return _pixel[x][y];

    }

    public void Set(int x, int y, bool value)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
            throw new ArgumentException();
        _pixel[x][y] = value;
    }
}