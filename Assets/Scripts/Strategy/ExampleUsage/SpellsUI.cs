using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A simple UI class for handling button clicks.
public class SpellsUI : MonoBehaviour
{
    [SerializeField] private Button[] spellButtons;

    public static Action<int> OnSpellButtonPressed;

    private void Awake() 
    {
        for (int i = 0; i < spellButtons.Length; ++i)
        {
            int index = i;
            spellButtons[i].onClick.AddListener(() =>
            {
                HandleButtonPress(index);
            });
        }
    }

    //Fire an event when a button is pressed.
    private void HandleButtonPress(int index)
    {
        OnSpellButtonPressed?.Invoke(index);
    }
}
