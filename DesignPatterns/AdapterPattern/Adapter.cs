namespace DesignPatterns.AdapterPattern;

public class Adapter : IAdapter
{
    private Adaptee _adaptee1;

    public Adapter(Adaptee adaptee)
    {
        _adaptee1 = adaptee;        
    }

    public void Request()
    {
        _adaptee1.SpecificRequest();
    }
}