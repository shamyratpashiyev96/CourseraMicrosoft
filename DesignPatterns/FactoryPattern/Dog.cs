namespace DesignPatterns.FactoryPattern;

public class Dog : Animal
{
    public override void Speak()
    {
        System.Console.WriteLine("Woof!");
    }
}