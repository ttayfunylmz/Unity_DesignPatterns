using UnityEngine;

//Decorator class for adding health functionality to a potion.
public class HealthDecorator : PotionDecorator
{
    //Constructor
    public HealthDecorator(int value) : base(value) {}

    //Use the decorated potion using the "null-coalescing" operator
    public override int UsePotion()
    {
        Debug.Log("Using HealthDecorator Potion with value: " + value);
        HealOthers();
        return potion?.UsePotion() ?? 0; 
    }

    //Healing buff
    private void HealOthers()
    {
        //TODO: HEAL LOGIC
    }
}
