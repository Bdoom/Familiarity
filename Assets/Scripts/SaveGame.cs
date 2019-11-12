using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private Database db; 

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        db = GameObject.FindWithTag("Database").GetComponent<Database>();
        StartCoroutine(WorldSave());
    }

    IEnumerator WorldSave()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            SavePlayer();
        }
    }

    void SavePlayer()
    {
        db.UpdatePlayer();

    }

}
