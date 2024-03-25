# Coding Challenge - Pixel Grids

The following challenges are based on actual problems our team had to solve in the past. While the original tasks were using voxels, we chose to work with simplified conditions for today’s challenges and are using pixels instead.

A pixel is the smallest unit of information in a digital image, representing a single point of color in a grid pattern. We, however, work with an image mask that only stores whether a pixel is set or not.

## Challenge 1: Storing Pixels

Your task is to develop a data structure that is able to read and write pixels to a grid of a fixed size. Given below is an interface that needs to be implemented. You can find it [here](./Enscape.Integration.CodingChallenge/IPixelGrid.cs).

``` csharp
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
```



## Challenge 2: Clustering

The below grid shows a sample representation of a 9x6 pixel grid.

|  y/x  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |
|-------|---|---|---|---|---|---|---|---|---|
| **0** | 0 | 0 | 0 | 1 | 1 | 1 | 0 | 0 | 0 |
| **1** | 1 | 1 | 0 | 1 | 1 | 1 | 0 | 1 | 0 |
| **2** | 1 | 1 | 0 | 1 | 0 | 1 | 0 | 0 | 0 |
| **3** | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| **4** | 0 | 0 | 1 | 1 | 0 | 0 | 1 | 0 | 1 |
| **5** | 0 | 0 | 1 | 1 | 0 | 0 | 1 | 1 | 1 |

We want to find all clusters of set pixels within a given grid.

A cluster consists of all neighboring pixels.
Two pixels are neighboring if their distance is equal to 1. Diagonally connected pixels are not considered neighbors in our case.
Example: P(0, 3) and P(1, 3) are neighbors. P(1, 3) and P(2, 4) are not neighbors.


Implement the following interface to implement an algorithm that creates pixel clusters. You can find it [here](./Enscape.Integration.CodingChallenge/IPixelClusterizer.cs).
Use your implementation of pixel grids from Challenge 1.

``` csharp
/// <summary>
/// Creates clusters of pixels from an existing pixel grid.
/// </summary>
public interface IPixelClusterizer
{
    /// <summary>
    /// Groups neighboring pixels into clusters.
    /// </summary>
    /// <param name="inputGrid">The input binary pixel grid.</param>
    /// <returns>All pixel clusters found in the grid.</returns>
    /// <remarks>Two pixels are not considered neighbors if they are only connected diagonally.</remarks>
    PixelCluster[] Cluster(IPixelGrid inputGrid);
}
```
