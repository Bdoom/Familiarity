using SQLite4Unity3d;

public class Player
{
    [PrimaryKey, AutoIncrement]		
    public int id {get; set;}
    public string playerName {get; set;}

    public string gender {get; set;}

    public float playerLocationX {get; set;}
    public float playerLocationY {get; set;}
    public float playerLocationZ {get; set;}

    public float Food {get; set;}
    public float Water {get; set;}
    public float Health {get; set;}
    public float Weight {get; set;}


    public float MaxFood {get; set;}
    public float MaxWater {get; set;}
    public float MaxHealth {get; set;}
    public float MaxWeight {get; set;}

    public string levelName {get; set;}

}
