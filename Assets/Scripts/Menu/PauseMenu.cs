using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Le GameObject du menu pause
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape; // Touche pour activer/désactiver le menu pause
    private bool isPaused = false; // Indique si le jeu est en pause

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                Resume(); // Reprendre le jeu
            }
            else
            {
                Pause(); // Activer le menu pause
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Masquer le menu pause
        Time.timeScale = 1f; // Reprendre le temps du jeu
        isPaused = false; // Le jeu n'est plus en pause
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Afficher le menu pause
        Time.timeScale = 0f; // Arrêter le temps du jeu
        isPaused = true; // Le jeu est en pause
    }

    public void QuitGame()
    {
        // Quitte le jeu ou retourne au menu principal
        Time.timeScale = 1f; // Assurez-vous de reprendre le temps
        Application.Quit(); // Quitte le jeu
        // Ou vous pouvez charger une autre scène avec SceneManager.LoadScene("MenuPrincipal");
    }
}
