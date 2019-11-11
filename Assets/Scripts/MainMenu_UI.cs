using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{

    public GameObject newGame;
    public GameObject continueGame;
    public GameObject settings;
    public GameObject exitGame;

    void Start()
    {
        if (Database.GetFirstPlayer() == null)
        {
            continueGame.SetActive(false);
        }
        else
        {
            newGame.SetActive(false);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("NewCharacter");
    }

    public void ContinueGame()
    {
        Player player = Database.GetFirstPlayer();
        SceneManager.LoadScene(player.levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {

    }

}
