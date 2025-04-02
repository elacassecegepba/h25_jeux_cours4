using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    /// <summary>
    /// Charge la scène spécifiée par son nom.
    /// Attention, la scène doit être ajoutée dans le Build Settings.
    /// </summary>
    public void LoadScene(SceneSO sceneSO)
    {
        // On peut imaginer qu'on pourrait faire une transition entre les scènes.
        // Par exemple, on pourrait faire un fondu au noir avant de changer de scène.
        // On pourrait aussi faire une animation de transition entre les scènes.
        // Ou même un écran de chargement.
        sceneSO.LoadScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
