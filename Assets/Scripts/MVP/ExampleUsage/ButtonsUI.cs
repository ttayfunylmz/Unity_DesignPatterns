using UnityEngine;
using UnityEngine.UI;

//Represents the UI buttons and their functionality within the MVP pattern.
public class ButtonsUI : MonoBehaviour
{
    //Reference Variables
    [Header("MVP References")]
    [SerializeField] private HealthPresenter healthPresenter;

    [Header("UI References")]
    [SerializeField] private Button damageButton;
    [SerializeField] private Button healButton;

    //Variables
    private int damageAmount = 10;
    private int healAmount = 10;

    //Handle Button Clicks.
    private void Awake() 
    {
        damageButton.onClick.AddListener(() =>
        {
            healthPresenter?.OnDamageButtonClick(damageAmount);
        });

        healButton.onClick.AddListener(() =>
        {
            healthPresenter?.OnHealButtonClick(healAmount);
        });
    }
}
