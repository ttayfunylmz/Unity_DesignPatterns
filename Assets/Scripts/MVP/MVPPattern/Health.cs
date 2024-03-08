using System;
using UnityEngine;

//"Model" component for MVP.
public class Health : MonoBehaviour
{
    //Event triggered when health changes, allows for decoupled communication.
    public event Action OnHealthChanged;

    //Variables
    private const int minHealth = 0;
    private const int maxHealth = 100;
    private int currentHealth;

    //Properties
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MinHealth => minHealth;
    public int MaxHealth => maxHealth;

    //Increase health by a specified amount.
    public void IncreaseHealth(int increaseAmount)
    {
        currentHealth += increaseAmount;
        currentHealth = Mathf.Max(currentHealth, minHealth);
        UpdateHealth();
    }

    //Decrease health by a specified amount.
    public void DecreaseHealth(int decreaseAmount)
    {
        currentHealth -= decreaseAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealth();
    }

    //Trigger health update event.
    public void UpdateHealth()
    {
        OnHealthChanged?.Invoke();
    }
}
