using UnityEngine;
using DG.Tweening;

//Controller for polishing images on hover
public class ImagePolishController : MonoBehaviour
{
    private float scaleDuration = 0.1f;
    
    //Method called when the mouse hovers over an image
    public void OnImageHoverEnter(Transform targetObject)
    {
        targetObject.DOScale(1.1f, scaleDuration);
        AudioManager.Instance.Play(Consts.Audio.HOVER_SOUND);
    }

    //Method called when the mouse exits the hover area of an image
    public void OnImageHoverExit(Transform targetObject)
    {
        targetObject.DOScale(1f, scaleDuration);
    }
}
