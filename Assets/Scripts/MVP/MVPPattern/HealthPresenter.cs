using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//"Presenter" component for MVP.
public class HealthPresenter : MonoBehaviour
{
    //Events triggered when damage or healing occurs.
    public event Action OnDamage;
    public event Action OnHeal;

    //Reference Variables
    [Header("Model")]
    [SerializeField] private Health health;

    [Header("View")]
    [SerializeField] private Slider healthSlider;

    //Subscribe to the health change event and initialize health value on start.
    private void Start() 
    {
        health.OnHealthChanged += Health_OnHealthChanged;

        health.CurrentHealth = health.MaxHealth;
    }

    //Method invoked when the health changes, updates the view accordingly.
    private void Health_OnHealthChanged()
    {
        UpdateView();
    }

    //Updates the UI view (Slider) based on the current health value.
    public void UpdateView()
    {
        if(health == null) { return; }

        if(healthSlider != null && health.MaxHealth != 0)
        {
            float targetValue = (float)health.CurrentHealth / (float)health.MaxHealth;
            float animationDuration = 0.5f;
            healthSlider.DOValue(targetValue, animationDuration);
        }
    }

    //Method invoked when damage button is clicked, decreases health and triggers damage event.
    public void OnDamageButtonClick(int amount)
    {
        health?.DecreaseHealth(amount);
        OnDamage?.Invoke();
    }

    //Method invoked when heal button is clicked, increases health and triggers heal event.
    public void OnHealButtonClick(int amount)
    {
        health?.IncreaseHealth(amount);
        OnHeal?.Invoke();
    }

    //Unsubscribe from health change event on destruction to prevent memory leaks.
    private void OnDestroy() 
    {
        health.OnHealthChanged -= Health_OnHealthChanged;    
    }
}
