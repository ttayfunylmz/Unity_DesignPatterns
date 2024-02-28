//"Concrete Component" class representing a speed potion
public class SpeedPotion : IPotion
{
    private readonly int value; // Value of the speed potion

    //Constructor
    public SpeedPotion(int value)
    {
        this.value = value;
    }

    //Method for using the speed potion and returning its value
    public int UsePotion()
    {
        return value;
    }
}
