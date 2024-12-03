using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button Controller Script for the Demo.
/// </summary>
public class WeaponButtonsController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private GunInfoController _rifleGunInfoController;
    [SerializeField] private GunInfoController _shotgunInfoController;

    [Header("Rifle Gun Buttons")]
    [SerializeField] private Button _addRifleGunButton;
    [SerializeField] private Button _addSilencerRifleGunButton;
    [SerializeField] private Button _removeSilencerRifleGunButton;

    [Header("Shotgun Buttons")]
    [SerializeField] private Button _addShotgunButton;
    [SerializeField] private Button _addSilencerShotgunButton;
    [SerializeField] private Button _removeSilencerShotgunButton;

    private void Awake() 
    {
        _addRifleGunButton.onClick.AddListener(OnAddRifleGunButtonClicked);
        _addShotgunButton.onClick.AddListener(OnAddShotGunButtonClicked);
        _addSilencerRifleGunButton.onClick.AddListener(OnAddSilencerRifleGunButtonClicked);
        _removeSilencerRifleGunButton.onClick.AddListener(OnRemoveSilencerRifleGunButtonClicked);
        _addSilencerShotgunButton.onClick.AddListener(OnAddSilencerShotgunButtonClicked);
        _removeSilencerShotgunButton.onClick.AddListener(OnRemoveSilencerShotgunButtonClicked);
    }

    private void OnAddRifleGunButtonClicked()
    {
        _weaponManager.CreateRifleGun();
        _rifleGunInfoController.SetWeaponInfo(false);
        _addRifleGunButton.interactable = false;
        _addSilencerRifleGunButton.interactable = true;
        _removeSilencerRifleGunButton.interactable = true;
    }

    private void OnAddShotGunButtonClicked()
    {
        _weaponManager.CreateShotGun();
        _shotgunInfoController.SetWeaponInfo(false);
        _addShotgunButton.interactable = false;
        _addSilencerShotgunButton.interactable = true;
        _removeSilencerShotgunButton.interactable = true;
    }

    private void OnAddSilencerRifleGunButtonClicked()
    {
        _weaponManager.ToggleSilencerForRifleGun(true);
        _rifleGunInfoController.SetWeaponInfo(true);
    }

    private void OnRemoveSilencerRifleGunButtonClicked()
    {
        _weaponManager.ToggleSilencerForRifleGun(false);
        _rifleGunInfoController.SetWeaponInfo(false);
    }

    private void OnAddSilencerShotgunButtonClicked()
    {
        _weaponManager.ToggleSilencerForShotGun(true);
        _shotgunInfoController.SetWeaponInfo(true);
    }

    private void OnRemoveSilencerShotgunButtonClicked()
    {
        _weaponManager.ToggleSilencerForShotGun(false);
        _shotgunInfoController.SetWeaponInfo(false);
    }
}
