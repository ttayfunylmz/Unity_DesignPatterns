using UnityEngine;

//Potion Type Scriptable Object for defining different types of potions
[CreateAssetMenu(fileName = "Potions", menuName = "Potions/New Potion")]
public class PotionTypeSO : ScriptableObject
{
    public int value;
    public PotionType type;
}

//Potion Type Enum
public enum PotionType
{
    Speed,
    Health,
    Damage
}
