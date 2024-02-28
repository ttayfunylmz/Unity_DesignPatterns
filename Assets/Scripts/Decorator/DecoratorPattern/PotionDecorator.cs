using UnityEngine;

//Decorator class for adding extra functionality to the Speed Potion.
public abstract class PotionDecorator : IPotion
{
    protected IPotion potion; //Reference to the potion being decorated
    protected readonly int value; //Extra value added by the decorator

    //Constructor
    public PotionDecorator(int value)
    {
        this.value = value;
    }

    //Method for decorating a potion with another potion
    //Checks if the potion being passed is not the same as the current potion
    public void Decorate(IPotion potion)
    {
        if(ReferenceEquals(this, potion))
        {
            Debug.LogWarning("Potion can't decorate itself.");
            return;
        }

        if(this.potion is PotionDecorator decorator)
        {
            decorator.Decorate(potion);
        }
        else
        {
            this.potion = potion;
        }
    }

    // Use the decorated potion using the "null-coalescing" operator
    public virtual int UsePotion()
    {
        Debug.Log("Using Decorator Potion with value: " + value);
        return potion?.UsePotion() + value ?? value;
    }
}
