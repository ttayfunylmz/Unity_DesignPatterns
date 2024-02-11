using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A spell class implements from AbilityStrategy class.
[CreateAssetMenu(fileName = "Magic Spell", menuName = "Spells/Magic Spell")]
public class MagicSpellStrategy : AbilityStrategy
{
    [SerializeField] private GameObject magicParticlesPrefab; //Object to instantiate.
    [SerializeField] private float selfDestructionDuration;

    //Override UseAbility from AbilityStrategy class.
    public override void UseAbility(Transform desiredPosition, Quaternion desiredRotation)
    {
        Debug.Log("Magic Spell activated!");

        GameObject magicInstance = Instantiate(magicParticlesPrefab, desiredPosition.position.With(y: 1.25f), desiredRotation);
        Destroy(magicInstance, selfDestructionDuration); //Destroy the object after a certain amount of time.
    }
}
