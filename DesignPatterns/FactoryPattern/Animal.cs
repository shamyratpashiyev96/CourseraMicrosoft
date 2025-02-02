namespace DesignPatterns.FactoryPattern;

public abstract class Animal()
{
    public void Jump()
    {
        System.Console.WriteLine("Jumping");
    }

    public abstract void Speak();
}