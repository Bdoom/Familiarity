using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class InitializeDatabase : MonoBehaviour
{
    void Start()
    {
        Database.db.CreateTable<Player>();
    }
}
