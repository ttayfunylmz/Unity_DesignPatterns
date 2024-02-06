using UnityEngine;

//A simple MonoSingleton class for making our Singleton "Generic".
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " is missing.");
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Second instance of " + typeof(T) + " created. Automatic self-destruct triggered.");
            Destroy(this.gameObject);
        }
        instance = this as T;

        Init();
    }

    public virtual void Init() { }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}