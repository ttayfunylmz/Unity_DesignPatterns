using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A spell class implements from AbilityStrategy class.
[CreateAssetMenu(fileName = "Rock Spell", menuName = "Spells/Rock Spell")]
public class RockSpellStrategy : AbilityStrategy
{
    [SerializeField] private GameObject rockParticlesPrefab; //Object to instantiate.
    [SerializeField] private float selfDestructionDuration;

    //Override UseAbility from AbilityStrategy class.
    public override void UseAbility(Transform desiredPosition, Quaternion desiredRotation)
    {
        Debug.Log("Rock Spell activated!");
        
        GameObject rockInstance = Instantiate(rockParticlesPrefab, desiredPosition.position.With(y: 1.25f), desiredRotation);
        Destroy(rockInstance, selfDestructionDuration); //Destroy the object after a certain amount of time.
    }
}
