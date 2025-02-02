namespace DesignPatterns.ObserverPattern;

public class WeatherStation
{
    private List<IObserver> _observers = new();
    private float _temperature;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach(var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }

    public void SetTemperature(float newTemperature)
    {
        _temperature = newTemperature;
        NotifyObservers();
    }
}   