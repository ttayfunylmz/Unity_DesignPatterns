using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A spell class implements from AbilityStrategy class.
[CreateAssetMenu(fileName = "Vine Spell", menuName = "Spells/Vine Spell")]
public class VineSpellStrategy : AbilityStrategy
{
    [SerializeField] private GameObject vineParticlesPrefab; //Object to instantiate.
    [SerializeField] private float selfDestructionDuration;

    //Override UseAbility from AbilityStrategy class.
    public override void UseAbility(Transform desiredPosition, Quaternion desiredRotation)
    {
        Debug.Log("Vine Spell activated!");
        
        GameObject vineInstance =  Instantiate(vineParticlesPrefab, desiredPosition.position.With(y: 1.25f), desiredRotation);
        Destroy(vineInstance, selfDestructionDuration); //Destroy the object after a certain amount of time.
    }
}
