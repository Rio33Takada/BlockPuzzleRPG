public class FieldGridInformation : BaseGridInformation
{
    public FieldObject FieldObject { get; set; } // そのマスを占有しているオブジェクト.

    public FieldGridInformation(int x, int y ,FieldObject fieldObject) : base(x, y)
    {
        FieldObject = fieldObject;
    }
}