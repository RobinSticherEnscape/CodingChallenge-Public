namespace Enscape.Integration.CodingChallenge.Tests;

public class PixelClusterizerTests
{
    private IPixelClusterizer _clusterizer;

    [SetUp]
    public void Setup()
    {
        _clusterizer = new PixelClusterizer();
    }

    [Test]
    public void PixelClusterizer_CorrectNumberOfClustersFound()
    {
        var voxels = new[]
        {
            (x: 1, y: 1),
            (x: 2, y: 1),
            (x: 1, y: 2),
            (x: 2, y: 2),

            (x: 4, y: 4),
            (x: 5, y: 4),
            (x: 4, y: 5),
            (x: 5, y: 5),
        };

        var voxelGrid = new PixelGrid(10, 10);

        foreach (var (x, y) in voxels)
        {
            voxelGrid.Set(x, y, true);
        }

        var clusters = _clusterizer.CreateClusters(voxelGrid);


        Assert.That(clusters.Count, Is.EqualTo(2));
    }

    [Test]
    public void PixelClusterizer_ClustersHaveCorrectNumberOfPixels()
    {
        var voxels = new[]
        {
            (x: 1, y: 1),
            (x: 2, y: 1),
            (x: 1, y: 2),
            (x: 2, y: 2),

            (x: 4, y: 4),
            (x: 5, y: 4),
            (x: 4, y: 5),
            (x: 5, y: 5),
        };

        var voxelGrid = new PixelGrid(10, 10);

        foreach (var (x, y) in voxels)
        {
            voxelGrid.Set(x, y, true);
        }

        var clusters = _clusterizer.CreateClusters(voxelGrid);

        Assert.That(clusters[0].Pixels.Length, Is.EqualTo(4));
        Assert.That(clusters[1].Pixels.Length, Is.EqualTo(4));
    }

    [Test]
    public void PixelClusterizer_ClustersHaveCorrectPixels()
    {
        var voxels = new[]
        {
            (x: 1, y: 1),
            (x: 2, y: 1),
            (x: 1, y: 2),
            (x: 2, y: 2),

            (x: 4, y: 4),
            (x: 5, y: 4),
            (x: 4, y: 5),
            (x: 5, y: 5),
        };

        var voxelGrid = new PixelGrid(10, 10);

        foreach (var (x, y) in voxels)
        {
            voxelGrid.Set(x, y, true);
        }

        var clusters = _clusterizer.CreateClusters(voxelGrid);

        var firstCluster = voxels.Take(4).ToArray();
        var secondCluster = voxels.Skip(4).Take(4).ToArray();

        Assert.That(clusters[0].Pixels, Is.EquivalentTo(firstCluster).Or.EquivalentTo(secondCluster));
        Assert.That(clusters[1].Pixels, Is.EquivalentTo(firstCluster).Or.EquivalentTo(secondCluster));
        Assert.That(clusters[0].Pixels, Is.Not.EquivalentTo(clusters[1].Pixels));
    }

    [Test]
    public void PixelClusterizer_SampleGrid()
    {
        int[][] sampleGrid = [
            [0, 0, 0, 1, 1, 1, 0, 0, 0],
            [1, 1, 0, 1, 1, 1, 0, 1, 0],
            [1, 1, 0, 1, 0, 1, 0, 0, 0],
            [1, 1, 0, 0, 0, 0, 0, 0, 0],
            [0, 0, 1, 1, 0, 0, 1, 0, 1],
            [0, 0, 1, 1, 0, 0, 1, 1, 1]
        ];

        var voxelGrid = new PixelGrid(9, 6);

        for (int y = 0; y < sampleGrid.Length; y++)
        {
            for (int x = 0; x < sampleGrid[y].Length; x++)
            {
                voxelGrid.Set(x, y, sampleGrid[y][x] == 1);
            }
        }

        var clusters = _clusterizer.CreateClusters(voxelGrid);

        Assert.That(clusters.Count, Is.EqualTo(5));

        foreach (var cluster in clusters)
        {
            foreach (var pixel in cluster.Pixels)
            {
                Assert.That(sampleGrid[pixel.y][pixel.x], Is.EqualTo(1));
            }
        }
    }
}