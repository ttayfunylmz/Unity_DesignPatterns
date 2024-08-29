using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickableUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _clickText;

    public void SetClickText(int amount)
    {
        _clickText.text = "Click: " + amount.ToString();
    }
}
