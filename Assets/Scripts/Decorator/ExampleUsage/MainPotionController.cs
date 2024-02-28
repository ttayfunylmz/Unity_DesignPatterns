using System;
using UnityEngine;
using UnityEngine.UI;

//Controller for the main potion button in the UI
public class MainPotionController : MonoBehaviour
{
    //Trigger an event when the main potion button is clicked
    public static Action OnMainPotionClicked;

    private Button button;
    private RectTransform rectTransform;

    private void Awake() 
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        button.onClick.AddListener(() =>
        {
            OnMainButtonClick();
        });  
    }

    //Method called when the main potion button is clicked
    private void OnMainButtonClick()
    {
        //Check if a buff potion is selected
        if(PotionManager.Instance.SelectedBuffPotion != null)
        {
            PotionManager.Instance.SelectedBuffPotion.MoveTo(rectTransform.anchoredPosition);
            // Use the potion associated with the selected buff potion
            PotionManager.Instance.SelectedBuffPotion.Potion.UsePotion();

            OnMainPotionClicked?.Invoke();
            AudioManager.Instance.Play(Consts.Audio.MERGE_SOUND);
        }
        else
        {
            OnMainPotionClicked?.Invoke();
            Debug.Log("Speed Potion used without any other Potions.");
        }
    }
}
