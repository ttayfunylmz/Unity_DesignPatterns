using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Constant values.
public class Consts : MonoBehaviour
{
    public struct Audio
    {
        public const string MERGE_SOUND = "MergeSound";
        public const string HOVER_SOUND = "HoverSound";
    }

    public struct StrategyPatternConsts
    {
        public const string IS_ATTACKING = "isAttacking";
    }

    public struct CommandPatternConsts
    {
        public const string IS_JUMPING = "isJumping";
    }

    public struct DecoratorPatternConsts
    {
        public const string IS_LEVELING_UP = "isLevelingUp";
    }
}
