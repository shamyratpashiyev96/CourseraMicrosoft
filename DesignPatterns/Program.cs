using DesignPatterns.AdapterPattern;
using DesignPatterns.FactoryPattern;
using DesignPatterns.ObserverPattern;
using DesignPatterns.SingletonPattern;

namespace DesignPatterns;

public class Program
{
    public static void Main(string[] args)
    {
        /* Singleton pattern (Creational design pattern) */
        var dbConnection1 = Database.GetInstance();
        var dbConnection2 = Database.GetInstance();

        dbConnection1.Connect(); // Outputs "Successfully connected to the Database", because it is not connected yet.
        dbConnection2.Connect(); // Outputs "Already connected to the Database", because it is attempting to connect for the second time.  
        var bothConnectionsAreEqual = object.ReferenceEquals(dbConnection1, dbConnection2);
        System.Console.WriteLine($"bothConnectionsAreEqual: {bothConnectionsAreEqual}"); // Outputs true, which means it is structured using singleton pattern


        /* Adapter pattern (Structural design pattern) */
        Adaptee adaptee = new Adaptee();
        IAdapter adapter = new Adapter(adaptee);
        adapter.Request(); // Outputs "Implementing SpecificRequest", it means we have called adaptee.SpecificRequest() via adapter.Request() func


        /* Factory Pattern (Creational design pattern) */
        Animal dog = AnimalFactory.CreateAnimal("Dog");
        dog.Speak();

        Animal cat = AnimalFactory.CreateAnimal("Cat");
        cat.Speak();


        /* Observer Pattern (Behavioral design pattern) */
        var desktopDisplay = new DesktopDisplay();
        var phoneDisplay = new PhoneDisplay();
        var weatherStation = new WeatherStation();

        weatherStation.RegisterObserver(desktopDisplay);
        weatherStation.RegisterObserver(phoneDisplay);
        weatherStation.SetTemperature(20.4f); // Displays messages for both registered (desktop & phone) observers
    }
}

