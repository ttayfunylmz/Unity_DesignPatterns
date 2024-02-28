using UnityEngine;

//Character class for playing animations and particles when the main potion button is clicked
public class Character : MonoBehaviour
{
    [SerializeField] private Animator characterAnimator;
    [SerializeField] private GameObject levelUpParticles;

    //Subscribe to the event
    private void Start() 
    {
        MainPotionController.OnMainPotionClicked += MainPotionController_OnMainPotionClicked;    
    }

    //Play an animation and create a particle when the event is triggered
    private void MainPotionController_OnMainPotionClicked()
    {
        characterAnimator.SetTrigger(Consts.DecoratorPatternConsts.IS_LEVELING_UP);
        Instantiate(levelUpParticles, transform.position, Quaternion.identity);
    }
}
