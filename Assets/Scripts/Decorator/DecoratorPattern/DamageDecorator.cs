using UnityEngine;

//Decorator class for adding damage functionality to a potion.
public class DamageDecorator : PotionDecorator
{
    //Constructor
    public DamageDecorator(int value) : base(value) {}

    //Use the decorated potion using the "null-coalescing" operator
    public override int UsePotion()
    {
        Debug.Log("Using DamageDecorator Potion with value: " + value);
        DamageOthers();
        return potion?.UsePotion() ?? 0; 
    }

    //Damaging buff
    private void DamageOthers()
    {
        //TODO: DAMAGE LOGIC
    }
}
