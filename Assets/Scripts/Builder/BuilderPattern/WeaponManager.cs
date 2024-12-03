using UnityEngine;

/// <summary>
/// Manages weapon creation, instantiation, and functionality such as toggling the silencer for specific weapons.
/// </summary>
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponDataSO rifleGunData;
    [SerializeField] private WeaponDataSO shotGunData;

    private WeaponData _rifleGun;
    private WeaponData _shotGun;
    private GameObject _rifleGunInstance;
    private GameObject _shotGunInstance;

    /// <summary>
    /// Creates the rifle gun using the builder pattern and instantiates its prefab.
    /// </summary>
    public void CreateRifleGun()
    {
        _rifleGun = new WeaponData.Builder()
            .SetWeaponPrefab(rifleGunData.WeaponPrefab)
            .SetWeaponName(rifleGunData.WeaponName)
            .SetAmmoCapacity(rifleGunData.AmmoCapacity)
            .SetFireRate(rifleGunData.FireRate)
            .Build();

        _rifleGunInstance = InstantiateWeapon(_rifleGun);
    }

    /// <summary>
    /// Creates the shotgun using the builder pattern and instantiates its prefab.
    /// </summary>

    public void CreateShotGun()
    {
        _shotGun = new WeaponData.Builder()
            .SetWeaponPrefab(shotGunData.WeaponPrefab)
            .SetWeaponName(shotGunData.WeaponName)
            .SetAmmoCapacity(shotGunData.AmmoCapacity)
            .SetFireRate(shotGunData.FireRate)
            .SetSilencer(false)
            .Build();

        _shotGunInstance = InstantiateWeapon(_shotGun);
    }

    public void ToggleSilencerForRifleGun(bool hasSilencer)
    {
        ToggleSilencer(_rifleGun, _rifleGunInstance, hasSilencer);
    }

    public void ToggleSilencerForShotGun(bool hasSilencer)
    {
        ToggleSilencer(_shotGun, _shotGunInstance, hasSilencer);
    }

    /// <summary>
    /// Rebuilds the weapon data with updated silencer state and updates its visual representation.
    /// </summary>
    public void ToggleSilencer(WeaponData weaponData, GameObject weaponInstance, bool hasSilencer)
    {
        if (weaponData == null || weaponInstance == null) return;

        weaponData = new WeaponData.Builder()
            .SetWeaponPrefab(weaponData.WeaponPrefab)
            .SetWeaponName(weaponData.WeaponName)
            .SetAmmoCapacity(weaponData.AmmoCapacity)
            .SetFireRate(weaponData.FireRate)
            .SetSilencer(hasSilencer)
            .Build();

        ToggleSilencerVisual(weaponInstance, weaponData.HasSilencer);
    }

    /// <summary>
    /// Toggles the visual representation of the silencer on the weapon's prefab.
    /// </summary>
    private void ToggleSilencerVisual(GameObject weaponPrefab, bool hasSilencer)
    {
        weaponPrefab.GetComponent<GunPieceController>()?.ToggleSilencer(hasSilencer);
    }

    /// <summary>
    /// Instantiates the weapon prefab at its defined position and rotation.
    /// </summary>
    private GameObject InstantiateWeapon(WeaponData weaponData)
    {
        return Instantiate(
            weaponData.WeaponPrefab,
            weaponData.WeaponPrefab.gameObject.transform.position,
            weaponData.WeaponPrefab.gameObject.transform.rotation
        );
    }
}
