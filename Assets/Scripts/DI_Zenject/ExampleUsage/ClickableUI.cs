using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//This class serves as a non-MonoBehaviour example that uses dependency injection 
//To access a ClickableAudio instance, and provides a method to log a click event.
public class ClickableUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _clickText;

    public void SetClickText(int amount)
    {
        _clickText.text = "Click: " + amount.ToString();
    }
}
