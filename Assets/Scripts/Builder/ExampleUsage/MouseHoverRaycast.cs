using UnityEngine;

/// <summary>
/// Handles raycasting from the mouse position and displays popups for specific objects when hovered over.
/// </summary>
public class MouseHoverRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _rayDistance = 100f;
    [SerializeField] private GameObject _rifleGunPopup;
    [SerializeField] private GameObject _shotGunPopup;

    /// <summary>
    /// Updates the raycast every frame to check for mouse hover interactions.
    /// </summary>
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance, _layerMask))
        {
            ShowHidePopup(hit, Consts.BuilderPatternConsts.RIFLE_GUN, _rifleGunPopup);
            ShowHidePopup(hit, Consts.BuilderPatternConsts.SHOT_GUN, _shotGunPopup);
        }
        else
        {
            _rifleGunPopup.SetActive(false);
            _shotGunPopup.SetActive(false);
        }
    }

    /// <summary>
    /// Shows or hides a popup based on the tag of the hit object.
    /// </summary>
    /// <param name="hit">The RaycastHit that contains information about the collision.</param>
    /// <param name="objectTag">The tag of the object to check.</param>
    /// <param name="popupGameObject">The popup GameObject to show or hide.</param>
    private void ShowHidePopup(RaycastHit hit, string objectTag, GameObject popupGameObject)
    {
        if(hit.collider.gameObject.CompareTag(objectTag))
        {
            popupGameObject.SetActive(true);
        }
        else
        {
            popupGameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * _rayDistance);
    }
}
