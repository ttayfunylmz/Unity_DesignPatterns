//Static class for creating potions by their type
public static class PotionFactory
{
    public static IPotion CreatePotion(PotionTypeSO potionType)
    {
        return potionType.type switch
        {
            PotionType.Health => new HealthDecorator(potionType.value),
            PotionType.Damage => new DamageDecorator(potionType.value),
            _ => new SpeedPotion(potionType.value)
        };
    }
}
