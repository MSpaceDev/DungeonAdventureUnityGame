using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player instance;

    public int health = 6;

    int coins;
    Vector2 position;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveLoadManager.instance.Save(transform.position, coins);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SaveLoadManager.instance.Load(out position, out coins);
            transform.position = position;
        }
    }
}
