using UnityEngine;

/// <summary>
/// Represents weapon data with various attributes such as prefab, name, ammo capacity, fire rate, and additional features.
/// </summary>
public class WeaponData
{
    public GameObject WeaponPrefab { get; private set; }
    public string WeaponName { get; private set; }
    public int AmmoCapacity { get; private set; }
    public float FireRate { get; private set; }
    public bool HasScope { get; private set; }
    public bool HasSilencer { get; private set; }

    /// <summary>
    /// Private constructor to enforce object creation through the Builder class.
    /// </summary>
    private WeaponData() {}

    /// <summary>
    /// Builder class to construct a WeaponData instance step by step.
    /// </summary>
    public class Builder
    {
        private WeaponData _weaponData;

        /// <summary>
        /// Initializes a new instance of the Builder class.
        /// </summary>
        public Builder()
        {
            _weaponData = new WeaponData();
        }

        public Builder SetWeaponPrefab(GameObject weaponPrefab)
        {
            _weaponData.WeaponPrefab = weaponPrefab;
            return this;
        }

        public Builder SetWeaponName(string weaponName)
        {
            _weaponData.WeaponName = weaponName;
            return this;
        }

        public Builder SetAmmoCapacity(int ammoCapacity)
        {
            _weaponData.AmmoCapacity = ammoCapacity;
            return this;
        }

        public Builder SetFireRate(float fireRate)
        {
            _weaponData.FireRate = fireRate;
            return this;
        }

        public Builder SetScope(bool hasScope)
        {
            _weaponData.HasScope = hasScope;
            return this;
        }

        public Builder SetSilencer(bool hasSilencer)
        {
            _weaponData.HasSilencer = hasSilencer;
            return this;
        }

        /// <summary>
        /// Builds and returns the WeaponData instance.
        /// </summary>
        public WeaponData Build()
        {
            return _weaponData;
        }
    }
}
