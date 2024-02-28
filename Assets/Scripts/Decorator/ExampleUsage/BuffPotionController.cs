using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

//Controller for buff potions in the UI
public class BuffPotionController : MonoBehaviour
{
    [SerializeField] private PotionTypeSO potionType;

    private Button button;
    public RectTransform rectTransform;

    public IPotion Potion { get; set; } //Property for the potion associated with the controller

    private void Awake()
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        //Create an instance of the potion associated with the controller using the PotionFactory
        Potion = PotionFactory.CreatePotion(potionType);

        button.onClick.AddListener(() =>
        {
            OnButtonClick();
        });
    }

    //Method called when the buff potion button is clicked
    private void OnButtonClick()
    {
        //Check if no buff potion is currently selected
        if(PotionManager.Instance.SelectedBuffPotion == null)
        {
            //Set this buff potion as the selected one
            PotionManager.Instance.SelectedBuffPotion = this;
            Debug.Log("Potion Selected: " + PotionManager.Instance.SelectedBuffPotion);
        }
        else
        {
            //Decorate the selected buff potion with this buff potion
            PotionManager.Instance.Decorate(this);
            //Reset the selected buff potion to null
            PotionManager.Instance.SelectedBuffPotion = null;
        }
    }

    //Move the buff potion to a target position with animation
    public void MoveTo(Vector2 targetPosition)
    {
        float duration = 0.5f;
        rectTransform.DOAnchorPos(targetPosition, duration).SetEase(Ease.InBack).OnComplete(() => 
        {
            Destroy(gameObject);
        });
    }
}
