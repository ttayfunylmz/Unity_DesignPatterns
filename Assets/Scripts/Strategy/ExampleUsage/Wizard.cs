using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A main player class for "Strategy Pattern". Declares AbilityStrategy array & uses the ability when a button is pressed.
public class Wizard : MonoBehaviour
{
    [SerializeField] private AbilityStrategy[] abilities;

    [SerializeField] private Animator wizardAnimator;

    //Subscribe to the OnSpellButtonPressed event.
    private void OnEnable() 
    {
        SpellsUI.OnSpellButtonPressed += SpellsUI_OnSpellButtonPressed;
    }

    //Un-Subscribe to the OnSpellButtonPressed event.
    private void OnDisable() 
    {
        SpellsUI.OnSpellButtonPressed -= SpellsUI_OnSpellButtonPressed;
    }

    //Call the UseAbility function of the pressed button's script & play an animation.
    private void SpellsUI_OnSpellButtonPressed(int index)
    {
        abilities[index].UseAbility(this.transform, this.transform.rotation);
        wizardAnimator.SetTrigger(Consts.StrategyPatternConsts.IS_ATTACKING);
    }
}
