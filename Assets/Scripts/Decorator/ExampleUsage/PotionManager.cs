using UnityEngine;

// Singleton class managing potion functionalities
public class PotionManager : MonoSingleton<PotionManager>
{
    public BuffPotionController SelectedBuffPotion;

    //Decorate the potion
    public void Decorate(BuffPotionController clickedBuffPotion)
    {
        if(SelectedBuffPotion == clickedBuffPotion) { return; }
        
        // Check if the selected potion is already a decorator
        if(SelectedBuffPotion.Potion is PotionDecorator decorator)
        {
            Debug.Log("Decorating Potions...");
            decorator.Decorate(clickedBuffPotion.Potion);
            clickedBuffPotion.Potion = decorator;

            SelectedBuffPotion.MoveTo(clickedBuffPotion.rectTransform.anchoredPosition);
            AudioManager.Instance.Play(Consts.Audio.MERGE_SOUND);
        }
        else
        {
            Debug.LogWarning("Can't Decorate Potions!");
        }
    }
}
