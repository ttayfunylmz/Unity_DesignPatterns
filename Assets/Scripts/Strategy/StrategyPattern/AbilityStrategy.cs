using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A simple "Abstract Class" which is also a "Scriptable Object".
public abstract class AbilityStrategy : ScriptableObject
{
    public abstract void UseAbility(Transform desiredPosition, Quaternion desiredRotation);
}
