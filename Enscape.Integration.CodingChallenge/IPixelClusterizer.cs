namespace Enscape.Integration.CodingChallenge;

/* Challenge 2 */

public record PixelCluster((int x, int y)[] Pixels);

/// <summary>
/// Creates clusters of pixels from an existing pixel grid.
/// </summary>
public interface IPixelClusterizer
{
    /// <summary>
    /// Groups neighboring pixels into clusters.
    /// </summary>
    /// <param name="inputGrid">The input pixel grid.</param>
    /// <returns>All pixel clusters found in the grid.</returns>
    /// <remarks>Two pixels are not considered neighbors if they are only connected diagonally.</remarks>
    PixelCluster[] CreateClusters(IPixelGrid inputGrid);
}

public class PixelClusterizer : IPixelClusterizer
{
    public PixelCluster[] CreateClusters(IPixelGrid inputGrid)
    {
        throw new NotImplementedException();
    }
}