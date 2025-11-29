public abstract class BaseGridInformation
{
    public int IndexX { get; }
    public int IndexY { get; }

    public BaseGridInformation(int x, int y)
    {
        IndexX = x;
        IndexY = y;
    }
}