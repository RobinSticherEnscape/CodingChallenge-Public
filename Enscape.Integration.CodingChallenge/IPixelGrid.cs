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
    public PixelGrid(int width, int height)
    {
        throw new NotImplementedException();
    }

    public int Width { get; }
    public int Height { get; }

    public bool Get(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Set(int x, int y, bool value)
    {
        throw new NotImplementedException();
    }
}