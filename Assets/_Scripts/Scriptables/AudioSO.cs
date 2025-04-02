using UnityEngine;

/// <summary>
/// ScriptableObject pour stocker les informations sur un clip audio.
/// </summary>
[CreateAssetMenu(menuName = "Audio/Audio Data")]
public class AudioSO : ScriptableObject
{
    public AudioClip _clip;
    [Range(0f, 1f)]
    public float _volume;
    public bool _loop;

    public void Play(AudioSource audioSource) {
        audioSource.clip = _clip;
        audioSource.volume = _volume;
        audioSource.loop = _loop;
        audioSource.Play();
    }

    public void PlayOneShot(AudioSource audioSource) {
        audioSource.PlayOneShot(_clip, _volume);
    }

    public void PlayAtPoint(AudioSource audioSource, Vector3 position) {
        AudioSource.PlayClipAtPoint(_clip, position, _volume);
    }
}