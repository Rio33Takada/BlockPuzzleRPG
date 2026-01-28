public abstract class BaseGridInformation
{
    public int IndexX { get; }
    public int IndexY { get; }

    protected BaseGridInformation(int x, int y)
    {
        IndexX = x;
        IndexY = y;
    }

    /// <summary>
    /// GridManager.SetGrid で差し替えられる直前に呼ばれる
    /// （ViewのDestroyなどを各派生クラスに委譲）
    /// </summary>
    public virtual void OnBeforeReplace()
    {
    }
}
