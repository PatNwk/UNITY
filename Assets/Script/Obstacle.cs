using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Trouve le GameManager dans la scène
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // Appelle la méthode GameOver du GameManager
            gameManager.GameOver();

            // Arrête le temps
            Time.timeScale = 0;

            // Debug - Affiche dans la console
            Debug.Log("Game Over !");
        }
    }
}
