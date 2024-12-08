using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (size == 0)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            PermutationsChoose(results, letters.Substring(0, i) + letters.Substring(i + 1), size - 1, word + letters[i]);
        }
    }

    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        WildcardBinary(pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), results);
        WildcardBinary(pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), results);
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            return;
        }

        List<(int, int)> moves = new List<(int, int)> { (x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1) };

        foreach (var move in moves)
        {
            if (maze.IsValidMove(currPath, move.Item1, move.Item2))
            {
                SolveMaze(results, maze, move.Item1, move.Item2, new List<ValueTuple<int, int>>(currPath));
            }
        }
    }
}