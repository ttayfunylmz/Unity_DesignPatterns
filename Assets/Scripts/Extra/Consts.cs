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
        public const string DAMAGE_SOUND = "DamageSound";
        public const string HEAL_SOUND = "HealSound";
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

    public struct MVPPatternConsts
    {
        public const string IS_DAMAGED = "isDamaged";
        public const string IS_HEALED = "isHealed";
    }

    public struct BuilderPatternConsts
    {
        public const string RIFLE_GUN = "RifleGun";
        public const string SHOT_GUN = "ShotGun";
    }
}
