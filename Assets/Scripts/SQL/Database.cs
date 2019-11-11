using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using PixelCrushers.DialogueSystem;

public class Database : MonoBehaviour
{
    public static SQLiteConnection db;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        db = new SQLiteConnection("gamesave", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
    }

    void Start()
    {
    }
   
    public static IEnumerable<Player> GetPlayers()
    {
        return db.Table<Player>();
    }

    public static Player GetPlayerByID(int playerID)
    {
		return db.Table<Player>().Where(player => player.id == playerID).FirstOrDefault();
    }

    public static Player GetFirstPlayer()
    {
        return GetPlayerByID(1);
    }

    public static Player InitializePlayer()
    {
        if (GetFirstPlayer() == null)
        {
            var p = new Player{
                playerName = DialogueLua.GetVariable("PlayerName").asString,
                gender = DialogueLua.GetVariable("Gender").asString,
                levelName = "MainMap"

            };
            db.Insert(p);
            return p;
        }
        else
        {
            return GetFirstPlayer();
        }
	}

    public void InitPlayerNoReturn()
    {
        InitializePlayer();
    }


    public static void UpdatePlayer(Player player, Vector3 playerLocation)
    {
        player.playerLocationX = playerLocation.x;
        player.playerLocationY = playerLocation.y;
        player.playerLocationZ = playerLocation.z;
        db.Update(player);
    }

}
