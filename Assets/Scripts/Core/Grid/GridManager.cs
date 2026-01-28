using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager<T> where T : BaseGridInformation
{
    private readonly T[,] grid;
    private readonly Func<int, int, T> creator;

    public int Width { get; }
    public int Height { get; }

    public GridManager(int width, int height, Func<int, int, T> creator)
    {
        Width = width;
        Height = height;
        this.creator = creator;

        grid = new T[Width, Height];

        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                grid[x, y] = creator(x, y);
            }
    }

    public T GetGrid(int x, int y)
    {
        return grid[x, y];
    }

    public IEnumerable<T> GetAll()
    {
        return grid.Cast<T>();
    }

    public bool IsInside(int x, int y)
    {
        return x >= 0 && y >= 0 && x < Width && y < Height;
    }

    public void SetGrid(int x, int y, T newInfo)
    {
        grid[x, y]?.OnBeforeReplace();
        grid[x, y] = newInfo;
    }
}
