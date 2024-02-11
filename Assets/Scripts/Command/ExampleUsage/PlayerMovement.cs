using System.Collections;
using UnityEngine;
using DG.Tweening;

//A simple class to manage Player Movement.
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float moveDuration = 0.75f;

    //Move the cube to its destination.
    public void HandleMovement(Vector3 movement)
    {
        Vector3 destination = transform.position + movement;
        StartCoroutine(AnimateMovement(destination));
        playerAnimator.SetTrigger(Consts.CommandPatternConsts.IS_JUMPING);
    }

    //Animate the Cube.
    private IEnumerator AnimateMovement(Vector3 destination)
    {
        float waitingSeconds = 0.25f;
        yield return new WaitForSeconds(waitingSeconds);
        transform.DOMove(destination, moveDuration).SetEase(Ease.OutQuart);
    }
}
