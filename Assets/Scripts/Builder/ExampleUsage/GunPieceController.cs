using UnityEngine;

/// <summary>
/// Controls individual pieces of a gun, such as the silencer.
/// </summary>
public class GunPieceController : MonoBehaviour
{
    [SerializeField] private GameObject _silencerGameObject;

    /// <summary>
    /// Toggles the visibility of the silencer based on the provided state.
    /// </summary>
    /// <param name="hasSilencer">True to activate the silencer, false to deactivate it.</param>
    public void ToggleSilencer(bool hasSilencer)
    {
        _silencerGameObject.SetActive(hasSilencer);
    }
}
