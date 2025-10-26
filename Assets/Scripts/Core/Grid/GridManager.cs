using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridManager<T> where T : BaseGridInformation
{
    private readonly T[,] grid;

    public T GetGrid(int x, int y) => grid[x, y];
    public IEnumerable<T> GetAll() => grid.Cast<T>();
    public bool IsInside(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;
}

