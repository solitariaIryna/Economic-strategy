
public class Resource
{
    private Resources _resources;
    public Resources Resources { get => _resources;}
    public int Value { get => _value; set => _value = value; }

    private int _value;

    public Resource(Resources resources, int value)
    {
        _resources = resources;
        _value = value;    
    }
 
    public void ClearValueResource()
    {
        Value = 0;
    }
}
    
