using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerSaveLoad : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private Camera cam;

    private Database db;

    void Start()
    {
        cam = Camera.main;
        FollowCamera fc = cam.GetComponent<FollowCamera>();
        db = GameObject.FindWithTag("Database").GetComponent<Database>();


        Player p = db.GetFirstPlayer();
        Vector3 playerLocation;
        if (p == null)
        {
            playerLocation = new Vector3(-6.49f, -10.28f, -5);
        }
        else
        {
            playerLocation = new Vector3(p.playerLocationX, p.playerLocationY, p.playerLocationZ);
        }
        GameObject playerSpawned = Instantiate(PlayerPrefab, playerLocation, Quaternion.identity);
        fc.target = playerSpawned.transform;

    }
}
