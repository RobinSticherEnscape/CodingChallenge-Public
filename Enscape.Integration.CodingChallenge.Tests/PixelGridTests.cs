namespace Enscape.Integration.CodingChallenge.Tests;

public class PixelGridTests
{
    [Test]
    public void PixelGrid_Initialization_CorrectSize()
    {
        var width = 10;
        var height = 20;

        var voxelGrid = new PixelGrid(width, height);

        Assert.That(voxelGrid.Width, Is.EqualTo(width));
        Assert.That(voxelGrid.Height, Is.EqualTo(height));
        Assert.DoesNotThrow(() =>
        {
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    voxelGrid.Get(x, y);
        });
    }

    [Test]
    public void PixelGrid_GetSet_CorrectValue()
    {
        var width = 100;
        var height = 200;

        var voxelGrid = new PixelGrid(width, height);

        var x = 99;
        var y = 199;

        voxelGrid.Set(x, y, true);

        Assert.IsTrue(voxelGrid.Get(x, y));
    }

    [Test]
    public void PixelGrid_LargeGrid_OperationValid()
    {
        var width = 100000;
        var height = 10000;

        var voxelGrid = new PixelGrid(width, height);

        var x = 500;
        var y = 500;

        voxelGrid.Set(x, y, true);

        Assert.IsTrue(voxelGrid.Get(x, y));
    }
}