using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Références aux différents sons
    private AudioClip _collectSound; // Son de collecte des pièces
    private AudioSource _audioSource; // AudioSource pour jouer les sons

    // Instance unique pour accéder à l'AudioManager partout
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        // Gérer l'instance du singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Assure-toi qu'il n'y a qu'un seul AudioManager
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Empêche de détruire l'AudioManager lors des scènes suivantes
        }

        // Charger les sons depuis le dossier Resources
        _collectSound = Resources.Load<AudioClip>("Sounds/coin01"); // Charge le son de collecte
        _audioSource = GetComponent<AudioSource>(); // Récupère le composant AudioSource attaché à ce GameObject
    }

    // Jouer le son de collecte des pièces
    public void PlayCollectSound()
    {
        if (_collectSound != null)
        {
            _audioSource.PlayOneShot(_collectSound); // Joue le son uniquement une fois
        }
        else
        {
            Debug.LogError("Collect sound not assigned in AudioManager.");
        }
    }
}
