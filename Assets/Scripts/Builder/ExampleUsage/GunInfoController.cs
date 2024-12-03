using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the display of weapon information in the UI.
/// </summary>
public class GunInfoController : MonoBehaviour
{
    [SerializeField] private WeaponDataSO _weaponData;

    [SerializeField] private TMP_Text _weaponNameText, _ammoCapacityText, _fireRateText,
        _hasScopeText, _isSilencedText;
    
    [SerializeField] private Image _weaponNameIconLeft, _weaponNameIconRight;
    
    /// <summary>
    /// Sets and updates the weapon information in the UI.
    /// </summary>
    public void SetWeaponInfo(bool hasSilencer)
    {
        _weaponNameText.text = _weaponData.WeaponName;
        _ammoCapacityText.text = _weaponData.AmmoCapacity.ToString();
        _fireRateText.text = _weaponData.FireRate.ToString();
        _hasScopeText.text = "Has Scope: " + "No";
        _isSilencedText.text = "Is Silenced: " + (hasSilencer ? "Yes" : "No");

        _weaponNameIconLeft.sprite = _weaponData.WeaponSprite;
        _weaponNameIconRight.sprite = _weaponData.WeaponSprite;
    }
}
