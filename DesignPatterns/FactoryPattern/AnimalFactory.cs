namespace DesignPatterns.FactoryPattern;

public class AnimalFactory
{
    public static Animal CreateAnimal(string animalType)
    {
        if(animalType == "Dog")
        {
            return new Dog();
        }
        else if(animalType == "Cat")
        {
            return new Cat();
        }
        else
        {
            throw new ArgumentException("Invalid animal type");
        }
    }
}