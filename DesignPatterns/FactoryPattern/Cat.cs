namespace DesignPatterns.FactoryPattern;

public class Cat : Animal
{
    public override void Speak()
    {
        System.Console.WriteLine("Meow!");
    }
}