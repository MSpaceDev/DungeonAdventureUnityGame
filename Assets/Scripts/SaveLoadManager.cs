using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

    public static SaveLoadManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Save(Vector2 position, int coins)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.dat", FileMode.Create);
        bf.Serialize(stream, new PlayerStats(position, coins));
    }

    public void Load(out Vector2 position, out int coins)
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.dat", FileMode.Open);
            PlayerStats playerStats = (PlayerStats) bf.Deserialize(stream);

            position = new Vector2(playerStats.xPos, playerStats.yPos);
            coins = playerStats.coins;
        }
        else
        {
            position = Vector2.zero;
            coins = 0;
        }
    }
}

[System.Serializable]
public class PlayerStats {
    public int coins;

    public float xPos;
    public float yPos;

    public PlayerStats(Vector2 position, int coins)
    {
        this.xPos = position.x;
        this.yPos = position.y;

        this.coins = coins;
    }
}
