using System;
using System.Collections.Generic;
using System.Linq;

public class GridManager<T> where T : BaseGridInformation
{
    private readonly T[,] grid;

    public int Width { get; private set; }
    public int Height { get; private set; }

    public GridManager(int width, int height)
    {
        Width = width;
        Height = height;
        grid = new T[Width, Height];

        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
            {
                var emptyField = FieldObjectFactory.Create(FieldObjectType.Empty, x, y);
                grid[x, y] = (T)Activator.CreateInstance(typeof(T), x, y, emptyField);
            }
    }

    public T GetGrid(int x, int y) => grid[x, y];
    public IEnumerable<T> GetAll() => grid.Cast<T>();
    public bool IsInside(int x, int y) => x >= 0 && y >= 0 && x < Width && y < Height;

    public void SetGrid(int x, int y, T gridInformation)
    {
        grid[x, y] = gridInformation;
    }
}