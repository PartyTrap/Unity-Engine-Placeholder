using UnityEngine;
using System.Collections;

public class PlayerData 
{
    // C# Class Singleton:

    private static PlayerData instance = null;

    public static PlayerData Instance
    {
        get {
            if (instance == null)
            {
                instance = new PlayerData();
            }
            return instance;
        }
    }


    // PlayerData Constructor:
    private PlayerData ()
    {
       Level = PlayerPrefs.GetString("Level");
       Health = PlayerPrefs.GetInt("Health");
    }


    // Accessors:

    private string level;// = "Ranged_Intro";
    public string Level{
        get{ return this.level;}
        set{
            level = value;
            PlayerPrefs.SetString("Level", level);
        }
    }

    private int health = 0;

    public int Health
    {
        get {
            return this.health;
        }
        set {
            health = value;

            PlayerPrefs.SetInt("Health", health);
          
            }
    }
        
}
