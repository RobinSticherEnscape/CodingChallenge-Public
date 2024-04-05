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
        var unmergedClusters = Enumerable.Range(0, inputGrid.Width)
            .SelectMany(i => Enumerable.Range(0, inputGrid.Height)
                .Select(j => (i, j)))
            .Where(p => inputGrid.Get(p.i, p.j))
            .Select(p => new PixelCluster(new[] { p }))
            .ToList();

        var result = new List<PixelCluster>();

        while(unmergedClusters.Any())
        {
            var candidate = unmergedClusters.Last(); // just pick one
            unmergedClusters.Remove(candidate);
         
            var adjacent = unmergedClusters
                .Where(candidate.IsAdjacentTo)
                .ToArray();

            if (adjacent.Any())
            {
                unmergedClusters = unmergedClusters.Except(adjacent).ToList();
                var union = candidate
                    .Singleton()
                    .Concat(adjacent)
                    .Join();
                unmergedClusters.Add(union);
            }
            else
            {
                result.Add(candidate);
            }
        }

        return result.ToArray();
    }    
}

internal static class Extensions
{
    public static IEnumerable<T> Singleton<T>(this T elem) =>
        Enumerable.Repeat(elem, 1);

    public static PixelCluster Join(this IEnumerable<PixelCluster> clusters) =>
       new PixelCluster(clusters.SelectMany(cl => cl.Pixels).ToArray());

    public static bool IsAdjacentTo(this PixelCluster a, PixelCluster b) =>
        a.Pixels.Any(p1 => b.Pixels.Any(p2 => p1.IsAdjacentTo(p2)));

    public static bool IsAdjacentTo(this (int x, int y) p1, (int x, int y) p2) =>
        p1.x == p2.x && p1.y == p2.y - 1 ||
        p1.x == p2.x && p1.y == p2.y + 1 ||
        p1.y == p2.y && p1.x == p2.x - 1 ||
        p1.y == p2.y && p1.x == p2.x + 1;
}