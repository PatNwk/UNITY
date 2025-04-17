using UnityEngine;

public class Piece : MonoBehaviour
{
    private GameManager gameManager; // Référence au GameManager

    void Start()
    {
        // Cherche le GameManager dans la scène
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Vérifie si l'objet qui entre en collision est le joueur
        {
            // Appelle la méthode PlayCollectSound de l'AudioManager pour jouer le son de collecte
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayCollectSound(); // Joue le son via AudioManager
                Debug.Log("Son joué : coin01"); // Affiche dans la console que le son est joué
            }
            else
            {
                Debug.LogWarning("AudioManager non trouvé !"); // Si AudioManager n'est pas trouvé
            }

            // Ajoute des points au score via le GameManager
            gameManager.AddScore(1);

            // Détruit la pièce (la fait disparaître)
            Destroy(gameObject);
        }
    }
}
