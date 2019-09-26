using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("TestMap");
    }

}
