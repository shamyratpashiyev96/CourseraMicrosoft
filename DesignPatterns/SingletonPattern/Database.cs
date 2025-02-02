namespace DesignPatterns.SingletonPattern;

public class Database
{
    private static Database instance;
    private static readonly object lockObject = new();
    private static bool isConnected = false;

    private Database() { }

    public static Database GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                instance = new Database();
            }
        }

        return instance;
    }

    public void Connect()
    {
        if (!isConnected)
        {
            isConnected = true;
            System.Console.WriteLine("Successfully connected to the Database");
        }
        else
        {
            System.Console.WriteLine("Already connected to the Database");
        }
    }
}