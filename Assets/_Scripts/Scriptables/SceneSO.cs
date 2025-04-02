using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Scene/Scene Data")]
public class SceneSO : ScriptableObject
{
    public SceneAsset _scene;
    public AudioSO _backgroundMusic;

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene.name);
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        AudioSystem.Instance.PlayMusic(_backgroundMusic);
    }
}
