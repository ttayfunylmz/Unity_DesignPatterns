using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//A simple class for managing buttons.
public class ButtonManager : MonoSingleton<ButtonManager>
{
    [SerializeField] private Button[] buttons;

    //On any button click, deactivate the buttons for a while and then reactivate them.
    public IEnumerator OnAnyButtonClick()
    {
        DeactivateButtons();

        float waitingSeconds = 1f;
        yield return new WaitForSeconds(waitingSeconds);

        ActivateButtons();
    }

    //Make all the buttons interactive.
    private void ActivateButtons()
    {
        foreach(Button button in buttons)
        {
            button.interactable = true;
        }
    }

    //Make all the buttons non-interactive.
    private void DeactivateButtons()
    {
        foreach(Button button in buttons)
        {
            button.interactable = false;
        }
    }
}
