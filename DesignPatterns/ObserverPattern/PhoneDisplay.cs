namespace DesignPatterns.ObserverPattern;

public class PhoneDisplay : IObserver
{
    public void Update(float temperature)
    {
        System.Console.WriteLine($"Phone Display: Temperature updated to {temperature} degrees");
    }
}