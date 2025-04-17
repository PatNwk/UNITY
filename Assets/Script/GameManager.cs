using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour recharger la scène
using TMPro; // Pour utiliser TextMeshPro
using UnityEngine.UI; // Pour utiliser les boutons

public class GameManager : MonoBehaviour
{
    public int score = 0; // Le score du jeu
    public TextMeshProUGUI scoreText; // Le texte qui affichera le score en jeu
    public GameObject gameOverUI; // L'UI de fin de jeu (GameOver)
    public TextMeshProUGUI gameOverScoreText; // Le texte qui affichera le score dans l'UI de Game Over
    public Button retryButton; // Le bouton pour recommencer
    public Button quitButton; // Le bouton pour quitter

    void Start()
    {
        // Assure-toi que l'UI de GameOver est cachée au début
        gameOverUI.SetActive(false);

        // Ajoute des écouteurs pour les boutons "retry" et "quit"
        retryButton.onClick.AddListener(Retry);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Ajouter des points au score et mettre à jour l'affichage
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString(); // Mise à jour du texte avec TextMeshPro
    }

    // Affiche l'UI de GameOver, arrête le jeu et met à jour le score
    public void GameOver()
    {
        // Met à jour le texte du score dans l'UI de Game Over
        gameOverScoreText.text = "Score: " + score.ToString();

        // Affiche l'UI de Game Over
        gameOverUI.SetActive(true);

        // Arrête le temps du jeu
        Time.timeScale = 0;
    }

    // Redémarre la scène actuelle
    public void Retry()
    {
        Time.timeScale = 1; // Réactive le temps
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }

    // Quitte le jeu (fonctionne seulement en mode Build)
    public void QuitGame()
    {
        Application.Quit();
    }
}
