using UnityEngine;

public class FieldGridInformation : BaseGridInformation
{
    public FieldObject FieldObject { get; set; }
    public GameObject ViewObject { get; set; }

    public FieldGridInformation(int x, int y, FieldObject fieldObject)
        : base(x, y)
    {
        FieldObject = fieldObject;
    }

    public override void OnBeforeReplace()
    {
        if (ViewObject != null)
        {
            GameObject.Destroy(ViewObject);
            ViewObject = null;
        }
    }
}
