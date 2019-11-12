using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{

    public GameObject newGame;
    public GameObject continueGame;
    public GameObject settings;
    public GameObject exitGame;

    private Database db;

    void Start()
    {
        db = GameObject.FindWithTag("Database").GetComponent<Database>();
        
    }

    void Update()
    {
        if (db.mainPlayer != null)
        {
            continueGame.SetActive(true);
            newGame.SetActive(false);
        }
        else
        {
            continueGame.SetActive(false);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("NewCharacter");
    }

    public void ContinueGame()
    {
        Player player = db.mainPlayer;
        SceneManager.LoadScene(player.levelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        Debug.Log(db.mainPlayer == null);
    }

}
