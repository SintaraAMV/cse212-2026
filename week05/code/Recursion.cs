using System.Collections.Generic;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2.
    /// If n <= 0, return 0. A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
        {
            return 0;
        }

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size'
    /// from the string 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remainingLetters = letters.Remove(i, 1);
            PermutationsChoose(results, remainingLetters, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count how many ways there are to climb stairs when a person
    /// can climb 1, 2, or 3 stairs at a time.
    /// Uses memoization for large values.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        remember ??= new Dictionary<int, decimal>();

        if (s < 0)
        {
            return 0;
        }

        if (s == 0)
        {
            return 1;
        }

        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        decimal result =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = result;
        return result;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Insert all possible binary strings for a given wildcard pattern.
    /// Example: 1*0 -> 100, 110.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0)
    /// and end at the end square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        currPath ??= new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            if (maze.IsValidMove(currPath, x + 1, y))
            {
                SolveMaze(results, maze, x + 1, y, currPath);
            }

            if (maze.IsValidMove(currPath, x, y + 1))
            {
                SolveMaze(results, maze, x, y + 1, currPath);
            }

            if (maze.IsValidMove(currPath, x - 1, y))
            {
                SolveMaze(results, maze, x - 1, y, currPath);
            }

            if (maze.IsValidMove(currPath, x, y - 1))
            {
                SolveMaze(results, maze, x, y - 1, currPath);
            }
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}