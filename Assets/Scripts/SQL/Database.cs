using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using SQLite;

public class Database : MonoBehaviour
{
    public static SQLiteAsyncConnection db;
    public Player mainPlayer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        db = new SQLiteAsyncConnection("gamesave", SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        db.CreateTableAsync<Player>();
        GetFirstPlayer();
    }

    void Start()
    {
    }

    public async void GetPlayerByID(int playerID)
    {
        var query = db.Table<Player>().Where(player => player.id == playerID);
        var list = await query.ToListAsync();

        foreach (var p in list)
        {
            mainPlayer = p;
        }

    }

    public Player GetFirstPlayer()
    {
        if (mainPlayer == null)
        {
            GetPlayerByID(1);
        }

        return mainPlayer;
    }

    public Player InitializePlayer()
    {
        if (GetFirstPlayer() == null)
        {
            var p = new Player{
                playerName = DialogueLua.GetVariable("PlayerName").asString,
                gender = DialogueLua.GetVariable("Gender").asString,
                levelName = "MainMap",
                playerLocationX = -6.49f,
                playerLocationY = -10.28f,
                playerLocationZ = -5

            };
            db.InsertAsync(p);
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

    public void UpdatePlayer()
    {
        Player player = GetFirstPlayer();
        if (player == null)
        {
            Debug.LogWarning("Database player object is null.");
            return;
        }
            
        GameObject realtimePlayer = GameObject.FindWithTag("Player");
        player.playerLocationX = realtimePlayer.transform.position.x;
        player.playerLocationY = realtimePlayer.transform.position.y;
        player.playerLocationZ = realtimePlayer.transform.position.z;
        db.UpdateAsync(player);
    }

}
