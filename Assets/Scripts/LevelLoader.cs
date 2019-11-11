using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelLoader : MonoBehaviour
{
    public string LevelName;
    public GameObject FaderObject;
    private Animator animController;

    void Start()
    {
        animController = FaderObject.GetComponent<Animator>();
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<CharacterMovement>().enabled = false;
        animController.SetTrigger("FadeToBlack");
        StartCoroutine(WaitForFadeEnd());
    }

    IEnumerator WaitForFadeEnd()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(LevelName);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
