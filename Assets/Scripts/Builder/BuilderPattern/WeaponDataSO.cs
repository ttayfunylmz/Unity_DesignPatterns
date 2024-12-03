using UnityEngine;

/// <summary>
/// ScriptableObject representing weapon data. Can be used to store and manage weapon-related properties in the Unity Editor.
/// </summary>
[CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponData")]
public class WeaponDataSO : ScriptableObject
{
    [SerializeField] private string _weaponName;
    [SerializeField] private Sprite _weaponSprite;
    [SerializeField] private int _ammoCapacity;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _weaponPrefab;

    public string WeaponName => _weaponName;
    public Sprite WeaponSprite => _weaponSprite;
    public int AmmoCapacity => _ammoCapacity;
    public float FireRate => _fireRate;
    public GameObject WeaponPrefab => _weaponPrefab;
}
