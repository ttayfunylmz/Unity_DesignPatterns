using System;
using UnityEngine;

//Player class for making the prototype more polished.
public class Player : MonoBehaviour
{
    //Reference Variables
    [Header("MVP References")]
    [SerializeField] private HealthPresenter healthPresenter;

    [Header("References")]
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject damageParticles;
    [SerializeField] private GameObject healParticles;

    //Subscribe to the OnDamage & OnHeal events.
    private void Start() 
    {
        healthPresenter.OnDamage += HealthPresenter_OnDamage;
        healthPresenter.OnHeal += HealthPresenter_OnHeal;    
    }

    //On Damage Button click, play animation, play audio and spawn particles.
    private void HealthPresenter_OnDamage()
    {
        playerAnimator.SetTrigger(Consts.MVPPatternConsts.IS_DAMAGED);
        AudioManager.Instance.Play(Consts.Audio.DAMAGE_SOUND);
        var damageParticlesInstance = Instantiate(damageParticles, damageParticles.transform.position, Quaternion.identity);
        Destroy(damageParticlesInstance, 1f);
    }

    //On Heal Button click, play animation, play audio and spawn particles.
    private void HealthPresenter_OnHeal()
    {
        playerAnimator.SetTrigger(Consts.MVPPatternConsts.IS_HEALED);
        AudioManager.Instance.Play(Consts.Audio.HEAL_SOUND);
        var healParticlesInstance = Instantiate(healParticles, healParticles.transform.position, Quaternion.identity);
        Destroy(healParticlesInstance, 1f);
    }

    //Unsubscribe from OnDamage & OnHeal events on destruction to prevent memory leaks.
    private void OnDestroy()
    {
        healthPresenter.OnDamage -= HealthPresenter_OnDamage;
        healthPresenter.OnHeal -= HealthPresenter_OnHeal;
    }
}
