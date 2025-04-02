using UnityEngine;

/// <summary>
/// Singleton pour gérer le son dans le jeu.
/// </summary>
public class AudioSystem : Singleton<AudioSystem>
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;

    public void PlayMusic(AudioSO audioSO)
    {
        audioSO.Play(_musicSource);
    }

    public void PlaySFX(AudioSO audioSO, Vector3 pos)
    {
        audioSO.PlayAtPoint(_soundSource, pos);
    }

    public void PlaySFX(AudioSO audioSO)
    {
        audioSO.PlayOneShot(_soundSource);
    }
}
