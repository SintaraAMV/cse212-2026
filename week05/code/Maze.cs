// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }
    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        Width = width;
        Height = height;
        Data = data;
    }

    /// <summary>
    /// Helper function to determine if the (x,y) position is at
    /// the end of the maze.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Width + x] == 2;
    }

    /// <summary>
    /// Helper function to determine if the (x,y) position is a valid
    /// place to move given the size of the maze, the content of the maze,
    /// and the current path already traversed.
    /// </summary>
    public bool IsValidMove(List<ValueTuple<int, int>> currPath, int x, int y)
    {
        if (x > Width - 1 || x < 0)
        {
            return false;
        }

        if (y > Height - 1 || y < 0)
        {
            return false;
        }

        if (Data[y * Width + x] == 0)
        {
            return false;
        }

        if (currPath.Contains((x, y)))
        {
            return false;
        }

        return true;
    }
}