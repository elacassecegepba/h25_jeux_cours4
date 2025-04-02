using UnityEngine;

/// <summary>
/// Un StaticInstance est une classe qui contient une instance d'elle-même.
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        Instance = this as T;
    }

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// Un singleton est un objet qui ne peut exister qu'en un seul exemplaire.
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        // S'il y a déjà une instance de ce singleton, on détruit l'objet actuel.
        if (Instance is not null)
        {
            Destroy(gameObject);
            return;
        }

        // Appel de la méthode Awake de StaticInstance.
        base.Awake();
    }
}

/// <summary>
/// Un singleton persistant est un singleton qui ne sera pas détruit lors d'un
/// changement de scène.
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        // Appel de la méthode Awake de Singleton.
        base.Awake();
        // On empèche la destruction de l'objet lors d'un changement de scène.
        DontDestroyOnLoad(gameObject);
    }
}
