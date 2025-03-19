using UnityEngine;

/// <summary>
/// Manages the registration and unregistration of services in the ServiceLocator.
/// Ensures that services are available globally within the application.
/// </summary>
public class ServiceManager : MonoBehaviour
{
    [Header("Services to Register")]
    [SerializeField] private ButtonSoundManager _soundManager;
    [SerializeField] private ClickCounterUI _clickCounterUI;

    /// <summary>
    /// Registers the required services on Awake.
    /// </summary>
    private void Awake()
    {
        RegisterServices();
    }

    /// <summary>
    /// Registers services into the ServiceLocator.
    /// </summary>
    private void RegisterServices()
    {
        ServiceLocator.RegisterService<ButtonSoundManager>(_soundManager);
        ServiceLocator.RegisterService<ClickCounterUI>(_clickCounterUI);
    }

    /// <summary>
    /// Unregisters services from the ServiceLocator.
    /// </summary>
    private void UnregisterServices()
    {
        ServiceLocator.UnregisterService<ButtonSoundManager>();
        ServiceLocator.UnregisterService<ClickCounterUI>();
    }

    /// <summary>
    /// Ensures that services are unregistered when the object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        UnregisterServices();
    }
}
