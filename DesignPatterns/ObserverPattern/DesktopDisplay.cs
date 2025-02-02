using DesignPatterns.ObserverPattern;

namespace DesignPatterns.ObserverPattern;

public class DesktopDisplay : IObserver
{
    public void Update(float temperature)
    {
        System.Console.WriteLine($"Desktop Display: Temperature updated to {temperature} degrees.");
    }
}